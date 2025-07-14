using System;
using System.Collections.Generic;

// Namespace declaration
namespace CSharpConceptsDemo
{
    // Abstract class
    abstract class Animal
    {
        public abstract void AnimalSound(); // Abstract method (no body)
        public void Sleep() => Console.WriteLine("Zzz...");
    }

    // Inherited class
    class Dog : Animal
    {
        public override void AnimalSound() => Console.WriteLine("Dog says: Woof!");
    }

    // Interface
    interface IVehicle
    {
        void Drive();
    }

    class Car : IVehicle
    {
        public void Drive() => Console.WriteLine("Car is driving...");
    }

    // Base class
    class Person
    {
        public string Name = "John";
        public virtual void Greet() => Console.WriteLine("Hello from Person");
    }

    // Derived class (Inheritance)
    class Student : Person
    {
        public string School = "University";
        public override void Greet() => Console.WriteLine("Hello from Student");
    }

    class ConsoleApplication
    {
        // Enum
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }

        // Struct
        struct Point
        {
            public int X, Y;
            public Point(int x, int y) { X = x; Y = y; }
        }

        // Method with parameters and return
        static int Add(int a, int b) => a + b;

        // Method Overloading
        static void Print(string message) => Console.WriteLine(message);
        static void Print(int number) => Console.WriteLine("Number: " + number);

        // Static method
        static void SayHello() => Console.WriteLine("Hello World!");

        // Entry point
        static void Main(string[] args)
        {
            // Basic console output
            SayHello();

            // Variables & Data types
            int age = 25;
            double pi = 3.14;
            char grade = 'A';
            string name = "Ryan";
            bool isCool = true;

            Console.WriteLine($"Name: {name}, Age: {age}, Pi: {pi}, Grade: {grade}, IsCool: {isCool}");

            // Type casting
            double myDouble = 9.78;
            int myInt = (int)myDouble;
            Console.WriteLine("Casted value: " + myInt);

            // String operations
            string greeting = "Hello";
            Console.WriteLine(greeting.ToUpper());
            Console.WriteLine(greeting.Contains("ell"));

            // Arrays
            int[] nums = { 1, 2, 3 };
            foreach (int n in nums)
                Console.WriteLine("Array value: " + n);

            // Lists
            List<string> fruits = new List<string> { "Apple", "Banana" };
            fruits.Add("Cherry");
            foreach (string fruit in fruits)
                Console.WriteLine("Fruit: " + fruit);

            // If-else condition
            if (age > 18)
                Console.WriteLine("Adult");
            else
                Console.WriteLine("Minor");

            // Switch case
            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent!");
                    break;
                case 'B':
                    Console.WriteLine("Good");
                    break;
                default:
                    Console.WriteLine("Needs improvement");
                    break;
            }

            // Loops
            for (int i = 0; i < 3; i++)
                Console.WriteLine("For loop " + i);

            int count = 0;
            while (count < 3)
            {
                Console.WriteLine("While loop " + count);
                count++;
            }

            // Methods
            int sum = Add(5, 10);
            Console.WriteLine("Sum: " + sum);

            // Method Overloading
            Print("Overloaded method");
            Print(123);

            // Enums
            Days today = Days.Mon;
            Console.WriteLine("Today is: " + today);

            // Struct
            Point p = new Point(3, 4);
            Console.WriteLine($"Point: ({p.X}, {p.Y})");

            // OOP: Inheritance & Polymorphism
            Student s = new Student();
            Console.WriteLine(s.Name);
            s.Greet();

            // Abstract & Override
            Dog myDog = new Dog();
            myDog.AnimalSound();
            myDog.Sleep();

            // Interface implementation
            IVehicle myCar = new Car();
            myCar.Drive();

            // Exception handling
            try
            {
                int[] numbers = { 1, 2, 3 };
                Console.WriteLine(numbers[5]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }

            // Nullable types
            int? nullableInt = null;
            Console.WriteLine("Nullable value: " + (nullableInt ?? 0)); // coalescing operator

            // Lambda expression
            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine("Lambda multiply: " + multiply(4, 5));

            // LINQ example
            var evenNumbers = new List<int> { 1, 2, 3, 4, 5, 6 }.FindAll(n => n % 2 == 0);
            foreach (var n in evenNumbers)
                Console.WriteLine("Even number: " + n);

            // DateTime
            DateTime now = DateTime.Now;
            Console.WriteLine("Current DateTime: " + now);

            // End
            Console.WriteLine("\n✅ All C# concepts executed successfully!");
        }
    }
}
