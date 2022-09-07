# prova-prosoft

Rodando local

docker pull mongo
docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=12346MaterSenha mongo

docker pull mcr.microsoft.com/mssql/server
docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Master@#!#10" -p 1433:1433 -d mcr.microsoft.com/mssql/server

Executar o script para criação da base de dados do sql serve que está pasta script
