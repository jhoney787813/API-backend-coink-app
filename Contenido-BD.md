![image](https://github.com/user-attachments/assets/d2a6df9f-5dae-44c1-8eaf-abcf23d0209e)

# Requerimientos a evaluar:

* Construir un esquema de base de datos que permita registrar el nombre, teléfono y dirección de un usuario. 
* Construir tablas paramétricas para país, departamento y municipio. 
* Usar bases de datos relacionales. 
* Las consultas en base de datos deberán implementarse a través de consumo de Stored Procedures. 

## Planteamiento de la solución 

Se utiliza el servicio en la nube de Supabase  para alojar nuesta bd PostgreSQL ya que ofrece las siguientes posibilidades:

- Crear y administrar tus tablas, índices, y relaciones.
- Ejecutar consultas SQL directamente desde el panel de Supabase.
- Hacer uso de funciones avanzadas de PostgreSQL como triggers, views y stored procedures.

# Justificación de la Estructura de la Base de Datos

La estructura de la base de datos propuesta se basa en los requerimientos iniciales de crear un sistema para registrar datos de usuarios, incluyendo su país, estado y ciudad, mediante un diseño de base de datos relacional.

Se crea una base de datos llamada `UserDB`.El modeloasegura la integridad de los datos y previene duplicados.

**Sección Definiciones (DDL)**

Por defecto nuestra BD de llama "postgres"

## Tablas

### 1. Tabla `Country`

```sql
CREATE TABLE Country (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);
```

#### Justificación
- **Requisito**: Crear una tabla para registrar países.
- **Campos**:
  - `id SERIAL PRIMARY KEY`: Identificador único de cada país.
  - `name VARCHAR(100) NOT NULL`: Nombre del país, obligatorio para asegurar que no haya países sin nombre.
  - `prefix VARCHAR(10) NOT NULL UNIQUE`: Prefijo único del país, garantizando que no haya duplicados.
  - `created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP`: Fecha y hora de creación automática, útil para auditoría.

### 2. Tabla `State`

```sql
CREATE TABLE State (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE, 
    country_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES Country(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);
```

#### Justificación
- **Requisito**: Crear una tabla para registrar estados o departamentos, asociados a un país.
- **Campos**:
  - `id SERIAL PRIMARY KEY`: Identificador único del estado.
  - `name VARCHAR(100) NOT NULL`: Nombre del estado, requerido para asegurar la existencia de un nombre asociado.
  - `prefix VARCHAR(10) NOT NULL UNIQUE`: Prefijo único para identificar el estado.
  - `country_id INT NOT NULL`: Llave foránea que se relaciona con el país en la tabla `Country`.
  - `created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP`: Marca temporal para la creación del registro.

### 3. Tabla `City`

```sql
CREATE TABLE City (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    prefix VARCHAR(10) NOT NULL UNIQUE,  
    state_id INT NOT NULL,
    FOREIGN KEY (state_id) REFERENCES State(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);
```

#### Justificación
- **Requisito**: Crear una tabla para registrar ciudades, asociadas a un estado o departamento.
- **Campos**:
  - `id SERIAL PRIMARY KEY`: Identificador único para la ciudad.
  - `name VARCHAR(100) NOT NULL`: Nombre de la ciudad, asegurando que cada ciudad tenga un nombre válido.
  - `prefix VARCHAR(10) NOT NULL UNIQUE`: Prefijo único de la ciudad.
  - `state_id INT NOT NULL`: Llave foránea que referencia la tabla `State`.
  - `created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP`: Marca temporal de creación.

### 4. Tabla `UserData`

```sql
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
```

#### Justificación
- **Requisito**: Registrar información de los usuarios, asociando su dirección a una ciudad.
- **Campos**:
  - `id SERIAL PRIMARY KEY`: Identificador único para el registro del usuario.
  - `card_id VARCHAR(12) UNIQUE`: Campo único para almacenar el número de cédula del usuario.
  - `name VARCHAR(100) NOT NULL`: Nombre del usuario, obligatorio.
  - `phone VARCHAR(15)`: Número de teléfono del usuario.
  - `address VARCHAR(255)`: Dirección física del usuario.
  - `city_id INT`: Llave foránea que referencia la ciudad donde reside el usuario.
  - `created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP`: Fecha de creación del registro.

## Cumplimiento de Principios ACID en el Modelo Propuesto

El diseño de la base de datos cumple con todos los requerimientos iniciales mediante un enfoque relacional. La integridad referencial se garantiza a través de llaves foráneas entre `UserData`, `City`, `State` y `Country`. Además, la inclusión de campos `UNIQUE` y la creación automática de marcas temporales (`created_at`) asegura que los datos sean únicos y rastreables. Esta estructura ofrece flexibilidad para agregar más países, estados y ciudades sin afectar la funcionalidad del sistema.

Con el dieseño de este modelo estamos garantizando **Atomicidad**, **Consistencia** y **Durabilidad** en las transacciones. Sin embargo, para lograr una implementación completamente ACID, el desarrollo de la API debe incorporar consideraciones sobre **Aislamiento** o manejo de transacciones cuando hagamos una consulta, inserción o actualización para que aseguremos la integridad de los datos.

**Sección Manipulacion (DML)**

## Justificación: Stored Procedures y Stored Functions en PostgreSQL

### Diferencia Clave
Los **Stored Procedures** son para modificaciones en la base de datos, mientras que las **Stored Functions** son para devolver resultados de consultas. Esto asegura una clara separación de responsabilidades en la lógica de base de datos.

## Implementación de Funciones en PostgreSQL


### Explicación de la Función `GetUserByCardId`

En nuestro caso, hemos creado una **Stored Function** para devolver los datos del usuario consultando por el número de cédula. Esta función permite recuperar información específica por el número de cédula del usuario registrado.

### Estructura de la Función
```sql
CREATE OR REPLACE FUNCTION fnGetUserByCardId(
    p_card_id VARCHAR(12)
)
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
    JOIN City c ON u.city_id = c.id
    WHERE u.card_id = p_card_id;
END;
$$ LANGUAGE plpgsql;

```
### Llamada a la Función
La función se invoca de la siguiente manera:
```sql
SELECT * FROM fnGetUserByCardId('123');
```
### Explicación de la Función `GetUserByCardId`

En nuestro caso, hemos creado una **Stored Function** para devolver todos los usuarios registrados sin filtros.
### Estructura de la Función

```sql
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
```
### Llamada a la Función
La función se invoca de la siguiente manera:
```sql
SELECT * FROM fnGetUsersData();
```

## Procedimiento con Manejo de Transacciones en PostgreSQL

Este procedimiento `InsertUserData` inserta datos en la tabla `UserData` y utiliza transacciones para asegurar que los cambios se confirmen (**commit**) o se deshagan (**rollback**) en caso de error.

**NOTA:** El Manejo implícito de transacciones: PostgreSQL ya controla las transacciones automáticamente, por lo que no es necesario usar COMMIT o ROLLBACK en el procedimiento.
## Procedimientos Almacenados para la Tabla UserData
### Estructura del Procedure

```sql
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
           --ROLLBACK;
            RAISE EXCEPTION 'Error inserting user with card_id: %. Transaction rolled back.', p_card_id;
    END;
END;
$$;
```
### Llamada al procedure
El procedure se invoca de la siguiente manera:
```sql
CALL spInsertUserData('123456789012', 'John Doe', '1234567890', '123 Main St', 1);
```



## DeleteUserByCardId - Eliminar Usuario por Número de Cédula

### Descripción:
Este procedimiento almacenado elimina un usuario de la tabla `UserData` basado en el número de cédula proporcionado (`card_id`).

### Parámetros:
- `p_card_id`: El número de cédula único del usuario que se desea eliminar (`VARCHAR(12)`).

### SQL:
```sql
CREATE OR REPLACE PROCEDURE spDeleteUserByCardId(
    p_card_id VARCHAR(12)
)
LANGUAGE plpgsql AS $$
BEGIN
    BEGIN
        DELETE FROM UserData
        WHERE card_id = p_card_id;
        RAISE NOTICE 'Usuario con card_id: % eliminado correctamente.', p_card_id;
    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Error al eliminar el usuario con card_id: %', p_card_id;
    END;
END;
$$;

```
### Llamada al procedure
El procedure se invoca de la siguiente manera:
```sql
CALL spDeleteUserByCardId('123456789012');
```

## UpdateUserData - Actualizar Información del Usuario por Número de Cédula

### Descripción:
El procedimiento almacenado `UpdateUserData` permite actualizar la información de un usuario en la tabla `UserData` utilizando el número de cédula (`card_id`) como clave única. Los datos que se pueden actualizar incluyen el nombre del usuario, el número de teléfono, la dirección y la ciudad donde reside.

### Parámetros:
- **`p_card_id`** (`VARCHAR(12)`): El número de cédula único del usuario que se desea actualizar.
- **`p_name`** (`VARCHAR(100)`): El nuevo nombre del usuario.
- **`p_phone`** (`VARCHAR(15)`): El nuevo número de teléfono del usuario.
- **`p_address`** (`VARCHAR(255)`): La nueva dirección del usuario.
- **`p_city_id`** (`INT`): El ID de la ciudad a la que pertenece el usuario, relacionado con la tabla `City`.

### SQL:
```sql
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
            city_id = p_city_id,
        WHERE card_id = p_card_id;
        RAISE NOTICE 'Usuario con card_id: % actualizado correctamente.', p_card_id;
    EXCEPTION
        WHEN OTHERS THEN
            RAISE EXCEPTION 'Error al actualizar el usuario con card_id: %', p_card_id;
    END;
END;
$$;
```
### Llamada al procedure
El procedure se invoca de la siguiente manera:
```sql
    CALL spUpdateUserData('123456789012', 'Jane Doe', '9876543210', '456 Calle Nueva', 2);
```
