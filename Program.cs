using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {

        // Reflection (Yansıma)

        /*
        Reflection objects are used for obtaining type information at runtime. The classes that give access to the metadata of a running program are in the System.Reflection namespace.

        The System.Reflection namespace contains classes that allow you to obtain information about the application and to dynamically add types, values, and objects to the application.

        Applications of Reflection
        Reflection has the following applications −

        It allows view attribute information at runtime.
        It allows examining various types in an assembly and instantiate these types.
        It allows late binding to methods and properties
        It allows creating new types at runtime and then performs some tasks using those types.

        */

        // Reflection bize hakkında bilgi sahibi olmadığımız programatik nesnelerle ilgili çalışma zamanında(run-time) bilgi alabilmemizi sağlayan bir yöntemdir.
        // örneğin programın çalışma zamanında farklı bir DLL dosyasını uygulama içerisine dahil ederek içerisindeki metot ve dışarıya açık nesneleri kullanabilmeyi sağlar.

        Assembly ourAssembly = Assembly.GetExecutingAssembly();
        AssemblyShowInfo(ourAssembly);

        var student = new Student
        {
            Name = "Hasan",
            SurName = "GG",
            Email = "sadad@email.com"
        };

        Type studentType = typeof(Student);

        // Type'ı çekmenin en bilindik yöntemi extension methodlar functional programing is candır.

        PropertyInfo[] studentType2 = student.GetType().GetProperties();
        FieldInfo[] fieldInfos = studentType.GetFields();
        MethodInfo[] methodInfos = studentType.GetMethods();
        
        foreach (var item in fieldInfos)
        {
            System.Console.WriteLine($"Field Name : {item.Name}");
            System.Console.WriteLine($" {item.DeclaringType}");
            System.Console.WriteLine($"Object Value : {item.GetValue(student)}");
        }

        foreach (var method in methodInfos)
        {
            System.Console.WriteLine("-------------------");
            System.Console.WriteLine($"Method Names :  {method.Name}");
            System.Console.WriteLine($"Method ParameterType :  {method.ReturnParameter}");
            System.Console.WriteLine($"Method CallingConvention :  {method.CallingConvention}");
            System.Console.WriteLine($"Method Is Public :  {method.IsPublic}");
            System.Console.WriteLine("-------------------");

        }

        Console.ReadLine();
    }

    static void AssemblyShowInfo(Assembly asm)
    {
        Console.WriteLine("---------------");
        Console.WriteLine($"FullName : {asm.FullName}");
        Console.WriteLine($"Path : {asm.Location}");
        Console.WriteLine($"Version : {asm.ImageRuntimeVersion}");
        Console.WriteLine();
    }

    public class Student
    {
        public string Name;
        public string SurName;
        public string Email;

        public string SayName(string name)
        {
            return name;
        }

    }
}