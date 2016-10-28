# Decorator Pattern

## Описание
 * Този шаблон за дизайн ни позволява да добавяме допълнителна функционалност към даден базов клас по време на изпълнението на нашата програма. Като това се случва без да се променя поведението на други обекти от същия клас.
 *Освновният плюс е че ни предпазва от това да създаваме нови под-класове за да добавим нова функционалност. Като за всеки даден вариант и комбинация да имаме отделн клас (в примера по-надолу това щеше да заничи да имаме по 6 подкласа за всяко превозно средство, за да покрием възможността да се комбинират 3 екстри)   
 
## Цел
 * Добавя допълнителна функционалност на обектите динамично и е флексибилна алтернатива за заместване на множество под класове

## Известни употреби
 * In .NET: CryptoStream and GZipStream decorates Stream

## Implemntation
```
// base class
public abstract class VehicleComponent
    {
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public abstract void DisplayInfo();

        public abstract void UpdatePrice(decimal updateCost);
    }

// Concrete Component клас. 
public class BaseCar : VehicleComponent
    {
        public Car(string brand, decimal price)
        {
            this.Brand = brand;
            this.Price = price;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("{0} -----", this.GetType().Name);
            Console.WriteLine("Brand: {0}", this.Brand);
            Console.WriteLine("Price: {0}", this.Price);
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Price += updateCost;
        }
    }

// базовият клас за всички декоратори

 public abstract class VehicleDecorator : VehicleComponent
    {
        public VehicleDecorator(decimal price, VehicleComponent vehicle)
        {
            this.Price = price;
            this.Vehicle = vehicle;
            this.Vehicle.UpdatePrice(this.Price);
        }

        public VehicleComponent Vehicle { get; private set; }

        public override void DisplayInfo()
        {
            this.Vehicle.DisplayInfo();
            var name = this.GetType().Name;
            var lastIndex = name.IndexOf("Decorator");
            var addedExtra = StringUtilities.SplitCamelCase(name.Substring(0, lastIndex));
            Console.WriteLine($"{string.Join(" ", addedExtra)}");
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Vehicle.UpdatePrice(updateCost);
        }
    }


// добавя допълнителни функционалност или информация за подадения му обект
internal class V8EngineDecorator : VehicleDecorator
    {
        public V8EngineDecorator(decimal price, VehicleComponent vehicle) : 
            base(price, vehicle)
        {
        }

        public void DriveOnTrack()
        {
            Console.WriteLine("Driving around the local racing track");
        }
    }
// позволява ни лесно да комбинираме различните опции и лесно да изпозлваме нова функционалност. 

public class Client
    {
        public static void Main(string[] args)
        {
            /// Creating a car
            var basicCar = new BaseCar("BMW", 85000);
            basicCar.DisplayInfo();
            LineSeparator();

            /// Adding one option
            var upgradedCar = new LeatherInteriorDecorator(1300m, basicCar);
            Console.WriteLine("Upgraded Car Includes:");
            upgradedCar.DisplayInfo();
            LineSeparator();

            /// Adding all options
            var superCar = new V8EngineDecorator(3500m, new NavigationSystemDecorator(300m, upgradedCar));
            Console.WriteLine("Super Car Includes:");
            superCar.DisplayInfo();
            superCar.DriveOnTrack();
            LineSeparator();
        }

        private static void LineSeparator()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
~~~

## Последствия
 *Decorator ни позволява да спазваме Open/Close принципа.
 *Предпазва от лавинообразно наразтване на класове


## Проблеми
 * Различните обекти нямат собствена индентичност, коeто води до лоша тестваемост
 * Наличието на множество сходни малки обекти води до трудна поддръжка
  
## UML  диаграма

![alt Decorator](https://github.com/dushka-dragoeva/TelerikSeson2016/blob/master/Programing%20C%23/Design%20Patterns/04.%20Structural-Design-Patterns/Images/Decorator-Diagram.png)
