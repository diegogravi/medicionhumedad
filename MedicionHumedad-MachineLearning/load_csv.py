import pandas as pd
import os

def MakeCSV(file_name):
    dir_path = os.path.dirname(os.path.realpath(__file__))
    dframe = pd.read_csv(os.path.join(dir_path, file_name),delimiter=';',parse_dates=['date_time'])
    dframe['year'] = dframe['date_time'].dt.year
    dframe['minute'] = dframe['date_time'].dt.minute
    dframe['hour'] = dframe['date_time'].dt.hour
    dframe['day_of_week'] = dframe['date_time'].dt.day_name()
    dframe['month'] = dframe['date_time'].dt.month_name()
    dframe['minute'] = dframe['minute'] + dframe['hour']*60
    dframe.drop('id',inplace=True,axis=1)
    print(dframe.head(10))
    return dframe