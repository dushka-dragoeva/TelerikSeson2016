# Behavioral Design Patterns 
## Iterator

### Проблем

Сложните обекти, като например различните видове колекции, трябва да дават възможност за достъп до своите елементи без да показват своята вътрешна структура. Освен това трябва да можем да обхождаме елементите на колекцията по различни начини в зависимост от нашата конкретна нужда.
Не е добро решение на проблема да натоварим интерфейса със списък с операции за различните видове обхождане, дори и ако бихме могли да предвидим какви ще бъдат те. 
Моделът Iterator обаче ни позволява да направим това по много добър начин. Ключовата идея е да се поеме отговорността за достъп до елементите на сложния обект и да се сложи в Iterator обект, който дефинира стандартен протокол на обхождане.

### Намерение:

Абстракцията, предоставена от модела iterator ни позволява да модифицираме имплементацията на колекция, без да правим никакви промени извън колекцията. Това ни дава възможност да създадем общ GUI компонент, който ще бъде в състояние да обхожда всяка колекция на сотуерното ни приложение.

Iterator предоставя начин за достъп до елементите на съставен обект без да излага на показ неговата структура.


### Имплементация

###### Iterator example

	using System;
    using System.Collections;

    class MainApp
    {
    	static void Main()
    	{
      		ConcreteAggregate a = new ConcreteAggregate();
      		a[0] = "Item A";
      		a[1] = "Item B";
      		a[2] = "Item C";
      		a[3] = "Item D";

      		// Create Iterator and provide aggregate 
      		ConcreteIterator i = new ConcreteIterator(a);

      		Console.WriteLine("Iterating over collection:");
 
      		object item = i.First();
      		while (item != null)
      		{
        		Console.WriteLine(item);
        		item = i.Next();
      		} 

      		// Wait for user 
      		Console.Read();
    	}
    }



###### Abstract Aggregate

    abstract class Aggregate
    {
    	public abstract Iterator CreateIterator();
    }

###### Concrete Aggregate

    class ConcreteAggregate : Aggregate
    {
    	private ArrayList items = new ArrayList();

    	public override Iterator CreateIterator()
    	{
      		return new ConcreteIterator(this);
    	}

    	public int Count
    	{
      		get{ return items.Count; }
    	}

    	public object this[int index]
    	{
      		get{ return items[index]; }
      		set{ items.Insert(index, value); }
    	}
    }

###### Abstract Iterator
    
    abstract class Iterator
    {
    	public abstract object First();
    	public abstract object Next();
    	public abstract bool IsDone();
    	public abstract object CurrentItem();
    }

###### Concrete Iterator

    class ConcreteIterator : Iterator
    {
    	private ConcreteAggregate aggregate;
    	private int current = 0;

    	public ConcreteIterator(ConcreteAggregate aggregate)
    	{
      		this.aggregate = aggregate;
    	}

    	public override object First()
    	{
      		return aggregate[0];
    	}

    	public override object Next()
    	{
      		object ret = null;
      		if (current < aggregate.Count - 1)
      		{
        		ret = aggregate[++current];
      		}
 
      		return ret;
    	}

    	public override object CurrentItem()
    	{
      		return aggregate[current];
    	}

    	public override bool IsDone()
    	{
      		return current >= aggregate.Count ? true : false ;
    	}
    }

### UML Диаграма
[Iterator](Pictures/Iterator.png)


