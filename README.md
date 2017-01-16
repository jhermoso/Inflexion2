# Inflexion2 

Inflexion is an spanish word that means inflection, but both words has the same pronunciation and the same meanig in both languages.The number "2" is not a version is only prefix to help to indicate where to change the direction, of your goals.

This framework is under construction, forever ... and is trying to folow the best practices of Domain Driven Design. The objective of this framework is to help to write applications, complex applications or simple applications. Dividing the complex applications in different modules or groupping many simple applications under only one umbrella in any big coorporation converting the simple applications in modules of one unique system.

This framework is designed to chose wich technologies to use for one application, becouse the only important thing is to keep simple the bussines logic of any system.

Also this framework, is constructed in a very systematic point of view, becouse in the future, would be useful to use code generation to get the applications.

## Quick start guide

This project includes a DDD framework and a simple example of implementation of one bounded context.
The framework is a set of technical base classes to help the implementation of the business bounded context. 
The best strategy to use this framework is construct at least one shared bounded context with the business framework for the client.
the rest of modules or bounded contexts should inheritance from this shared or "kernel" bounded context.

the framework is constructed following the DDD principals and the code of every layer is organized in the visual studio solution in one folder per layer
. The folder structure is the same for the framework and for all the bounded context.

    01. FrontEnd 
    02. Application
    03. Domain
    04. Infrastructure
    05. Testing

At root level, there is a folder for the framework with this structure. In the front end folder currently is implemented only the 
bases classes for WPF, but this framework is possible to be used with any kind of front end due to the application layer.

In the example there is a second folder with the name of "Model" and every bounded context should have a folder with the same structure of layers
. In the example, the only bounded context implemented is "Shared"

The current framework has a WPF application based on PRISM with MVVM pattern and Unity like IoC. 
this part of the framework has his own bootstrap and reads dynamically the different modules, where every bounded context is a module.
this means that the framework provides the .exe but this application is empty and all the functionality should be implemented only in the bounded contexts.

The structure of every bounded context is always the same and is very systematic in every layer. Where the inheritance relationship 
with the layers of the framework is parallel.
For every layer there is a common structure of projects and every project has always the same class organization. This means that 
for every business class there are 20 classes distributed through the different projects of every layer.
the naming of every project follows this rule:

    [Company].[Product].[BoundedContext].[Layer].[Assembly]

