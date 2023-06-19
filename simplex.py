# #!/usr/bin/env python
# # coding: utf-8

# TODO: handle empty DataFrame, should be in random_dataset_day, 
# solve the problem if there are the same meals
# return meals when th names are  possible for finding
# try and catch

import array
import numpy as np
import pandas as pd 
from pulp import * 
#pulp היא ספריית אופטימיזציה של תכנות ליניארי
import seaborn as sns
import json
from flask import Flask, request, jsonify
import urllib.parse

week_days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday']

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
    food_df = json.loads(json_data["data"])
    food_df = pd.DataFrame(food_df)[['Shmmitzrach','FoodEnergy','Carbohydrates','TotalFat','Protein', 'EnglishName', 'Categories']].dropna()
    meals_df = json.loads(json_data["meals"])
    meals_df = pd.DataFrame(meals_df)
    meals_df = meals_df.set_index("Code")
    calories = int(json_data["calorieConsumption"])
    kg = int(json_data["weight"])
    json_response = json.dumps(create_diet(food_df, meals_df, calories, kg), ensure_ascii=False)
    return json_response
    

def create_diet(food_df, meals_df, calories, kg):   
    days_data = random_dataset_day(food_df)
    res_model = []
    for day in week_days:
        day_data = days_data[day]
        meals_data = random_dataset_meal(day_data, meals_df)
        meals_data = {key: meals_data[key] for key in meals_data if not meals_data[key].empty}
        meal_model = []
        for meal_idx in meals_df.index:
            meal_data = meals_data.get(meal_idx, meals_data[2])
            caloriesForMeal = meals_df.at[meal_idx, "Calories"]*calories
            sol_model = model(kg, caloriesForMeal, meal_data)
            meal_model.append(sol_model)
        res_model.append(meal_model)
    unpacked = []
    for i in range(len(res_model)):
        unpacked.append(dict(zip(meals_df.index,res_model[i])))
    dict_result = dict(zip(week_days,unpacked))
    return dict_result


def random_dataset_day(data):
    frac_data = data.sample(frac=1).reset_index().drop('index',axis=1)
    split_values = np.linspace(0,len(data),7).astype(int)
    split_values[-1] = split_values[-1]-1
    day_data = []
    for s in range(len(split_values)-1):
        day_data.append(frac_data.loc[split_values[s]:split_values[s+1]])
    return dict(zip(week_days,day_data))


def random_dataset_meal(day_data, meals_df):
    meals_data = []
    for meal in meals_df.index:
        # searches if one of food's categories is in meal categories
        meal_data = day_data[day_data.apply(lambda df: any(i in df["Categories"] for i in meals_df.loc[meal, "Categories"]), axis=1)]
        meals_data.append(meal_data)
    res = dict(zip(meals_df.index,meals_data))
    return res
 

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


def model(kg,calories,meals_data):
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
    prob = pulp.LpProblem( "Diet", LpMinimize )
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

if __name__ == '__main__':
    app.run()
