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

@app.route('/get_current_humidity', methods=['GET','POST'])
def GetCurrentHumidity():
    if request.method == 'GET':
        dataset_name = 'data.csv'
        date_now = datetime.now()
        print(date_now)
        predicted = MakePredictions(date_now, option = 'current')
        return jsonify(predicted)

@app.route('/get_custom_humidity', methods=['GET','POST'])
def GetCustomHumidity():
    if request.method == 'POST':
        ### Date should have tuple format ###
        # date = ("YYY-MM-DD","HH:MM" #
        json_body = request.get_json()
        date = (json_body['date'], json_body["hour"])
        predicted = MakePredictions(date, option = 'custom')
        return jsonify(predicted)

if __name__=="__main__":
    app.run()