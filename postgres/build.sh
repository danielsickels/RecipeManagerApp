#!/bin/bash

docker build -t recipedb .

docker run -d --name postgres-instance -p 5432:5432 -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=recipeapp -v postgres-data:/var/lib/postgresql/data recipedb