-- SQL sentence to delete the table
DROP TABLE IF EXISTS users;

-- SQL sentence to delete the database
DROP DATABASE IF EXISTS "FONAP_game";

-- SQL sentence to create the DATABASE:
CREATE DATABASE "FONAP_game"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Spain.1252'
    LC_CTYPE = 'Spanish_Spain.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- SQL sentence to create the tables
CREATE TABLE users(
	id SERIAL PRIMARY KEY NOT NULL,
	name TEXT NOT NULL,
	age INTEGER NOT NULL,
	community TEXT,
	is_affiliate BOOLEAN,
	score INTEGER DEFAULT 0);

CREATE TABLE questions(
	id SERIAL PRIMARY KEY NOT NULL,
    user_id INTEGER NOT NULL,
	question TEXT NOT NULL,
    CONSTRAINT fk_user FOREIGN KEY(user_id) REFERENCES users(id));
