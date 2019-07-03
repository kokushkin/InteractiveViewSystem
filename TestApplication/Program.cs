using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public interface ITestGenericInterface<T>
    {
        int GetCode(T obj);
    }

    public class SimpleCoder : ITestGenericInterface<string>
    {
        public int GetCode(string str)
        {
            return str.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
