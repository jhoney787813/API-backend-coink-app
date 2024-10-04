
# Desarrollo C#. 
 
* Deberá crear un Api de servicios que deberá exponer: Servicio que permita registrar Nombre, teléfono, País, Departamento, municipio y Dirección. 
* Los servicios expuestos deberán validar que el dato que se ingrese como parámetro sea 
válido.

* Las consultas en base de datos deberán implementarse a través de consumo de Stored Procedures. 

* Será apreciado el uso de patrones de diseño. 



### Justificación para la elección de la arquitectura:

La solución de software se desarrolló implementando el patrón CQRS junto con la arquitectura Vertical Slice, con el objetivo de garantizar atributos de negocio como la escalabilidad y la seguridad.

**Vertical Slice Architecture** es una técnica que permite crear aplicaciones mantenibles al organizar la aplicación en torno a características o "cortes verticales". Esto facilita la gestión y el desarrollo, ya que cada corte vertical representa un conjunto específico de funcionalidades.

Por otro lado, **CQRS** (Command Query Responsibility Segregation) es un patrón que separa las operaciones de lectura y actualización en un almacén de datos. Esta segregación de responsabilidades no solo mejora el rendimiento, sino que también potencia la escalabilidad y la seguridad de la aplicación.

Además, es crucial definir si nuestra API o backend adoptará una estrategia de diseño BFF (Backend for Frontend). Esta táctica es altamente recomendada si planeamos exponer nuestras capacidades en el futuro, especialmente para el desarrollo de aplicaciones móviles que utilizan nuestra API como integraciones de plataforma segura. 

Para profundizar en estos conceptos, incluyo un recurso que elaboré en mi compañía actual, donde exploro en detalle la tecnología .NET y enfatizo la importancia de CQRS.

voy a dejar un recurso elaborado por mi donde incursiono en tecnologia .NET y enfatizo en la importancia de CQRS

![recurso1](https://github.com/user-attachments/assets/8c7e5887-4f17-458c-a20a-0e9d2ee220b0)

![recurso2](https://github.com/user-attachments/assets/6f0875c9-53cf-4054-a26f-f59df4b18804)



