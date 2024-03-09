## This project was developed for educational purposes to test clean architecture together with DDD and CQRS.

## It was revealed:
The main feature of pure architecture is that the outer layers do not refer to the inner ones.

### Domain
The main feature of DDD is that the definition of __entity__ and __model__ changes in comparison with pure architecture. 
Namely, in DDD, in the ***domain*** layer of the __model__, they represent a set of parameters and
RULES that completely describe the subject area (also, the application of these rules as a check of correspondence based on a closed constructor),
so in the usual architecture on this layer there are __entities__ with a set of only parameters. This is perhaps the only difference.

### Infrastructure
At the ***infrastructure*** level in DDD, pure __entities__ are defined that will correspond to the final database, just as in a clear architecture, 
configurations for them are also located at this level, but in DDD configurations refer to the rules defined in the __domain models__.

### Application
At the ***application*** level, the principle is the same, but let me note that in DDD __models__ business rules are encapsulated, 
which provides complete security in that these rules will be saved. Here you can also work out exceptions well.

### Presentation
At the ***presentation*** level, there is a very familiar pattern from MV* that acts as a __view__; 
in the example here there are only implementations of controllers that can be used by the Server API.
Otherwise, this layer is nothing more than a representation and for the most part it is not always needed.

### CQRS
Regarding the CQRS - in other words, the mediator pattern, which in this project is implemented using the MediotR library.
The thing is cool, but because of it your project becomes larger, so here’s a life hack: if, as in this example, you have typical CRUD operations, 
then there is no point in using a mediator, if the project is larger and you need non-standard queries like: read, write ,
update and delete, and more specific types of creating 7 users who will not have a middle name in their full name and who are at least 18 years old,
then yes. Another thing that needs to be said about CQRS is that its principle of dividing into commands/requests and handlers and using them in the mediator pattern,
like: you have these parameters and execute this specific command. ```Send(<SomeCommandOrQuery>(some parameters)```

### Summary
In conclusion about the architecture, I can say that while I was doing this example I came across the idea that this thing is very helpful in writing structured code and, most importantly, code that works entirely according to the SOLID principles. But, during the development process, you need to understand that there are also patterns like CQRS, this is not yet talking about the Unit of Work, because I haven’t used it, that you need to use them in context and start from the problems that they solve, because they may be useless for you, which will create unnecessary code overhead, and that the question will come up: Isn’t it better to get by with ordinary services?

_That's all, I was with you and I really hope that this repository and the annotation to it helped you. Best coding to you!_
