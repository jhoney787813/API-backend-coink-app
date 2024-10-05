# Desarrollo C#

Este proyecto se enfoca en la creación de una API REST utilizando tecnologías como .NET, C# y SQL. El desarrollo sigue el patrón de diseño CQRS junto con MediatR. lo que facilita la implementación de un API con corte vertical. ([Codigo Fuente](https://github.com/jhoney787813/API-backend-coink-app/tree/main/src)) 

### Requerimientos a evaluar:
* Deberá crear una API de servicios que exponga un servicio para registrar los siguientes datos: Nombre, teléfono, país, departamento, municipio y dirección.
* Los servicios expuestos deberán validar que los datos ingresados como parámetros sean válidos.
* Las consultas en la base de datos deberán implementarse a través de Stored Procedures.
* Será apreciado el uso de patrones de diseño.

# Planteamiento de la solución 

### Justificación para la elección de la arquitectura:

La solución de software se desarrolló implementando el patrón CQRS junto con la arquitectura Vertical Slice, con el objetivo de garantizar atributos de negocio como la escalabilidad y la seguridad.

**Vertical Slice Architecture** es una técnica que permite crear aplicaciones mantenibles al organizar la aplicación en torno a características o "cortes verticales". Esto facilita la gestión y el desarrollo, ya que cada corte vertical representa un conjunto específico de funcionalidades.

Por otro lado, **CQRS** (Command Query Responsibility Segregation) es un patrón que separa las operaciones de lectura y actualización en un almacén de datos. Esta segregación de responsabilidades no solo mejora el rendimiento, sino que también potencia la escalabilidad y la seguridad de la aplicación.

Además, es crucial definir si nuestra API o backend adoptará una estrategia de diseño BFF (Backend for Frontend). Esta táctica es altamente recomendada si planeamos exponer nuestras capacidades en el futuro, especialmente para el desarrollo de aplicaciones móviles que utilizan nuestra API como integraciones de plataforma segura.

Para profundizar en estos conceptos, incluyo un recurso que elaboré en mi compañía actual, donde exploro en detalle la tecnología .NET y enfatizo la importancia de CQRS. También discuto los retos que conlleva su implementación, ya que toda arquitectura tiene sus ventajas y desventajas.

