CREATE OR REPLACE PROCEDURE spUpdateUserData(
    p_card_id VARCHAR(12),
    p_name VARCHAR(100),
    p_phone VARCHAR(15),
    p_address VARCHAR(255),
    p_city_id INT
)
LANGUAGE plpgsql AS $$
BEGIN
    BEGIN
        UPDATE UserData
        SET name = p_name,
            phone = p_phone,
            address = p_address,
            city_id = p_city_id
        WHERE card_id = p_card_id;

        RAISE NOTICE 'User with card_id: % updated successfully.', p_card_id;

    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Error updating user with card_id: %', p_card_id;
    END;
END;
$$;
