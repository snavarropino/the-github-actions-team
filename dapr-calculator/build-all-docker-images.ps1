echo "Building all docker images"

& .\build-docker-image.ps1 -App distributed-calculator-go -Tag 1 -PublishToDockerHub 1
& .\build-docker-image.ps1 -App distributed-calculator-node -Tag 1 -PublishToDockerHub 1
& .\build-docker-image.ps1 -App distributed-calculator-python -Tag 1 -PublishToDockerHub 1
& .\build-docker-image.ps1 -App distributed-calculator-csharp -Tag 1 -PublishToDockerHub 1
& .\build-docker-image.ps1 -App distributed-calculator-react-calculator -Tag 1 -PublishToDockerHub 1
