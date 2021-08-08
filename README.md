# Operacion-Fuego-de-Quasar

Aplicación fuego de quasar para determinar mensaje oculto y posicion de la nave engmiga.

# Ejecución

El servicio se encuentra desplegado en Amazon AWS Elastic Beanstalk.

* Funcion POST Topsecret: 
  * Petición tipo POST
  * Link: http://operacionfuegodequasar-env.eba-6zdvexms.us-east-2.elasticbeanstalk.com/Topsecret
  * Recibe el nombre de 3 satélites, las distancias hacia el objetivo a encontrar de cada satélite y un mensaje oculto el cual se encuentra entre los mismos con interferencias.
  * Posibles respuestas: codigo 200 ok junto al mensaje oculto y las coordenadas del objetivo, en caso de error codigo 404 junto al error especificado.
  * Formato del Payload:

    {	
      "satellites":[
          {
          "name": "kenobi",
          "distance": 100.0,
          "message": ["este", "", "", "mensaje", ""]
          },
          {
          "name": "skywalker",
          "distance": 115.5,
          "message": ["", "es", "", "", "secreto"]
          },
          {
          "name": "sato",
          "distance": 142.7,
          "message": ["este", "", "un", "", ""]
          }
        ]
    }


    * Ejemplo de ejecución correcta.
![Topsecret](https://user-images.githubusercontent.com/20496342/128645497-c58bea9c-949b-457d-ba22-050e74bcbc56.png)


    * Ejemplo de ejecución incorrecta.
![Topsecret_error](https://user-images.githubusercontent.com/20496342/128645386-cc65c04a-723b-4da7-adf5-ef25995abafd.png)

* Funcion POST Topsecret_Split: 
  * Petición tipo POST
  * Link: http://operacionfuegodequasar-env.eba-6zdvexms.us-east-2.elasticbeanstalk.com/Topsecret_Split   
  * Recibe la información de un satélite que será almacenado para luego ser utlizado para ubicar al objetivo y descifrar el mensaje oculto.
  * Posibles respuestas: codigo 200 ok junto al mensaje oculto y las coordenadas del objetivo, en caso de error codigo 404 junto al error especificado.
  * Formato del Payload:
    /topsecret_split/{satellite_name}
    {
    "distance": 100.0,
    "message": ["este", "", "", "mensaje", ""]
    }
    * Ejemplo de ejecución correcta.
    ![Kenobi](https://user-images.githubusercontent.com/20496342/128645926-06d11f94-4f97-4374-ad81-2451b635a4fd.png)
    ![skywalker](https://user-images.githubusercontent.com/20496342/128645870-c496e0f8-e9ff-4b04-85c5-280f7f1e6102.png)
    ![sato](https://user-images.githubusercontent.com/20496342/128645867-1306ee01-89a6-405e-aef8-c82adf9a8e28.png)
    
    * Ejemplo de ejecución incorrecta.
    ![error_desconocidos](https://user-images.githubusercontent.com/20496342/128645958-0f930752-bc37-4b15-bd57-b562aa0d3987.png)
    ![error_ya_cargados](https://user-images.githubusercontent.com/20496342/128645959-8dfc585a-d12d-4e71-8c3f-29dca6515130.png)

* Funcion GET Topsecret_Split: 
  * Petición tipo POST
  * Link: http://operacionfuegodequasar-env.eba-6zdvexms.us-east-2.elasticbeanstalk.com/Topsecret_Split  
  * Recupera la información cargada en de la función post (Topsecret_Split) y determina la ubicación del objetivo y el mensaje oculto enviado. Luego de cada llamada a esta   función se limpian los satélites almacenados. 
  * Posibles respuestas: codigo 200 ok junto al mensaje oculto y las coordenadas del objetivo, en caso de error codigo 404 junto al error especificado.
  
    * Ejemplo de ejecución correcta.
  ![get ok 2](https://user-images.githubusercontent.com/20496342/128646152-31a3f592-9984-4e65-8646-b47391c7fdba.png)

    * Ejemplo de ejecución incorrecta.  
  ![get ok](https://user-images.githubusercontent.com/20496342/128646100-5e66193d-510a-4741-8bbe-cbc68b85a28a.png)
  
# Arquitectura
 * Diagrama de clases UML donde se representan las clases que conforman la aplicación
 ![UML](https://user-images.githubusercontent.com/20496342/128646216-955c8e86-2650-405e-92f2-f4541c5adc34.png)




