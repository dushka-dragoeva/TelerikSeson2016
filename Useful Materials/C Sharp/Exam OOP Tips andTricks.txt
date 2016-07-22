
Всички обекти в папка Products или както се казва

1. Ако пропъртито изрично не е казано по условие да се валидира => автоматично пропърти
=> няма privite field
Полета правим само ако имаме валидация в сетера

2. Ако имаме математическа операция на 2 полета => в конструктура
3. Ако овърайд пропърти => protected set в конструктура на base class
4. Полетата валидираме в конструктура когато нямаме сетер
5. Enum - направо я добавяме в стрингбилдъра - не е нужно да я кастваме или  toString()
6. Ако ни се подава колекция, а интерфейса иска стринг => в get правим колекцията  toString()
7. Винаги валидация дали продукта != null при add, remove!!!!!!!!!!!!
8. Винаги да пробвам с ICollection();
9. Switch case => defalt -> return base
10. ExtendedClass through inheritance and overide  virtual metods + encapculation
same as in parent class
11. In console where we are allowd to change - new instance of extended classes

Properties are not obligatory bound to a class field – 
can be calculated dynamically:
public class Rectangle
{
    private double width;
    private double height;

    // More code …

    public double Area
    {
          get
            {
                return width * height;
            }
    }
}