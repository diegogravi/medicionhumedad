import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from load_csv import MakeCSV
import calendar
from sklearn.preprocessing import PolynomialFeatures
from sklearn.linear_model import LinearRegression
import pickle
import datetime

def MainML(file_name):
    dframe, X_list, x_list = MakeCSV(file_name)
    ### APPLYING POLYNOMIAL REGRESSION TO THE DATASET, SAVING PICKLE AND VISUALIZING RESULTS ###
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
            filename = r'./pickles' + "/" + day + '_' + condition + '_' + 'poly_reg_model.pickle'
            pickle.dump(poly_reg, open(filename, 'wb'))
            lin_reg = LinearRegression()
            lin_reg.fit(X_poly, m2)
            filename = r'./pickles' + "/" + day + '_' + condition + '_' + 'lin_reg_model.pickle'
            pickle.dump(lin_reg, open(filename, 'wb'))
            ### Visualization ###
            plt.figure(figsize=(20,10))
            plt.scatter(m1, m2, color = 'red')
            plt.plot(m1, lin_reg.predict(poly_reg.fit_transform(m1)), color = 'blue')
            plt.title('Fit '+condition+' vs mins, day: '+day)
            plt.xlabel('Mins')
            plt.ylabel(condition)
            plt.savefig(r'./ajustes'+"/"+day+'_'+condition+'_fit.jpg')
            plt.close()
        index=index+1
    output = {}
    output['output'] = 'Training Done!'
    return output

def MakePredictions(date, option):
    if option == 'current':
        hour=('%02d'%(date.hour))
        minute = ('%02d'%(date.minute))
        my_day = date.today()
        day = calendar.day_name[my_day.weekday()]
    if option == 'custom':
        hour = int(date[1].split(":")[0])
        minute = int(date[1].split(":")[1]) 
        day = datetime.date(int(date[0].split("-")[0]), int(date[0].split("-")[1]), int(date[0].split("-")[2])).strftime("%A")
    
    minute_count = int(hour)*60 + int(minute)
    x_to_predict = np.array(minute_count).reshape(-1, 1)
    conditions = ['temp','humidity']
    output={}
    for condition in conditions:
        lin_reg = pickle.load(open(r'./pickles' + "/" + day + '_' + condition + '_' + 'lin_reg_model.pickle', 'rb'))
        poly_reg = pickle.load(open(r'./pickles' + "/" + day + '_' + condition + '_' + 'poly_reg_model.pickle', 'rb'))
        y_predicted = lin_reg.predict(poly_reg.fit_transform(x_to_predict))[0]
        output[condition] = y_predicted
    return output






