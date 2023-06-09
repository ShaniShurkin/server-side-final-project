# #!/usr/bin/env python
# # coding: utf-8

# # In[25]:

#!/usr/bin/env python
# -*- coding: utf-8 -*-
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd 
from pulp import * 
import seaborn as sns
import json
from flask import Flask, request, jsonify
import urllib.parse

week_days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday']
# day_meals = ['Breakfast','Snack1','Lunch','Snack2','Dinner']

# Around 10% for the snack number 1 
# Around 10% for the snack number 2 
# Around 30% for dinner 
# 35% for lunch 
# 15 % for breakfast
# meal_calories = [0.15, 0.1, 0.35, 0.1, 0.3]
# calories_per_meal = dict(zip(day_meals,meal_calories))

app = Flask(__name__)
@app.route('/process_data', methods=['POST'])
def process_data():
    json_data = request.get_json()
    # json_data = dict.loads(json_string)
    json_foods = json.loads(json_data["data"])
    meals_and_calories = json.loads(json_data["mealsCalories"])
    day_meals = list(meals_and_calories.keys())
    calories = int(json_data["calorieConsumption"])
    kg = int(json_data["weight"])
    data = create_df(json_foods)
    #dict_result = better_model(weight, calories , data)
    days_data = random_dataset_day(data)
    res_model = []
    for day in week_days:
        day_data = days_data[day]
        meals_data = random_dataset_meal(data, day_data, day_meals)
        meal_model = []
        for meal in day_meals:
            meal_data = meals_data[meal]
            prob  = pulp.LpProblem( "Diet", LpMinimize )
            caloriesForMeal = meals_and_calories[meal]*calories
            sol_model = model(prob,kg,caloriesForMeal,meal_data)
            meal_model.append(sol_model)
        res_model.append(meal_model)
    unpacked = []
    for i in range(len(res_model)):
        unpacked.append(dict(zip(day_meals,res_model[i])))
    dict_result = dict(zip(week_days,unpacked))
    json_response = json.dumps(dict_result, ensure_ascii=False)
    response = json_response
    return response
    
def create_df(json_data):
    data = pd.DataFrame(json_data)
    data = data[['Shmmitzrach','FoodEnergy','Carbohydrates','TotalFat','Protein', 'EnglishName']].dropna()
    data = data.dropna()
    return data
  


def random_dataset_day(data):
    frac_data = data.sample(frac=1).reset_index().drop('index',axis=1)
    split_values = np.linspace(0,len(data),7).astype(int)
    split_values[-1] = split_values[-1]-1
    day_data = []
    for s in range(len(split_values)-1):
        day_data.append(frac_data.loc[split_values[s]:split_values[s+1]])
    return dict(zip(week_days,day_data))

def random_dataset_meal(data,day_data, day_meals):
    frac_data = day_data.sample(frac=1).reset_index().drop('index',axis=1)
    split_values_m = np.linspace(0,len(data)/len(week_days),len(day_meals)+1).astype(int)
    split_values_m[-1] = split_values_m[-1]-1
    #frac_data.rename(columns={'':"index"}, inplace=True)
    meals_data = []
    for s in range(len(split_values_m)-1):
        meals_data.append(frac_data.loc[split_values_m[s]:split_values_m[s+1]])
    return dict(zip(day_meals,meals_data))

def build_nutritional_values(kg,calories):
    protein_calories = kg*4
    res_calories = calories-protein_calories
    carb_calories = calories/2.
    fat_calories = calories-carb_calories-protein_calories
    res = {'Protein Calories':protein_calories,'Carbohydrates Calories':carb_calories,'Fat Calories':fat_calories}
    return res

def extract_gram(table):
    protein_grams = table['Protein Calories']/4.
    carbs_grams = table['Carbohydrates Calories']/4.
    fat_grams = table['Fat Calories']/9.
    res = {'Protein Grams':protein_grams, 'Carbohydrates Grams':carbs_grams,'Fat Grams':fat_grams}
    return res

def model(prob,kg,calories,meals_data):
    meals_data = meals_data.reset_index().drop('index',axis=1)
    G = extract_gram(build_nutritional_values(kg,calories))
    E = G['Carbohydrates Grams']
    F = G['Fat Grams']
    P = G['Protein Grams']
    meals_data = meals_data[meals_data.FoodEnergy!=0]
    food = meals_data.EnglishName.tolist()
    c = meals_data.FoodEnergy.tolist()
    x = pulp.LpVariable.dicts( "x", indices = food, lowBound=0, upBound=1.5, cat='Continuous', indexStart=[] )
    e = meals_data.Carbohydrates.tolist()
    f = meals_data.TotalFat.tolist()
    p = meals_data.Protein.tolist()
    prob  = pulp.LpProblem( "Diet", LpMinimize )
    prob += pulp.lpSum( [x[food[i]]*c[i] for i in range(len(food))]  )
    prob += pulp.lpSum( [x[food[i]]*e[i] for i in range(len(x)) ] )>=E
    prob += pulp.lpSum( [x[food[i]]*f[i] for i in range(len(x)) ] )>=F
    prob += pulp.lpSum( [x[food[i]]*p[i] for i in range(len(x)) ] )>=P
    prob.solve()
    variables = []
    values = []
    for v in prob.variables():
        variable = v.name
        value = v.varValue
        variables.append(variable)
        values.append(value)
    values = np.array(values).round(2).astype(float)
    sol = pd.DataFrame(np.array([food,values]).T, columns = ['Food','Quantity'])
    sol['Quantity'] = sol.Quantity.astype(float)
    sol = sol[sol['Quantity']!=0.0]
    sol.Quantity = sol.Quantity*100
    sol = sol.rename(columns={'Quantity':'Quantity (g)'})
    df_sol = sol.to_dict()
    he_res = meals_data[meals_data.index.isin(df_sol['Food'].keys())]['Shmmitzrach'].tolist()
    print(he_res,df_sol['Food'].keys(), meals_data)
    he_food = dict(zip(df_sol['Food'].keys(), he_res))
    df_sol['he_food'] = he_food
    return df_sol
# def better_model(kg,calories,data):
#     days_data = random_dataset_day(data)
#     res_model = []
#     for day in week_days:
#         day_data = days_data[day]
#         meals_data = random_dataset_meal(data, day_data)
#         meal_model = []
#         for meal in day_meals:
#             meal_data = meals_data[meal]
#             prob  = pulp.LpProblem( "Diet", LpMinimize )
#             sol_model = model(prob,kg,calories,meal,meal_data)
#             meal_model.append(sol_model)
#         res_model.append(meal_model)
#     unpacked = []
#     for i in range(len(res_model)):
#         unpacked.append(dict(zip(day_meals,res_model[i])))
#     unpacked_tot = dict(zip(week_days,unpacked))
#     return unpacked_tot

if __name__ == '__main__':
    app.run()

# #diet = better_model(44,1600)['Sunday']
