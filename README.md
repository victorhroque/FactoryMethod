[![Build Status](https://github.com/victorhroque/FactoryMethod/actions/workflows/dotnet.yml/badge.svg)](https://github.com/victorhroque/FactoryMethod/actions)

# Resolución de Documentos con Clean Architecture, CQRS y Factory Method (.NET 8)

Este repositorio contiene un ejemplo de implementación de la creación de documentos (resoluciones) utilizando los principios de Clean Architecture, el patrón CQRS (Command Query Responsibility Segregation) y el patrón Factory Method en .NET 8.
[.gitignore](.gitignore)
## Descripción

El proyecto simula la creación de dos tipos de resoluciones:

*   **Resolución de Designación de Jurado:** Documento que designa a los miembros de un jurado.

En lugar de generar PDFs reales (para simplificar el ejemplo), la creación del documento se simula con un mensaje en la consola y la generación de un GUID único.

## Arquitectura

El proyecto sigue los principios de Clean Architecture, separando las responsabilidades en diferentes capas:

*   **Resolution.Api:** Proyecto Web API que actúa como punto de entrada de la aplicación. Contiene los controladores y la configuración de la inyección de dependencias.
*   **Resolution.Application:** Proyecto que contiene la lógica de negocio, incluyendo los comandos (Commands), los manejadores de comandos (Handlers) y las interfaces de las fábricas.
*   **Resolution.Domain:** Proyecto que define las entidades del dominio, en este caso, la interfaz `IDocument`.
*   **Resolution.Infrastructure:** Proyecto que contiene las implementaciones concretas de las fábricas y los tipos de documentos.

Se utiliza el patrón CQRS para separar las operaciones de escritura (Commands) de las de lectura (que no se implementan en este ejemplo, pero se podrían agregar fácilmente). El patrón Factory Method se utiliza para desacoplar la creación de los diferentes tipos de documentos.

## Tecnologías

*   .NET 8
*   C#
*   Clean Architecture
*   CQRS (con MediatR)
*   Factory Method
*   xUnit (para pruebas unitarias)
*   Moq (para *mocking*)
*   ASP.NET Core Web API
