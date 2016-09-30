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
        public IBase<T> classObject;

        public BaseClass()
        {
            classObject = Factory.CreateInstance<T>() as IBase<T>;
        }
    }

    public class Person : BaseClass<IRead>
    {
        public void Run()
        {
            if (classObject != null)
            {
                classObject.GetInstance().GetAll();
            }
        }
    }


    public interface IRead : IBase<ReadClass>
    {
        string GetAll();
    }

    public class ReadClass : IRead
    {
        public string GetAll()
        {
            return "GetRead";
        }

        public ReadClass GetInstance()
        {
            return new ReadClass();
        }
    }

    public interface IWrite : IBase<WriteClass>
    {
        string GetWrite();
    }

    public class WriteClass : IWrite
    {
        public string GetWrite()
        {
            return "GetWrite";
        }

        public WriteClass GetInstance()
        {
            return new WriteClass();
        }
    }

    public interface IBase<T>
    {
        T GetInstance();
    }
}

