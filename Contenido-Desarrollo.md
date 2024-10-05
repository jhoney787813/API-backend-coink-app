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

## Algo a destacar

Este diseño asegura que cada módulo sea independiente, fácil de probar y de modificar. El uso de **CQRS** permite que los comandos y consultas se manejen de manera eficiente, lo que mejora la escalabilidad. Además, el enfoque de **Vertical Slice** garantiza que cada funcionalidad sea tratada como una unidad completa, facilitando el mantenimiento y la evolución del sistema. La aplicación de principios **SOLID** favorece un código más limpio, reutilizable y adaptable.

([Codigo Fuente](https://github.com/jhoney787813/API-backend-coink-app/tree/main/src)) 


