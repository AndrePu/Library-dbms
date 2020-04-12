# Project setup

## Database
In pgAdmin create database where you should run scripts from **Documentation/db-scripts** folder in following order:
1) Run create script;
2) Run all update scripts;
3) Run all insert scripts.
Extra: for ensuring of right configuration run select script.

## Server
0) Predefinetely you should install .NET Core SDK and other required resources.
1) In **Server** folder run command: _dotnet run_

## Client
0) Predefinetely you should install nodeJS, angular CLI and other requires resources.
1) In **ClientApp** folder run command: _npm install_
2) In the same place run: _ng serve_



