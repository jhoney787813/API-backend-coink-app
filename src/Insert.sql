INSERT INTO Country (name, prefix)
VALUES
('United States', 'US'),
('Canada', 'CA'),
('Mexico', 'MX'),
('Colombia', 'CO');

INSERT INTO State (name, prefix, country_id)
VALUES
('California', 'CA', (SELECT id FROM Country WHERE prefix = 'US')),
('Texas', 'TX', (SELECT id FROM Country WHERE prefix = 'US')),
('Ontario', 'ON', (SELECT id FROM Country WHERE prefix = 'CA')),
('Quebec', 'QC', (SELECT id FROM Country WHERE prefix = 'CA')),
('Nuevo León', 'NL', (SELECT id FROM Country WHERE prefix = 'MX')),
('Jalisco', 'JA', (SELECT id FROM Country WHERE prefix = 'MX')),
('Bogotá', 'BO', (SELECT id FROM Country WHERE prefix = 'CO')),
('Antioquia', 'ANT', (SELECT id FROM Country WHERE prefix = 'CO'));


INSERT INTO City (name, prefix, state_id)
VALUES
('Los Angeles', 'LA', (SELECT id FROM State WHERE prefix = 'CA')),
('San Francisco', 'SF', (SELECT id FROM State WHERE prefix = 'CA')),
('Houston', 'HT', (SELECT id FROM State WHERE prefix = 'TX')),
('Dallas', 'DL', (SELECT id FROM State WHERE prefix = 'ON')),
('Toronto', 'TO', (SELECT id FROM State WHERE prefix = 'ON')),
('Montreal', 'MT', (SELECT id FROM State WHERE prefix = 'QC')),
('Monterrey', 'MTY', (SELECT id FROM State WHERE prefix = 'NL')),
('Guadalajara', 'GDL', (SELECT id FROM State WHERE prefix = 'JA')),
('Bogotá D.C.', 'BOG', (SELECT id FROM State WHERE prefix = 'BO')),
('Usaquén', 'USA', (SELECT id FROM State WHERE prefix = 'BO')),
('Chapinero', 'CHP', (SELECT id FROM State WHERE prefix = 'BO')),
('Medellín', 'MED', (SELECT id FROM State WHERE prefix = 'ANT')),
('Envigado', 'ENV', (SELECT id FROM State WHERE prefix = 'ANT')),
('Bello', 'BEL', (SELECT id FROM State WHERE prefix = 'ANT'));



INSERT INTO UserData (card_id,name, phone, address, city_id)
VALUES
('123','Juan Pérez', '5551234', 'Calle 123, Bogotá',
    (SELECT id FROM City WHERE prefix = 'BOG')
),
('345','Laura Gómez', '5555678', 'Calle 456, Medellín',
    (SELECT id FROM City WHERE prefix = 'MED')
);
