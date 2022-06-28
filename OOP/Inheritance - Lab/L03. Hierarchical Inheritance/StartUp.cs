using System;

namespace L03._Hierarchical_Inheritance
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Cat cat = new Cat();
            cat.Meow(); 
            cat.Eat();
        }
    }
}
