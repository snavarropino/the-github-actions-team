
# Step 1: Just the Api with no ingress

## Apply deployments and services

Ensure your docker images are already published in a registry (lo local images are supported)

```cmd
kubectl apply -f heroes-sql.yaml
kubectl apply -f heroes-api.yaml
```

## Check the services are up

```cmd
kubectl get services

NAME             TYPE           CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
heroes-api-svc   NodePort       10.97.246.189   <none>        80:32225/TCP     6h

heroes-sql-svc   LoadBalancer   10.97.27.253    localhost     1433:30579/TCP   7h

kubernetes       ClusterIP      10.96.0.1       <none>        443/TCP          100d
```

## Perform port fordwarding (with visual studio code) to one of the api pods. Map to localhost 8081

Then invoke teh api with following command
```bash
curl http://localhost:8081/api/heros
```

## Update image 

```cmd
kubectl set image deployments/heroes-api-deployment heroes-api=snavarropino/heroesapi:v2
```

# Step 2:Api with ingress

## Install nginx ingress controller 

Instructions taken from https://docs.microsoft.com/es-es/azure/aks/ingress-tls

```cmd
# Create a namespace for your ingress resources
kubectl create namespace ingress-basic

# Use Helm to deploy an NGINX ingress controller
helm install stable/nginx-ingress \
    --namespace ingress-basic \
    --set controller.replicaCount=2 \
    --set controller.nodeSelector."beta\.kubernetes\.io/os"=linux \
    --set defaultBackend.nodeSelector."beta\.kubernetes\.io/os"=linux
```

## Get public ip

```cmd
kubectl get service -l app=nginx-ingress --namespace ingress-basic
```

## Configure DNS name

Modify script dns.sh with proper IP and execute it (in linux or WSL)

```cmd
./dns.sh
```

## Create ingress

```cmd
kubectl apply -f heroes-ingress.yaml
```

## Test API

```cmd
curl http://heroes-aks.westeurope.cloudapp.azure.com/api/heros
```

# Step 3: Api and web with ingress 

## Deploy web
```cmd
kubectl apply -f heroes-web.yaml
```
## Test it

Open browser and navigate to  http://heroes-aks.westeurope.cloudapp.azure.com
