import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from load_csv import MakeCSV
import calendar
from sklearn.preprocessing import PolynomialFeatures
from sklearn.linear_model import LinearRegression

def MainML(file_name):
    dframe, X_list, x_list = MakeCSV(file_name)
    
    ### APPLYING POLYNOMIAL REGRESSION TO THE DATASET ###
    days = [calendar.day_name[day] for day in range(0,7)]
    index=0
    for day in days: 
        conditions = ['temp','humidity'] 
        for condition in conditions:
            df=X_list[index].groupby('minute',as_index=False).mean()
            m1=df.iloc[:,[0]].values
            data_location = conditions.index(condition)+1
            m2=df.iloc[:,data_location].values
            poly_reg = PolynomialFeatures(degree = 6)
            X_poly = poly_reg.fit_transform(m1)
            poly_reg.fit(X_poly, m2)
            lin_reg = LinearRegression()
            lin_reg.fit(X_poly, m2)
            ### Visualising the Polynomial Regression results
            plt.figure(figsize=(20,10))
            plt.scatter(m1, m2, color = 'red')
            plt.plot(m1, lin_reg.predict(poly_reg.fit_transform(m1)), color = 'blue')
            plt.title('Fit'+condition+' vs mins, day: '+day)
            plt.xlabel('Mins')
            plt.ylabel(condition)
            plt.savefig(r'./ajustes'+"/"+day+'_'+condition+'_fit.jpg')
            plt.close()
        index=index+1
    return 'Training Done!'
#months = [calendar.month_name[month] for month in range(1,13)]
#dframe_avg = dframe.loc[:,['temp','humidity','hour','day_of_week','month']].groupby(['hour','day_of_week','month'],as_index=False).mean()






