# Behavioral Design Patterns 
## Chain of Responsibility

### Кратко описание

Chain of Responsibility позволява на обект да изпраща request, без да знае кой обект ще го получи и обработи. Искането се изпраща към верига от обекти (приемници) и всеки обект в тази верига, ако не може да обработи командата, я подава нататък, докато някой от обектите я обработи. 

### Намерение:
Chain of Responsibility избягва закачането на подателя на искането към приемник, като по този начин дава възможност и  на други обекти да обработят искането също.
Не е необходимо да знаем подробности за обектите, които обработват командите, затова те могат да бъдат конфигурирани динамично. Механизмът на свързване по веригата използва рекурсивна композиция, за да позволи свързването на неограничен брой обекти, които обработват команди. 


### Имплементация

###### Handler example

	using System;

    class MainApp
    {
    	static void Main()
    	{
      		IHandler h1 = new ConcreteHandler1();
      		IHandler h2 = new ConcreteHandler2();
      		IHandler h3 = new ConcreteHandler3();
      		h1.SetSuccessor(h2);
      		h2.SetSuccessor(h3);

      		int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

      		foreach (int request in requests)
      		{
        		h1.HandleRequest(request);
      		}

      		Console.Read();
    	}
    }



###### Abstract Handler

    abstract class Handler : IHandler
    {
    	protected Handler successor;

    	public void SetSuccessor(Handler successor)
    	{
      		this.successor = successor;
    	}

    	public abstract void HandleRequest(int request);
    }

###### ConcreteHandler1

    class ConcreteHandler1 : Handler
    {
    	public override void HandleRequest(int request)
    	{
      		if (request >= 0 && request < 10)
      		{
        		Console.WriteLine("{0} handled request {1}", 
          		this.GetType().Name, request);
      		}
      		else if (successor != null)
      		{
        		successor.HandleRequest(request);
      		}
    	 }
     }

###### ConcreteHandler2
    
    class ConcreteHandler2 : Handler
    {
    	public override void HandleRequest(int request)
    	{
      		if (request >= 10 && request < 20)
      		{
       			Console.WriteLine("{0} handled request {1}", 
          		this.GetType().Name, request);
      		}
      		else if (successor != null)
      		{
        		successor.HandleRequest(request);
      		}
    	}
     }



### UML Диаграма
[alt text]
https://github.com/dushka-dragoeva/TelerikSeson2016/blob/master/Programing%20C%23/Design%20Patterns/05.%20Behavioral-Design-Patterns/Pictures/Chain_of_responsibility.png)


