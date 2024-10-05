CREATE TABLE Country (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);

CREATE TABLE State (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE, 
    country_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES Country(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);

CREATE TABLE City (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE,  
    state_id INT NOT NULL,
    FOREIGN KEY (state_id) REFERENCES State(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);


CREATE TABLE UserData (
    id SERIAL PRIMARY KEY,
    card_id  VARCHAR(12) UNIQUE,
    name VARCHAR(100) NOT NULL,
    phone VARCHAR(15),             
    address VARCHAR(255),          
    city_id INT,                   
    FOREIGN KEY (city_id) REFERENCES City(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);

