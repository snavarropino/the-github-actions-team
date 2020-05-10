 # Terraform hints
 
In order to run this locally we have to do next steps:

 ## Login to azure and set subscription
 
 ``` cmd
 az login
 az account set -s <subscription id>
 ```
 
## Create storage for terraform backend (state file)

We have to manually create following resources, using the names configured in backend.tfvars

- Resource group

- Storage account

- Blob container

First we create the resource group and the storage account
 ``` cmd
az group create -l westeurope -n TerraformState
az storageV2 account create -n githubactionslocalstate -g TerraformState -l westeurope --sku Standard_LRS
 ```

Then we can list storage account keys in order to use such key in the container creation. 

``` cmd
az storage account keys list --account-name githubactionslocalstate 
az storage container create -n tfstate --account-name githubactionslocalstate --account-key <storage key>
 ```

## Init

``` cmd
terraform init --backend-config=backend.tfvars
```

 ## Plan

``` cmd
 terraform plan --var-file=configs\heroes.LOCAL.tfvars
 ```

 ## Apply

 ``` cmd
 terraform apply --var-file=configs\heroes.LOCAL.tfvars
 ```

After previous steps terraform state is going to be stored in a blog (named "terraform.local.state") inside the storage account and container we created previously

# Storing state locally

Coming soon