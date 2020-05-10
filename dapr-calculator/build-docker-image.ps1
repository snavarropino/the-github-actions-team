Param(
    [parameter(Mandatory=$true)][string]$App,
    [parameter(Mandatory=$true)][string]$Tag,
    [parameter(Mandatory=$true)][bool]$PublishToDockerHub=$false
)


function Build ($app, $folder, $tag)
{    
    & docker build -t snavarropino/${app}:${tag} ./$folder  
    
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }

    & docker tag snavarropino/${app}:${tag} snavarropino/${app}:latest    
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

function Publish($app, $tag)
{   
    & docker push snavarropino/${app}:${tag}
    
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }

    & docker push snavarropino/${app}:latest
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

echo "Building docker image $App with tag: $Tag"

switch ($App) {
    "distributed-calculator-go" {$folder="go"; Build $App $folder $Tag; break; }
    "distributed-calculator-node" {$folder="node"; Build $App $folder $Tag; break; }
    "distributed-calculator-python" {$folder="python"; Build $App $folder $Tag; break; }
    "distributed-calculator-csharp" {$folder="csharp"; Build $App $folder $Tag; break; }
    "distributed-calculator-react-calculator" {$folder="react-calculator"; Build $App $folder $Tag; break; }
    default {throw ("Invalid app" + $App)}

}

if($PublishToDockerHub){
    echo "Publish to Docker Hub:"
    Publish $App $Tag
}
