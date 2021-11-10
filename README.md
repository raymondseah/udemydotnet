create solution file in Project directory
the command will create a solution with same name as your current directory

`dotnet new sln`

next create you webapi folder. for my example using API as folder name◊◊◊◊

`dotnet new webapi -o API`

add created API project file into solution file

`dotnet sln add API/`

to see added projects

`dotnet sln list`

add packages. see .csproj file 

`dotnet new package <packages>`
`Microsoft.EntityFrameworkCore.Design`
`Microsoft.EntityFrameworkCore.Sqlite`

check version and list global tools

`dotnet --version`
`dotnet tool list -g`

install migrations tool
`dotnet tool install --global dotnet-ef`            

after creating the connection string, data models/entities and context for the db.
Can start to migrate, the following will generate migration cycle called InitialCreate into Data/Migrations folder

`dotnet ef migrations add InitialCreate -o Data/Migrations`

apply the migrations files into DB. for this development example. the .db file is create in the API folder

`dotnet ef database update`

use this command, work similar to nodemon for auto restarting of build

`dotnet watch run`

///////////////////////////////////////

Stop Build go up a folder and create two addition projects, this time we will create 2 classlib

`dotnet new classlib -o Core`
`dotnet new classlib -o Infrastructure`

Add this two folder into the sln file via this command

`dotnet sln add Core`
`dotnet sln add Infrastructure`

go into API folder and add reference to the create Intrastructure Folder

`cd API`
`dotnet add reference ../Infrastructure`

cd into the Infrastructure and do the same reference to Core

`dotnet add reference ../Core`

cd .. run restore

`dotnet restore`

move the Entities to Core and Data to Infrastructure
Update the name spaces and the csproj for the database package

for extra house keeping. vscode preferences -> settings -> search exclude `**/bin` and `**/obj` (if you want)

in root folder .gitingore some folder, bin and obj in this case
