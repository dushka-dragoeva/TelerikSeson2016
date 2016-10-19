** Code formating
Dont use space between the brackets

Use the following order of definitions:

Constants, 
delegates, 
inner types, 
fields, 
constructors, 
properties, 
methods

Static members, 
public members,
protected members, 
internal members, 
private members

Break long lines after punctuation

**High Quality Methods

Reduce complexity
Improve code readability
Avoid duplicating code
Hide implementation details
Increase the level of abstraction

The method returns incorrect result => bug

The method returns incorrect output when its input 
is incorrect or unusual=> low quality
Could be acceptable for private methods only

The methods has side effect => spaghetti code

** Strong Cohesion

*** Acceptable

1. Functional cohesion (independent function)  -  
the method depends on the passed parameteres.
2. Sequentianal cohesion  (algorithm) - 
Method perform sequens of operation to peform a single task.
3. Comunication cohesion (common data) -
a set of operations used to proceed certain data and
produce result.
4. Temporial cohesion (time related activities) - 
Operation that are not related but need to happen in a certain moment


Unacceptable cohesion

1. Logical cohesion - performs different operations depending on 
an input parameteres
2. Coincidential cohesion (spaghetti) - not related, random
operations are grouped in a method for unclear  reason

Loose Coupling

1. Minimal dependency to other parts of code
2. Minimal dependency on class memebers or
   external classes and their memebers
3. No side efects
4. Easy reusing in othe class or project

Idel coupling:

1. Method depends on its parameters
2. Real word - can not avoid
3  Method in classes coupeled to some fields
4. Method in a class is coupeled to static method, props,
or constants in external class

Unacceptable coupling

1. Coupling to static fields in external classes
2. Methods takes as argument class fields =>check intend of method
3. Method is public but is not a part from public interface


how to reduce

1. Utility classes => hide compleh logic
2. Abstraction => define public interfaces and hide implementation details
3. Encapsulation => all is private - increase visibility if it is needed

Tight coupling => passing parameters through class fields

Method Parameters

1. Put the most importent parameters first
2. Dont modify imput parameters
3. Use parameters consistently4. 
4. Number of parameters 7+-2
5. Method lenth - avoid longer than 1 screen 30 rows

Pseudo Code

can help for
1. Routines design
	What the routine will abstract => the information will hide
	Input parameters
	Output
	Preconditions
	Postconditions
	
2. Routines coding
3. Code Verification
4. Clearing up unreachable branches in routine

High Quality Classes

Basic principles => cohesion, coupling, inheritance, polymorphism
Strong cohesion is a tool for menaging compexity
Modules must depend little on each other
All classes and routines must have small direct visible and
flexible relationship to other classes and routines

1. Good abstraction

2. Correct Encapsulation

3. Correct inheritance
Structures can not be inherited

4. Good reason to create class

5.Polymorphism is a tool to enable code reuse
it is implemented through
virtual methods
abstract methods
interfaces

How to design HQ class

Don't create more than 6 levels of inheritance
Less external method calls == less coupling
Also known as "fan-out"






