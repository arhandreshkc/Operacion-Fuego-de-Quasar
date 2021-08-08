# Operacion-Fuego-de-Quasar

Aplicación fuego de quasar para determinar mensaje oculto y posicion de la nave engmiga.

# Ejecución

El servicio se encuentra desplegado en Amazon AWS Elastic Beanstalk.

* Funcion Topsecret: recibe la informacion de 3 satelites, las distancias hacia el objetivo a encontrar y un mensaje oculto el cual se encuentra entre los mismos con interferencias.
Posibles respuestas: codigo 200 ok junto al mensaje oculto y las coordenadas del objetivo, en caso de error codigo 404 junto al error especificado.

#### Ejemplo de ejecución correcta.
![Topsecret](https://user-images.githubusercontent.com/20496342/128645385-0b8a721b-1846-4191-9e2c-c0a190d7c1d9.png)

#### Ejemplo de ejecución incorrecta.
![Topsecret_error](https://user-images.githubusercontent.com/20496342/128645386-cc65c04a-723b-4da7-adf5-ef25995abafd.png)


