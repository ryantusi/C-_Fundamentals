using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🧮 Welcome to the C# Console Calculator!");
            Console.WriteLine("----------------------------------------");

            while (true)
            {
                try
                {
                    // Input numbers
                    Console.Write("\nEnter first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter operator (+, -, *, /, % or type 'exit' to quit): ");
                    string op = Console.ReadLine();

                    if (op.ToLower() == "exit")
                    {
                        Console.WriteLine("👋 Exiting calculator. Goodbye!");
                        break;
                    }

                    Console.Write("Enter second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double result = 0;
                    bool validOperation = true;

                    // Perform calculation
                    switch (op)
                    {
                        case "+":
                            result = num1 + num2;
                            break;

                        case "-":
                            result = num1 - num2;
                            break;

                        case "*":
                            result = num1 * num2;
                            break;

                        case "/":
                            if (num2 == 0)
                            {
                                Console.WriteLine("❌ Cannot divide by zero!");
                                validOperation = false;
                            }
                            else
                                result = num1 / num2;
                            break;

                        case "%":
                            result = num1 % num2;
                            break;

                        default:
                            Console.WriteLine("❌ Invalid operator.");
                            validOperation = false;
                            break;
                    }

                    // Show result
                    if (validOperation)
                        Console.WriteLine($"✅ Result: {num1} {op} {num2} = {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("⚠️ Please enter valid numeric values.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("⚠️ Error: " + ex.Message);
                }
            }
        }
    }
}
