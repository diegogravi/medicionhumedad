import json
from flask import request, jsonify, Flask
from data_analysis import DataAnalysis

app = Flask(__name__)
@app.route('/get_temp_humidity', methods=['GET','POST'])
def GetTempHumidity():
        if request.method == 'GET':
            dataset_name = 'data.csv'
            DataAnalysis(dataset_name)
            predicted = main_ml.make_pred()
            print(predicted)
            return jsonify(predicted)