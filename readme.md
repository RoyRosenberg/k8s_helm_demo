# Abstract
Simple example of an Asp.net core applciation and Redis server in K8S and Helm 

# Web Server
A simple web server that connects to Redis and look for _foo_ variable

# Helm Charts
## Redis
Helm charts for Redis

## Web-Server
Helm Charts for the web server

# Steps
## Step 1: Build the image
Run the folloiwng _docker build_ command
```
cd <repo_folder>
docker build -t web-server:3.0 -f .\K8S.WebApp\Dockerfile .
```

## Step 2: Install Redis
Invoke the following _helm_ command to deploy redis to my-app namespace in Kubernetes

```
helm upgrade --install redis ./redis --namespace my-app
```

## Step 3: Install Web-Server
Invoke the following _helm_ command to deploy web server to my-app namespace in Kubernetes

```
helm upgrade --install web-server ./web-server --namespace my-app
```

## Step 4: Make sure all is working
Invoke the following _kubectl_ command and check the pods/services/deployments
```
kubectl get all -n my-app
``` 
You should get result with service details, i.e.,
```
...
NAME                 TYPE       CLUSTER-IP      EXTERNAL-IP   PORT(S)                         AGE
service/redis        NodePort   10.107.27.217   <none>        6379:31351/TCP,8001:30571/TCP   23m
service/web-server   NodePort   10.98.38.65     <none>        8080:31803 /TCP                  6s
...
```
If you are running in Docker Desktop, find the port of the servicers and navigate to http://localhost:PORT

- Redis UI: http://localhost:30571
- Web Server: http://localhost:31803