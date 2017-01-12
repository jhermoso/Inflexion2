
# Inflexion2 



# nhibernate, entity framework, WCF, WPF. Prism, AvalonDock, MahApps.
This project includes a DDD framework and a simple example of implementation of bounded context.
The framework is a set of technical base clases to help the implementation of the bussines bounded context. 
the best strategy to use this framework is construct at least one shared bounded context with the business framework for the client.
the rest of modules or bounded contexts should inheritance from this shared or kernel bounded context.

the framework is constructed following the DDD principals and the code of every layer is grouped phisically in one folder per layer.
the folder structure is the same for the framework and for all the bounded context.
