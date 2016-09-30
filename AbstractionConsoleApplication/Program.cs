using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pp = new Person();
            pp.Run();
        }
    }


    public class BaseClass<T> where T : class
    {
        public T classObject;

        public BaseClass()
        {
            classObject = Factory.CreateInstance<T>();
        }
    }

    public class Person : BaseClass<IWrite>
    {
        public void Run()
        {
            if (classObject != null)
            {
                classObject.GetWrite();
            }
        }
    }


    public interface IRead : IBase
    {
        string GetAll();
    }

    public class ReadClass : IRead
    {
        public string GetAll()
        {
            return "GetRead";
        }
    }

    public interface IWrite : IBase
    {
        string GetWrite();
    }

    public class WriteClass : IWrite
    {
        public string GetWrite()
        {
            return "GetWrite";
        }
    }

    public interface IBase
    {

    }
}

