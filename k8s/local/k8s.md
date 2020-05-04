# Apply deployments and services

Ensure your docker images are already published in a registry (no local images are supported)

```cmd
kubectl apply -f heroes-sql.yaml
kubectl apply -f heroes-api.yaml
```

# Get the port where the api is listening to

```cmd
kubectl get services

NAME             TYPE           CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
heroes-api-svc   NodePort       10.97.246.189   <none>        80:32225/TCP     6h

heroes-sql-svc   LoadBalancer   10.97.27.253    localhost     1433:30579/TCP   7h

kubernetes       ClusterIP      10.96.0.1       <none>        443/TCP          100d
```

In previous case the port is 32225

# Send requests to api

```bash
curl http://localhost:32225/api/heros
```

# Update image 

```cmd
kubectl set image deployments/heroes-api-deployment heroes-api=snavarropino/heroesapi:v2
```