![recurso1](https://github.com/user-attachments/assets/8c7e5887-4f17-458c-a20a-0e9d2ee220b0)
![recurso2](https://github.com/user-attachments/assets/6f0875c9-53cf-4054-a26f-f59df4b18804)


# Distribución de archivos en solución de proyecto "API.Coink.App"

![image](https://github.com/user-attachments/assets/b915b741-53c1-4dbe-bd06-9258774dc20e)

# Estructura de Paquetes en la Construcción de APIs con CQRS y Vertical Slice

La distribución física de paquetes que mencionas en la construcción de APIs sigue un enfoque modular y bien organizado para favorecer la aplicación de principios SOLID, así como el patrón CQRS (Command Query Responsibility Segregation) y Vertical Slice, lo cual mejora la seguridad y la modularidad de la aplicación. A continuación, se explica cómo cada parte contribuye a estos objetivos:

## 1. Proyecto `API.Coink.App` (API) y `API.Backend.Coink.App.csproj` (controladores, endpoints y Swagger)
- Estos proyectos contienen la lógica de exposición de la API y la interfaz con el cliente. Siguiendo el patrón **MVC** (Model-View-Controller), los controladores sirven como intermediarios entre la capa de presentación (clientes) y la lógica de negocio.
- Al mantener los controladores separados de la lógica de negocio y la infraestructura, la aplicación queda más limpia y flexible. La documentación con **Swagger** proporciona visibilidad clara para los consumidores de la API.

  ![image](https://github.com/user-attachments/assets/f7015400-53f6-479b-8a5a-7e21d36a3c8c)



## 2. Proyecto de clases `Application` (comunicación entre controladores y capa de dominio)
- Aquí se encuentran las clases encargadas de la **orquestación de comandos y consultas** dentro del patrón CQRS. Esta capa traduce las solicitudes de los controladores en acciones que deben realizarse en el dominio, y maneja el flujo de la aplicación sin incluir la lógica de negocio directa.
- **CQRS** separa las operaciones de lectura y escritura en distintos modelos, permitiendo una gestión más eficiente y escalable de los datos.
- Esto favorece principios como el de **responsabilidad única** y **abierto/cerrado**, ya que cada módulo solo tiene una razón para cambiar.
- 
![image](https://github.com/user-attachments/assets/715d2d9c-7f93-430c-a947-143cc4e9473f)


## Requisito de Negocio de validar los datos de entrada

> Los servicios expuestos deberán validar que los datos ingresados como parámetros sean válidos. 

Para esto se promone que los datos de los modelos son validados sobre la capa de aplicación antes de llegar al dominio para realizar las operaciones de inserción o actualización. Esto garantiza que los datos de entrada sean los esperados antes de ejecutar las acciones sobre la base de datos.

Este enfoque asegura que se eviten errores innecesarios y que los datos ingresados sean correctos antes de afectar el sistema, preservando la integridad de la base de datos y las operaciones de negocio.


## Explicación de la Clase `CreateUserCommandHandler`

La clase `CreateUserCommandHandler` es responsable de manejar la creación de un nuevo usuario a través del comando `CreateUserCommand`. Su función principal es validar los datos antes de invocar la lógica de dominio para ejecutar la operación.

![image](https://github.com/user-attachments/assets/0ec602f8-e5e9-42f1-a855-d04dd38e61f5)
![image](https://github.com/user-attachments/assets/85dd46d6-7949-4945-b2ae-a0041ec02723)


# Resumen de la Explicación de las Validaciones

## Proceso de Validación
La función `ModelIsValid` se encarga de validar las propiedades del comando `CreateUserCommand` antes de procesar los datos. Las validaciones aplicadas son:

Todas estas validaciones se hacen tieniendo en cuenta el modelo de base de daos previamente creado para dar consistencia a los datos: respentando tipos de datos y longitud de los campos.

- **FullName**:
  - **Regla**: No puede estar vacío y no debe exceder los 100 caracteres.
  - **Justificación**: Se requiere para identificar al usuario y garantizar consistencia en la base de datos.

- **Identification**:
  - **Regla**: No puede estar vacío y no debe exceder los 12 caracteres.
  - **Justificación**: Es esencial para identificar al usuario con un tamaño manejable.

- **Phone**:
  - **Regla**: Si se proporciona, no debe exceder los 15 caracteres.
  - **Justificación**: Limitar su longitud evita errores, ya que los números telefónicos internacionales no suelen exceder 15 caracteres.

- **Address**:
  - **Regla**: Si se proporciona, no debe exceder los 255 caracteres.
  - **Justificación**: Mantener la dirección manejable y evitar problemas de rendimiento.

- **CityId**:
  - **Regla**: Debe ser un número mayor a 0.
  - **Justificación**: Representa una ciudad válida; un valor no positivo indica una ciudad no válida.

# Propuesta Alterna de Implementación para Validación de `CityId`

si queremos garantizar que el `CityId` solo sea válido si existe en la base de datos, se propone realizar una consulta adicional en la capa de aplicación. Esta validación no esta contenida en el ódigo actual pero se podria consirar.

## Implementación Propuesta

### 1. Inyección de Dependencia para la Verificación de Ciudades

Se necesitará una interfaz que permita verificar si una ciudad existe en la base de datos. liegoimplementar el repositiorio que ira a la tabla City y cargara en memoria cache todas la ciudades que estan almacenadas.

#### Interfaz `ICityRepository`

```csharp
public interface ICityRepository
{
    Task<bool> CityExistsAsync(int cityId);
}
```

La propuesta busca desarrollar un repositorio que valide la existencia de ciudades en la base de datos, utilizando caché para optimizar el rendimiento. E
La utilización de `IMemoryCache` mejora significativamente el rendimiento al evitar consultas repetitivas y optimizar la experiencia del usuario al reducir los tiempos de respuesta.

## Recomendaciones para Utilizar Caché

1. **Implementación de Caché**: Utilizar `IMemoryCache` de Microsoft es una opción efectiva para almacenar los resultados de las consultas, lo que previene la sobrecarga en la base de datos por consultas repetitivas.

2. **Gestión de Expiración**: Definir un tiempo de expiración para la caché asegura que los datos no se vuelvan obsoletos, manteniendo la integridad y precisión de la información. (Refresco de la data)

## 3. Proyecto de clases `Domain` (definiciones e implementaciones de reglas de negocio)
- Aquí es donde se define la lógica de negocio principal, separada de los detalles de implementación. Esto incluye **interfaces** que definen contratos de comportamiento y reglas de negocio independientes de cómo se implementan.
- **Vertical Slice** es clave aquí, ya que segmenta la lógica por funcionalidad (cada "slice" es una característica completa) para nuestro caso se segmenta por "casos de uso" ys que nuestro desarrollo se orienta al dominio del negocio, lo que facilita que cada parte de la aplicación crezca de manera autónoma, permitiendo iteraciones ágiles y un código más fácil de mantener.
- Este enfoque modular ayuda a reducir el acoplamiento y promueve **polimorfismo** y **inversión de dependencias**, dos principios de SOLID.
- 
![image](https://github.com/user-attachments/assets/68047791-4aac-4164-ada9-0e027a37d21d)

## 4. Proyecto de clases `Infrastructure` (implementación de repositorios)
- Esta capa se encarga de la persistencia de datos y la comunicación con otros servicios externos (como bases de datos o APIs externas). La **implementación de repositorios** está alineada con las interfaces definidas en el dominio.
- **Inversión de dependencias** (uno de los principios de SOLID) se aplica aquí porque la capa de aplicación y dominio dependen de **abstracciones** y no de implementaciones concretas. Esto permite cambiar la infraestructura (como el tipo de base de datos) sin afectar el dominio o la lógica de negocio.
  
![image](https://github.com/user-attachments/assets/837f737e-ba64-4827-a932-bda49e327f5e)

## 5. Documentación de endpoint con  `swagger` (contratros y respuestas)

Para nuestro caso, un "endpoint" es igual a un "controller" de API, pero por terminología lo denominamos "endpoint", ya que son los puntos de entrada a nuestros recursos. A través de ellos, exponemos y permitimos la interacción sobre el contexto de administración de clientes. Un "endpoint" es la URL específica donde los clientes acceden o manipulan recursos, mientras que el "controller" organiza la lógica que maneja esas solicitudes. El término "endpoint" refleja mejor el acceso público a los recursos, a diferencia del "controller", que es parte de la implementación interna del servidor.

![image](https://github.com/user-attachments/assets/dc297055-dc82-4d0e-adaf-debe90d490d9)

# API Specification: API.Backend.Coink.App

## Información

- **Versión de OpenAPI:** 3.0.1
- **Título:** API.Backend.Coink.App
- **Versión:** 1.0

## Rutas
### Eliminar un Usuario
#### `DELETE /api/v{version}/user/{identification}`
- **Tags:** Users
- **Parámetros:**
  - `identification` (ruta) - Identificación del usuario a eliminar (requerido).
  - `version` (ruta) - Versión de la API (requerido).
- **Respuestas:**
  - `200 OK` - Usuario eliminado correctamente.
  - `400 Bad Request` - Solicitud incorrecta.
  - `401 Unauthorized` - No autorizado.
  - `406 Not Acceptable` - No aceptable.
  - `409 Conflict` - Conflicto.
  - `500 Internal Server Error` - Error interno del servidor.

### Obtener un Usuario por ID

#### `GET /api/v{version}/user/{identification}`

- **Tags:** Users
- **Parámetros:**
  - `identification` (ruta) - Identificación del usuario (requerido).
  - `version` (ruta) - Versión de la API (requerido).
- **Respuestas:**
  - `200 OK` - Usuario encontrado.
  - `400 Bad Request` - Solicitud incorrecta.
  - `401 Unauthorized` - No autorizado.
  - `406 Not Acceptable` - No aceptable.
  - `409 Conflict` - Conflicto.
  - `500 Internal Server Error` - Error interno del servidor.

### Crear un Usuario

#### `POST /api/v{version}/user`

- **Tags:** Users
- **Parámetros:**
  - `version` (ruta) - Versión de la API (requerido).
- **Cuerpo de la Solicitud:**
  - **Contenido:**
    - `application/json` - Comando para crear un usuario.
    - `text/json` - Comando para crear un usuario.
    - `application/*+json` - Comando para crear un usuario.
- **Respuestas:**
  - `201 Created` - Usuario creado exitosamente.
  - `400 Bad Request` - Solicitud incorrecta.
  - `401 Unauthorized` - No autorizado.
  - `406 Not Acceptable` - No aceptable.
  - `409 Conflict` - Conflicto.
  - `500 Internal Server Error` - Error interno del servidor.

## Componentes

### Esquemas

- **CreateUserCommand**
  - **Propiedades:**
    - `identification`: string (opcional)
    - `fullName`: string (opcional)
    - `phone`: string (opcional)
    - `address`: string (opcional)
    - `cityId`: integer (formato: int32)

- **CreateUserCommandResponse**
  - **Propiedades:**
    - `identification`: string (opcional)
    - `fullName`: string (opcional)
    - `phone`: string (opcional)
    - `address`: string (opcional)
    - `cityId`: integer (formato: int32)

- **DeleteUserCommand**
  - **Propiedades:**
    - `identification`: string (opcional)

- **GetAllUsersQueryResponse**
  - **Propiedades:**
    - `identification`: string (opcional)
    - `fullName`: string (opcional)
    - `phone`: string (opcional)
    - `address`: string (opcional)
    - `cityId`: integer (formato: int32)
    - `cityName`: string (opcional)

- **GetUserByIdQueryResponse**
  - **Propiedades:**
    - `identification`: string (opcional)
    - `fullName`: string (opcional)
    - `phone`: string (opcional)
    - `address`: string (opcional)
    - `cityId`: integer (formato: int32)
    - `cityName`: string (opcional)

- **ProblemDetails**
  - **Propiedades:**
    - `type`: string (opcional)
    - `title`: string (opcional)
    - `status`: integer (formato: int32, opcional)
    - `detail`: string (opcional)
    - `instance`: string (opcional)




## Algo a destacar

Este diseño asegura que cada módulo sea independiente, fácil de probar y de modificar. El uso de **CQRS** permite que los comandos y consultas se manejen de manera eficiente, lo que mejora la escalabilidad. Además, el enfoque de **Vertical Slice** garantiza que cada funcionalidad sea tratada como una unidad completa, facilitando el mantenimiento y la evolución del sistema. La aplicación de principios **SOLID** favorece un código más limpio, reutilizable y adaptable.

([Codigo Fuente](https://github.com/jhoney787813/API-backend-coink-app/tree/main/src)) 


