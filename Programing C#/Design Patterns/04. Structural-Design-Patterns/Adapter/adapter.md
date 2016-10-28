# Adapter/Адаптор

 * Преобразува интерфейса на даден клас, така че да може да бъде използван от клиента.
 * Позволява на класове с несъвместими интерфейси да работят заедно.
 	
Използването на адаптор се налага при наличието на несъвместими интерфейси. Клиентът иска да извика даден метод, но не може, защото интефейсът, който могат да ползват обектите на клиента не е наличен в кода, чийто методи искаме да извикаме. В зависимост от употребата на адаптера, шаблонът е наричан още wrapper и translator.

## Клас диаграма:

![Factory method](http://www.dofactory.com/images/diagrams/net/adapter.gif)

Компоненти:

 * *__Target:__* Дефинира специфичния интерфейс, който клиентът използва.
 * *__Adapter:__* Приспособява интерфейса *Adaptee* към интерфейса *Target*.
 * *__Adaptee:__* Дефинира съществуващ интерфейс, който се нуждае от адаптиране.
 * *__Client:__* Работи с обекти, подчиняващи се на интерфейса *Target*.

Примерен код:

```
using System;
 
namespace Adapter
{
  class MainApp
  {
    static void Main()
    {
      // Create adapter and place a request
      Target target = new Adapter();
      target.Request();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  class Target
  {
    public virtual void Request()
    {
      Console.WriteLine("Called Target Request()");
    }
  }
 
  class Adapter : Target
  {
    private Adaptee adaptee = new Adaptee();
 
    public override void Request()
    {
      // Possibly do some other work
      //  and then call SpecificRequest
      this.adaptee.SpecificRequest();
    }
  }

  class Adaptee
  {
    public void SpecificRequest()
    {
      Console.WriteLine("Called SpecificRequest()");
    }
  }
}
```