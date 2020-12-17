import json
from flask import request, jsonify, Flask
from data_analysis import DataAnalysis
from main_ml import MainML

app = Flask(__name__)
app.config["DEBUG"] = True

@app.route('/get_temp_humidity', methods=['GET','POST'])
def GetTempHumidity():
    if request.method == 'GET':
        dataset_name = 'data.csv'
        out = DataAnalysis(dataset_name)
        train = MainML(dataset_name)
        #return jsonify(train)
        return train

if __name__=="__main__":
    app.run()