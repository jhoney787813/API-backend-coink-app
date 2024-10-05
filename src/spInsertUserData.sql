CREATE OR REPLACE PROCEDURE spInsertUserData(
    p_card_id VARCHAR(12),
    p_name VARCHAR(100),
    p_phone VARCHAR(15),
    p_address VARCHAR(255),
    p_city_id INT
)
LANGUAGE plpgsql AS $$
BEGIN

    BEGIN

        INSERT INTO UserData(card_id, name, phone, address, city_id, created_at)
        VALUES (p_card_id, p_name, p_phone, p_address, p_city_id, CURRENT_TIMESTAMP);
        --COMMIT;
        RAISE NOTICE 'User with card_id: % inserted successfully.', p_card_id;
    EXCEPTION
        WHEN OTHERS THEN
           -- ROLLBACK;

            RAISE EXCEPTION 'Error inserting user with card_id: %', p_card_id;
    END;
END;
$$;