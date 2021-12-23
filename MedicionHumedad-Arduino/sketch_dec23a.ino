//void setup() {
  // put your setup code here, to run once:
//  Serial.begin(9600); // open serial port, set the baud rate as 9600 bps
//}

//void loop() {
  // put your main code here, to run repeatedly:
//int val;
  //val = analogRead(0); //connect sensor to Analog 0
  //Serial.println(val); //print the value to serial port
  //delay(100);
//}
#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "MySpectrumWifib0-5g";
const char* password = "smileyberry319";

//La url de la creacion de la medicion
String serverName = "https://localhost:44399/api/Medicion/CrearMedicionConParams";

unsigned long lastTime = 0;
// Timer set to 10 minutes (600000)
//unsigned long timerDelay = 600000;
// Set timer to 5 seconds (5000)
unsigned long timerDelay = 5000;

const int AirValue = 526;   //you need to replace this value with Value_1
const int WaterValue = 280;  //you need to replace this value with Value_2
int intervals = (AirValue - WaterValue)/3;
int soilMoistureValue = 0;
void setup() {
  Serial.begin(9600); // open serial port, set the baud rate to 9600 bps
  
  WiFi.begin(ssid, password);
  Serial.println("Conectando");
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Conectado a wifi con la ip: ");
  Serial.println(WiFi.localIP());
 
}
void loop() {
//soilMoistureValue = analogRead(A0);  //put Sensor insert into soil
soilMoistureValue = analogRead(0);  //put Sensor insert into soil
//String soilMoistureValueString = "El valor de ahora es: ";
//soilMoistureValueString.concat(soilMoistureValueString);
//Serial.println(soilMoistureValue);

 //int val = analogRead(0); //connect sensor to Analog 0
  Serial.println(soilMoistureValue); //print the value to serial port

//float porcentaje = soilMoistureValue * 100 / WaterValue;
float porcentaje = 100 - ((soilMoistureValue - WaterValue)*100/246);

String porcentajeString ="El porcentaje es: %";
porcentajeString.concat(porcentaje);
  Serial.println( porcentajeString);
if(soilMoistureValue > WaterValue && soilMoistureValue < (WaterValue + intervals))
{

  Serial.println("Very Wet");
}
else if(soilMoistureValue > (WaterValue + intervals) && soilMoistureValue < (AirValue - intervals))
{
  Serial.println("Wet");
}
else if(soilMoistureValue < AirValue && soilMoistureValue > (AirValue - intervals))
{
  Serial.println("Dry");
}

//enviar la llamada al crearMedicion con parametros
if(WiFi.status()== WL_CONNECTED){
      HTTPClient http;

      String serverPath = serverName + "?humedad=" + String(porcentaje,2) + "&sensorId=2&plantacionId=2";
      
      // la url se inicializa con el http begin
      http.begin(serverPath.c_str());
      
      // enviar HTTP GET request
      int httpResponseCode = http.GET();
    
    if (httpResponseCode>0) {
        Serial.print("HTTP Response code: ");
        Serial.println(httpResponseCode);
        String payload = http.getString();
        Serial.println(payload);
      }
      else {
        Serial.print("Error code: ");
        Serial.println(httpResponseCode);
      }
      // Liberar recursos
      http.end();
}
else {
      Serial.println("WiFi desconectado");
    }
delay(350);
}
