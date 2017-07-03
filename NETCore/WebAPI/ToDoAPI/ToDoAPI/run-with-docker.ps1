$projectName="todoapi"
$framework = "netcoreapp1.1"
$Environment = "debug"
$pubFolder = "bin\$Environment\$framework\publish"

Write-Host "#0 Remove old docker image" -ForegroundColor "Yellow" -BackgroundColor "Black"

docker rmi $projectName -f
docker rm "${projectName}_run" -f

Write-Host "#1 Create the docker image" -ForegroundColor "Yellow" -BackgroundColor "Black"

dotnet restore
dotnet publish -f $framework -c $Environment -o $pubFolder
docker build -f ".\${pubFolder}\Dockerfile.mine" -t $projectName ".\${pubFolder}"

Write-Host "#2 Running the Docker image" -ForegroundColor "Yellow" -BackgroundColor "Black"

docker run --name "${projectName}_run" -d -p 5000docker:80 -t $projectName

Write-Host "All done." -ForegroundColor "Green" -BackgroundColor "Black"