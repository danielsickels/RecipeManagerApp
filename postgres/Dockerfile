FROM postgres:latest

# Set environment variables
ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=admin
ENV POSTGRES_DB=recipeapp

# Copy SQL files into the container
COPY ./migrations /docker-entrypoint-initdb.d/
