-- Create users table
CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Create recipes table
CREATE TABLE recipes (
    recipe_id SERIAL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    instructions TEXT NOT NULL,
    ingredients TEXT NOT NULL,
    nutrition_info JSONB,
    user_id INTEGER REFERENCES users(user_id)
);

-- Insert a sample user
INSERT INTO users (username, password) VALUES ('test', 'test');