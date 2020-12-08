# Repositorio del Trabajo Final de Graduación de Licenciatura en informática
# Autor
Diego Gravisaco
# Titulo
Sistema de medición y predicción inteligente de humedad en tierra 
# Configuración
Para realizar una copia en forma local, seguir los siguientes pasos:
1- Descargar [Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
- Configurar git en Visual Studio, ver el siguiente instructivo en este [Link](https://www.kabel.es/configuracion-git-visual-studio)

2 - Crear una base de datos con el nombre MedicionHumedadDB
- Instale el software Microsoft SQL Server del siguiente [Link](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Crear una DB llamada MedicionHumedadDB
- Importar una base SQL local con el script que se encuentra en la carpeta MedicionHumedad-Database > 01-Structure.sql y correrlo

3- Correr la aplicacion creando una nueva instancia de Debug, o presionando F5 en el teclado.
- Esto iniciara una nueva instancia de la aplicacion web que automaticamente ejecutara tambien los servicios rest
![](https://raw.githubusercontent.com/diegogravi/medicionhumedad/main/como%20correr%20visual%20studio.jpg)
4 - Una vez levantada la aplicacion, podra seleccionar cualquiera de las acciones para lo cual le pedira un usuario y contrasena.
- Utilize > usuario: admin | password: admin123456
![](https://raw.githubusercontent.com/diegogravi/medicionhumedad/main/login%20screenshot.jpg)
5 - Bajar el [Arduino Ide](https://www.arduino.cc/en/software)
- agregar la libreria del sensor para arduino uno y conectar en el pin 2 del sensor de humedad
![](https://github.com/diegogravi/medicionhumedad/blob/main/ide%20arduino.JPG?raw=true)
6 - Para el codigo de python ejecutar py FINAL.py para el calculo desde un powershell
