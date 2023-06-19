import pandas as pd
def f1():
    df = pd.DataFrame({"id1":[3,2,3,4,5,0],"he":["ש","ד","ג","ר","י","א"], "en":["a","b","c","d","e","f"], "cat": [[1,2],[3,4],[1,6,7],[1,2],[5],[]]})

    df2 = pd.DataFrame({"cat": [[1],[3],[1,5],[1,2],[9],[]]})
    df3 = pd.DataFrame()
    li = [df, df2, df3]
    dict = {1:df,2:df2,3:df3}
    meals_data = {key: dict[key] for key in dict if not dict[key].empty}
    print(meals_data)
    #meal_data = df[set(df["Categories"])&set(df2["Categories"])]
     #df = df[df.apply(lambda df: any(i in df["cat"] for i in Categories), axis=1)]

    #df = df[df.apply(lambda df: any(i in df["cat"] for Categories in df2["cat"] for i in Categories), axis=1)]
    #print(any(i in df.loc[0,"cat"] for i in Categories))
    # bool(set([1,2,3]) & set(4,5,6))
    # res = dict(zip(df["id1"][0:4],df["en"][0:4]))
    # mask = df[df.index.isin(res.keys())]['he'].tolist()
    # df =df.set_index("id1")
    # print(mask)
    # df = df.rename_axis("id")
    


if __name__ == '__main__':
    f1()