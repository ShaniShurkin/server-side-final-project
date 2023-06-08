import pandas as pd
def f1():
    df = pd.DataFrame({"id1":[3,2,3,4,5,0],"he":["ש","ד","ג","ר","י","א"], "en":["a","b","c","d","e","f"]})
    res = dict(zip(df["id1"][0:4],df["en"][0:4]))
    mask = df[df.index.isin(res.keys())]['he'].tolist()
    df =df.set_index("id1")
    print(mask)
    df = df.rename_axis("id")
    


if __name__ == '__main__':
    f1()