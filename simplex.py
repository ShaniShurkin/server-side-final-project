# #!/usr/bin/env python
# # coding: utf-8

# # In[25]:


# import matplotlib.pyplot as plt
# import numpy as np
# import pandas as pd 
# from pulp import * 
# import seaborn as sns


# # In[26]:

# import json
# import urllib.parse

# encoded_json_string = sys.argv[1]
# print(encoded_json_string)
# json_string = urllib.parse.unquote(encoded_json_string)
# print(json_string)
# data = json.loads(json_string)
# print(data)
# data = pd.read_csv(r'C:\\Users\\User\\Desktop\\final project\\food.csv', encoding='UTF-16 LE', sep='\t')
# #data.head(20)


# # In[27]:


# data.info()


# # In[28]:


# data = data[['shmmitzrach','food_energy','carbohydrates','total_fat','protein']]
# #print(data.info())
# #data.head(10)


# # In[29]:


# data_with_null = data[data.isnull().any(axis=1)]
# #data_with_null


# # In[30]:


# data = data.dropna()
# #data.info()


# # In[31]:


# week_days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday']
# split_values = np.linspace(0,len(data),7).astype(int)
# split_values[-1] = split_values[-1]-1
# #split_values


# # In[32]:


# def random_dataset_day():
#     frac_data = data.sample(frac=1).reset_index().drop('index',axis=1)
#     #frac_data.rename(columns={'':"index"}, inplace=True)
#     day_data = []
#     for s in range(len(split_values)-1):
#         day_data.append(frac_data.loc[split_values[s]:split_values[s+1]])
#     return dict(zip(week_days,day_data))
# random_dataset_day()['Sunday'].head(20)


# # In[33]:


# day_meals = ['Breakfst','Snack1','Lunch','Snack2','Dinner']
# split_values_m = np.linspace(0,len(data)/len(week_days),len(day_meals)+1).astype(int)
# split_values_m[-1] = split_values_m[-1]-1
# split_values_m


# # In[34]:


# def random_dataset_meal(day_data):
#     frac_data = day_data.sample(frac=1).reset_index().drop('index',axis=1)
#     #frac_data.rename(columns={'':"index"}, inplace=True)
#     meals_data = []
#     for s in range(len(split_values_m)-1):
#         meals_data.append(frac_data.loc[split_values_m[s]:split_values_m[s+1]])
#     return dict(zip(day_meals,meals_data))
# random_dataset_meal(random_dataset_day()['Sunday'])


# # In[35]:


# def build_nutritional_values(kg,calories):
#     protein_calories = kg*4
#     res_calories = calories-protein_calories
#     carb_calories = calories/2.
#     fat_calories = calories-carb_calories-protein_calories
#     res = {'Protein Calories':protein_calories,'Carbohydrates Calories':carb_calories,'Fat Calories':fat_calories}
#     return res
# build_nutritional_values(70,1500)


# # In[36]:


# def extract_gram(table):
#     protein_grams = table['Protein Calories']/4.
#     carbs_grams = table['Carbohydrates Calories']/4.
#     fat_grams = table['Fat Calories']/9.
#     res = {'Protein Grams':protein_grams, 'Carbohydrates Grams':carbs_grams,'Fat Grams':fat_grams}
#     return res
# extract_gram(build_nutritional_values(70,1500))


# # <p>Around 10% for the snack number 1 <br/>
# # Around 10% for the snack number 2 <br/>
# # Around 30% for dinner <br/>
# # 35% for lunch <br/>
# # 15 % for breakfast</p>
# # 

# # In[37]:


# meal_calories = [0.15, 0.1, 0.35, 0.1, 0.3]
# calories_per_meal = dict(zip(day_meals,meal_calories))
# calories_per_meal


# # In[40]:


# days_data = random_dataset_day()
# def model(prob,kg,calories,meal,meals_data):
#     calories = calories_per_meal[meal]*calories
#     G = extract_gram(build_nutritional_values(kg,calories))
#     E = G['Carbohydrates Grams']
#     F = G['Fat Grams']
#     P = G['Protein Grams']
#     meals_data = meals_data[meals_data.food_energy!=0]
#     food = meals_data.shmmitzrach.tolist()
#     c = meals_data.food_energy.tolist()
#     x = pulp.LpVariable.dicts( "x", indices = food, lowBound=0, upBound=1.5, cat='Continuous', indexStart=[] )
#     e = meals_data.carbohydrates.tolist()
#     f = meals_data.total_fat.tolist()
#     p = meals_data.protein.tolist()
#     prob  = pulp.LpProblem( "Diet", LpMinimize )
#     prob += pulp.lpSum( [x[food[i]]*c[i] for i in range(len(food))]  )
#     prob += pulp.lpSum( [x[food[i]]*e[i] for i in range(len(x)) ] )>=E
#     prob += pulp.lpSum( [x[food[i]]*f[i] for i in range(len(x)) ] )>=F
#     prob += pulp.lpSum( [x[food[i]]*p[i] for i in range(len(x)) ] )>=P
#     prob.solve()
#     variables = []
#     values = []
#     for v in prob.variables():
#         variable = v.name
#         value = v.varValue
#         variables.append(variable)
#         values.append(value)
#     values = np.array(values).round(2).astype(float)
#     sol = pd.DataFrame(np.array([food,values]).T, columns = ['Food','Quantity'])
#     sol['Quantity'] = sol.Quantity.astype(float)
#     sol = sol[sol['Quantity']!=0.0]
#     sol.Quantity = sol.Quantity*100
#     sol = sol.rename(columns={'Quantity':'Quantity (g)'})
#     return sol
# # def total_model(kg,calories):
# #     result = []
# #     for day in week_days:
# #         prob  = pulp.LpProblem( "Diet", LpMinimize )
# #         print('Building a model for day %s \n'%(day))
# #         result.append(model(prob,day,kg,calories))
# #     return dict(zip(week_days,result))


# # In[45]:


# def better_model(kg,calories):
#     days_data = random_dataset_day()
#     res_model = []
#     for day in week_days:
#         day_data = days_data[day]
#         meals_data = random_dataset_meal(day_data)
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


# # In[53]:


# diet = better_model(44,1600)['Sunday']


# # # In[ ]:





# # # In[ ]:





# # # In[ ]:
# print("Hi")


import json
from flask import Flask, request, jsonify

app = Flask(__name__)
data = ""
# @app.route('/process_data', methods=['POST'])
# def process_data():
#     data = json.loads(request.data)
#     # do something with the data
    


@app.route('/api/process_data', methods=['GET'])
def get_data():
   return jsonify(data)


if __name__ == '__main__':
    app.run()


