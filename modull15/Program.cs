using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//Дополнительное задание (для продвинутого уровня):

//-Используйте рефлексию для создания мини-интерпретатора, который может вызывать методы объекта на основе ввода 
//  пользователя (например, пользователь вводит имя метода и параметры, а программа выполняет этот метод).
namespace modull15
{
    public class MyClass
    {
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

       
    }

    class Program
    {
        static void Main()
        {
            MyClass myObject = new MyClass();

            while (true)
            {
                Console.Write("Enter method name (or 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit") break;

                Type type = myObject.GetType();
                MethodInfo method = type.GetMethod(input);

                if (method != null)
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    object[] paramValues = new object[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write($"Enter {parameters[i].ParameterType.Name} parameter: ");
                        string paramInput = Console.ReadLine();
                        paramValues[i] = Convert.ChangeType(paramInput, parameters[i].ParameterType);
                    }

                    object result = method.Invoke(myObject, paramValues);
                    if (result != null)
                    {
                        Console.WriteLine($"Result: {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Method not found.");
                }
            }
        }
    }
}
