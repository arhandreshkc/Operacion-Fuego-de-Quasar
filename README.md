# Operacion-Fuego-de-Quasar

Aplicación fuego de quasar para determinar mensaje oculto y posicion de la nave engmiga.

# Ejecución

El servicio se encuentra desplegado en Amazon AWS Elastic Beanstalk.

* Funcion Topsecret: recibe la informacion de 3 satelites, las distancias hacia el objetivo a encontrar y un mensaje oculto el cual se encuentra entre los mismos con interferencias.
Posibles respuestas: codigo 200 ok junto al mensaje oculto y las coordenadas del objetivo, en caso de error codigo 404 junto al error especificado.
