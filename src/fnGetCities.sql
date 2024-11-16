CREATE OR REPLACE FUNCTION fnGetAllCities()
RETURNS TABLE (
    id INT,
    name VARCHAR(100),
    Prefix VARCHAR(10),
    state_id INT,
    created_at TIMESTAMP
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        c.id ,
        c.name,
        c.prefix,
        c.state_id,
        c.created_at
    FROM City c;
END;
$$ LANGUAGE plpgsql;