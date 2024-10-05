CREATE OR REPLACE FUNCTION fnGetUsersData()
RETURNS TABLE(
    card_id VARCHAR(12),
    name VARCHAR(100),
    phone VARCHAR(15),
    address VARCHAR(255),
    city_id INT,
    city_name VARCHAR(100)
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        u.card_id,
        u.name,
        u.phone,
        u.address,
        u.city_id,
        c.name AS city_name
    FROM UserData u
    JOIN City c ON u.city_id = c.id;

END;
$$ LANGUAGE plpgsql;
