# Desarrollo C#

Este proyecto se enfoca en la creación de una API REST utilizando tecnologías como .NET, C# y SQL. El desarrollo sigue el patrón de diseño CQRS junto con MediatR. lo que facilita la implementación de un API con corte vertical.

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
