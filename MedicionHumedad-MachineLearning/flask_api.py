import json
from datetime import datetime
from flask import request, jsonify, Flask
from data_analysis import DataAnalysis
from main_ml import MainML, MakePredictions

app = Flask(__name__)
app.config["DEBUG"] = True

@app.route('/analysis_train', methods=['GET','POST'])
def AnalysisTrainModels():
    if request.method == 'GET':
        dataset_name = 'data.csv'
        out = DataAnalysis(dataset_name)
        train = MainML(dataset_name)
        return train

@app.route('/get_current_temp_humidity', methods=['GET','POST'])
def GetCurrentTempHumidity():
    if request.method == 'GET':
        dataset_name = 'data.csv'
        date_now = datetime.now()
        print(date_now)
        predicted = MakePredictions(date_now, option = 'current')
        return jsonify(predicted)

@app.route('/get_custom_temp_humidity', methods=['GET','POST'])
def GetCustomTempHumidity():
    if request.method == 'GET':
        dataset_name = 'data.csv'
        ### Date should have tuple format ###
        # date = ("YYY-MM-DD","HH:MM" #
        date = ("2020-12-18","12:11")
        predicted = MakePredictions(date, option = 'custom')
        return jsonify(predicted)

if __name__=="__main__":
    app.run()