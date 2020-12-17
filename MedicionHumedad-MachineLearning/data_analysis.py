#IMPORTING LIBRARIES
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import os
import calendar
from load_csv import MakeCSV
from sklearn.preprocessing import PolynomialFeatures
from sklearn.linear_model import LinearRegression

### DATA-PREPROCESSING
def DataAnalysis(file_name):
    ### EXPLORATORY DATA ANALYSIS ###
    ### PLOTS IN ./resultados ###
    dframe = MakeCSV(file_name)
    days = [calendar.day_name[day] for day in range(0,7)]
    X_list=[]
    x_list=[]
    for day in days:
        X = dframe.loc[dframe['day_of_week'] == day]
        x = X.iloc[:,[0,3]].values
        X_list.append(X)
        x_list.append(x)
    plt.style.use('fivethirtyeight')
    for info in ['temp', 'humidity']:
            i=0
            for day in days:    
                plt.figure(figsize=(15,10))
                byh = X_list[i].loc[:,[info,'minute']].groupby('minute',as_index=False).mean()
                plt.scatter(byh['minute'],byh[info])
                plt.savefig(r'./resultados'+"/"+day+"_MINUTE_"+info+".jpg")
                plt.close()
                i=i+1

    ### AVG TEMP VS TIME OF THE DAY (minutes) FOR ENTIRE DATASET
    for info in ['temp','humidity']:
        for time in ['minute','day_of_week','hour','month']:     
            plt.figure(figsize=(15,10))
            by = dframe.loc[:,[info,time]].groupby(time).mean()
            if time == 'day_of_week':
                days = [calendar.day_name[day] for day in range(0,7)]
                by = by.reset_index()
                by = by.groupby('day_of_week').sum().reindex(days)
            if time == 'month':
                months = [calendar.month_name[month] for month in range(1,13)]
                by = by.reset_index()
                by = by.groupby('month').sum().reindex(months) 
            plt.scatter(np.array(by.index),by[info])
            plt.savefig(r'./resultados'+"/AVG_VS_"+time.upper()+"_"+info+".jpg")
            plt.close()
    print("Data Analysis Completed Succesfully!!!")
    return

file_name = 'data.csv'
DataAnalysis(file_name)
#months = [calendar.month_name[month] for month in range(1,13)]
#dframe_avg = dframe.loc[:,['temp','humidity','hour','day_of_week','month']].groupby(['hour','day_of_week','month'],as_index=False).mean()

##APPLYING POLYNOMIAL REGRESSION TO THE DATASET

