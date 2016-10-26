## Factory Method Pattern##

Factory Method шаблона дефинира абстрактен клас за съдаване на обекти от друг клас, но избора на конкретен тип на обекта, който трябва да бъде създаден се прави от други класове по време на изпълнение на приложението.

Factory Method шаблона отговаря на **необходимостта** от интерфейс за създаване на различни обекти, като конкретния тип на инстанцирания обект се избира в зависимост от заявката на друг клас. Новосъздадените обекти се реферират чрез общ интерфейс.


Factory Method шаблона е **приложим** в случаите, в които класа, създаващ обекти, не може да предположи, какъв клас обект се очаква да бъде създаден. Единствено класа, който прави заявка за създаване на обект може да укаже неговия тип.

Factory Method шаблона намира широка **употреба** в ООП дизайна. Някои от най-честите приложения са:

+ toolkit, utility класове и framework-и;
+ MacApp, ET++, Unidraw. Smalltalk, Orbix ORB.

Factory Method шаблона се **имплементира** по два основни начина - чрез дефиниране на абстрактен Creator клас, който не съдържа имплементаниця на самия factory метод или чрез дефиниране на конкретен клас, който имплементира самия метод.
```
	public interface IProduct
	{
	    public void DoSomething();
	}

	public class ConcreteProduct : IProduct
	{
	    public void DoSomething()
	    {
	        // doing something in ConcreteProduct way;
	    }
	}

	public class ConcreteProduct2 : IProduct
	{
	    public void DoSomething()
	    {
	        // doing something in OtherConcretProduct way;
	    }
	}

	public enum ProductType
	{
	    ConcretProduct,
	    OtherConcretProduct
	}

	public class Factory
	{
	    public IProduct CreateProduct(ProductType type)
	    {
	        IProduct product = null;
	        switch (type)
	        {
	            case ProductType.ProductType1:
	                product = new ConcreteProduct();
	                break;
	            case ProductType.ProductType2:
	                product = new OtherConcretProduct();
	                break;
	            default:
	                break;
	        }

	        return product;
	    }
	}
```
При имплементацията на Factory Method шаблона **участват**:

+ *Product интерфейса* - дефинира интерфейс за обектите, които се създават от Factory метода;
+ *ConcreteProduct* - имплементира Product интерфейса;
+ *Factory* - декларира самия метод, който създава обекти;
+ *ConcreteFactory* (когато Factory класа е абстрактен; липсва в примера) - надгражда Factory класа с цел създаване на конкретен Product.

В **следствие** използването на Factory Method шаблона, отпада необходимостта от свързване на приложението с конкретни класове. Кодът използва единствено Product интерфейса, което прави възможна работата му с много различни ConcreteProduct класове.

**Структура**

[UML Diagram](http://www.apwebco.com/images/FactoryMethod.jpg)
