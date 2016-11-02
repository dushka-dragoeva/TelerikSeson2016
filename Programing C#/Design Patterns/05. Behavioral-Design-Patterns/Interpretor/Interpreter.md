# Behavioral Design Patterns 
## Interpreter

### Кратко описание

  
Interpreter позволява дефинирането на домейн език като проста езикова граматика, която представя правилата на домейна като изречения на този език и интерпретира тези изречения, за да решава поставените проблеми. Шаблонът използва класове, за да представи всяко граматично правило. И понеже граматиката има йерархична структура, една йерархия на наследяване на класовете с граматичните правила се вписва идеално.  
Абстрактен базов клас съдържа метода interpret(). А всеки конкретен подклас имплементира interpret() със съответния аргумент. Interpreter е един от дизайн шаблоните, които не са много често използвани.


### Намерение:
- Езикът дефинира своята граматика, а също така и интерпретатор, който използва граматиката, за да интерпретира изречения написани на този език.

- Мапва се домейн  към език, езикът към граматика и граматиката към йерархичен обектно-ориентиран дизайн.


### Имплементация

###### Interpreter example

	using System;
	using System.Collections;

    class MainApp
    {
    	static void Main()
    	{
      		Context context = new Context();

      		// Usually a tree 
      		ArrayList list = new ArrayList(); 

      		// Populate 'abstract syntax tree' 
      		list.Add(new TerminalExpression());
      		list.Add(new NonterminalExpression());
      		list.Add(new TerminalExpression());
      		list.Add(new TerminalExpression());

      		// Interpret 
      		foreach (AbstractExpression exp in list)
      		{
        		exp.Interpret(context);
      		}

      		// Wait for user 
      		Console.Read();
     	}
     }
 


###### Context

    class Context 
    {
    }

###### Abstract Expression

    abstract class AbstractExpression 
    {
    	public abstract void Interpret(Context context);
    }

###### Terminal Expression
    
    class TerminalExpression : AbstractExpression
    {
    	public override void Interpret(Context context)  
    	{
      		Console.WriteLine("Called Terminal.Interpret()");
    	}
    }


###### Nonterminal Expression

	class NonterminalExpression : AbstractExpression
    {
    	public override void Interpret(Context context)  
    	{
      		Console.WriteLine("Called Nonterminal.Interpret()");
    	}  
    }

### UML Диаграма

![alt Interpreter](https://github.com/dushka-dragoeva/TelerikSeson2016/blob/master/Programing%20C%23/Design%20Patterns/05.%20Behavioral-Design-Patterns/Pictures/Interpreter.png)


