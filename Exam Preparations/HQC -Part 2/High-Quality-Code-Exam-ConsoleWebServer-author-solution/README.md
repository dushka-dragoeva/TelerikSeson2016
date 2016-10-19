# High Quality Code Exam 2015 - ConsoleWebServer

## Refactoring documentation:

###Design pattern: Factory Method
Required 1 but implemented 3:
* `HandlerFactory` implements `CreateAndAttachHandlers` method from `IHandlerFactory` and is used for constructing and attaching handlers.
* `ControllerFactory` implements `CreateController` method from `IControllerFactory` and is used for constructing controller objects by given request.
* `ResponseProvider` implements `GetResponse` method from `IResponseProvider` and is used for constructing responses by given request as string.

###Design pattern: Strategy
Required 1 but implemented at least 2:
* The `WebServerConsole` is receiving its dependency to `IResponseProvider` strategy as a parameter in its constructor instead of creating it on its own using the `new` keyword
* The `ResponseProvider` class is receiving its dependecy to `IHandlerFactory` as a parameter in its constructor instead of creating it on its own using the `new` keyword

###Design pattern: Template Method
Required 2 but implemented 3:
* Some of the functionality of the `GetResponse` method is implemented in `BaseActionResult` and other is leaved to the "hooking" methods (called `GetStatusCode`, `GetContent` and `GetContentType`) in class inheritants (such as `ContentActionResult`, `JsonActionResult` and `RedirectActionResult`)
* Some of the functionality of the `HandleRequest` method is implemented in `Handler` and other is leaved to the "hooking" methods (called `CanHandle` and `Handle`) in class inheritants (such as `ControllerHandler`, `StaticFileHandler`, etc.)
* Some of the functionality of the `GetResponse` method is implemented in `ActionResultDecorator` and other is leaved to the "hooking" method called `UpdateResponse` in class inheritants (`ActionResultWithCorsDecorator` and `ActionResultWithNoCachingDecorator`)

###Design pattern: Chain of Responsibility
* The abstract class `Handler` have `HandleRequest` method which accepts `HttpRequest` and returns `HttpResponse` and also have `SetSuccessor(Handler successor)` method to receive the next element of the chain. All implementations of the `Handler` class (`ControllerHandler`, `HeadHandler`, `OptionsHandler` and `StaticFileHandler`) are chained in the `HandlerFactory` class using the `SetSuccessor` method.

More info: https://github.com/TelerikAcademy/High-Quality-Code-Exam-ConsoleWebServer/commit/a755175825e2bb1378c8fe90a3efbbfc61e879a8

###Design pattern: Decorator
* The abstract `ActionResultDecorator` class implements `IActionResult` and has a field `actionResult` of type `IActionResult`. The classes `ActionResultWithCorsDecorator` and `ActionResultWithNoCachingDecorator` (the concrete decorators) "decorates" `IActionResult`, adding additional functionality (headers).

More info: https://github.com/TelerikAcademy/High-Quality-Code-Exam-ConsoleWebServer/commit/745394da9f032185117cb2fa0d8feb48be30edce

###Found bugs:
* When file is not found the message should be `File not found!` instead of `File not found` (the difference is the `!` sign)
* When protocol version is 3.0 the response should be `501 NotImplemented Request cannot be handled.` instead of `200 OK`. This is fixed by replacing `request.ProtocolVersion.Major <= 3;` with `request.ProtocolVersion.Major < 3;`
* When default parameter is not specified the parameter value should be `string.Empty` instead of `Param`

More info about the introduced bugs: https://github.com/TelerikAcademy/High-Quality-Code-Exam-ConsoleWebServer/commit/5d7d49cd82624b89e1baaad6818177ca32b642e5

###Found bottleneck:
* In `StaticFileHandler` the slow recursive method `FileExists(string path, string filePath, int depth)` is replaced with call to `File.Exists(filePath)`

More info about the bottleneck: https://github.com/TelerikAcademy/High-Quality-Code-Exam-ConsoleWebServer/commit/a26aab61abab219f68e7b728d0f7891764f4597a

###Single responsibility principle
* `HttpRequest` and `RequestParser` are now two separate classes serving single responsibilities.

###Open/closed principle
Clients can easily extend the framework by:
* Implementing and using custom `ActionResultDecorator`
* Implementing custom `IHandlerFactory` and pass it to the `ResponseProvider`
* Implementing and attaching custom `Handler`
* Adding additional controller
* Returning custom `IActionResult` in controller methods
* Implementing custom `IResponseProvider` and pass it to the `WebServerConsole`
* And more other extensibility points in which user can add functionality without touching the original framework code

###Liskov substitution principle
* All inheritants can replace their base classes in the code without breaking existing functionality and all classes are interchangable.

###Interface segregation principle
* All interfaces in the code (`IActionResult`, `IControllerFactory`, `IHandlerFactory`, `IHttpRequest`, `IResponseProvider`) are small and well-defined.

###Dependency inversion principle
* The `WebServerConsole` is receiving its dependency to `IResponseProvider` strategy as a parameter in its constructor instead of creating it on its own using the `new` keyword
* The `ResponseProvider` class is receiving its dependecy to `IHandlerFactory` as a parameter in its constructor instead of creating it on its own using the `new` keyword

###*bonus*  New features
New features can be found here: https://github.com/TelerikAcademy/High-Quality-Code-Exam-ConsoleWebServer/commit/5b430dc30698aa50b3b544e36e6350576359e2eb
