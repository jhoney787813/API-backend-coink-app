CREATE OR REPLACE PROCEDURE spDeleteUserByCardId(
    p_card_id VARCHAR(12)
)
LANGUAGE plpgsql AS $$
BEGIN
    BEGIN
        DELETE FROM UserData
        WHERE card_id = p_card_id;
        RAISE NOTICE 'User with card_id: % deleted successfully.', p_card_id;
    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Error deleting user with card_id: %', p_card_id;
    END;
END;
$$;
