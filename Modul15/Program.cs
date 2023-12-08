using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modul15
{
    internal class Program
    {
        static void Main()
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine("Class Name: " + myClassType.Name);

            Console.WriteLine("\nConstructors:");
            foreach (var constructor in myClassType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("\nProperties:");
            foreach (var prop in myClassType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }

            Console.WriteLine("\nMethods:");
            foreach (var method in myClassType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{method.ReturnType} {method.Name}");
            }
            MyClass myClassInstance = (MyClass)Activator.CreateInstance(typeof(MyClass), true);
            PropertyInfo publicPropertyInfo = myClassType.GetProperty("PublicProperty");
            publicPropertyInfo.SetValue(myClassInstance, 123);

            // Для изменения приватного свойства потребуется указать BindingFlags
            PropertyInfo privatePropertyInfo = myClassType.GetProperty("PrivateProperty", BindingFlags.NonPublic | BindingFlags.Instance);
            privatePropertyInfo.SetValue(myClassInstance, "New Value");

            MethodInfo publicMethodInfo = myClassType.GetMethod("PublicMethod");
            publicMethodInfo.Invoke(myClassInstance, null);

            MethodInfo privateMethodInfo = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethodInfo.Invoke(myClassInstance, null);



        }
    }
}
