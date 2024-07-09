# Pagos generales para deployar el proyecto
- Publicar el proyecto
- Dockerizar la publucacación
- Para dockerizar la publicacion, copiar **DockerfilePublicacion** en la carpeta de la publicacion y cambiar nombre a solo **Dockerfile**

# Pasos para poder deployar el proyecto Local
- Ejecutar comando **docker** para crear la imagen

```
docker build --tag nombre_de_imagen:version ubicacion_archivo_dockerfile
```

- Ejem:

```
docker build --tag almacen-api:v1 .
```

- Ejecutar contenedor

```
docker run -d --name nombre_contenedor -p puerto_mi_pc:puerto_contenedor nombre_imagen:version_imagen
```

- Ejem

```
docker run -d --name almacen-api -p 5235:80 almacen-api:v1
```

# En caso de usar EC2

- Crear instancia Ec2
- Configurar docker en el servidor
- Usaremos docker.hub para subir nuestra imagen y luego descargar en el servidor (se mostrara en los siguientes pasos)
- Ejecutar comando para construir imagen segun manda **docker.hub**

```
docker build --tag nombre_usuario_dockerhub/nombre_de_imagen:version ubicacion_archivo_dockerfile
```

- Ejem:

```
docker build --tag dominanto/almacen-api:v1 .
```
- Nos logueamos a **docker.hub** (se hace solo una vez, en caso ya lo hayas echo antes en tu pc, no necesitarias ejecutar esto de nuevo)

```
docker login
```

- Pusheamos la imagen a **docker.hub**

```
docker push nombre_imagen
```

- Ejem

```
docker push dominanto/almacen-api:v2
```

- Descargamos imagen en el servidor, en nuestro caso es el siguiente.

```
docker pull dominanto/almacen-api:v2
```

- Ejecutamos el comando para correr contenedor

```
docker run -d --name almacen-api -p 5235:80 dominanto/almacen-api:v2
```
