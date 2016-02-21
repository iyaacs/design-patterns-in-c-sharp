using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class badSingleton
    {
        private static badSingleton _uniqueInstance;
        private badSingleton() { }
        public static badSingleton uniqueInstance
        {
            get
            {
                if (_uniqueInstance == null) { _uniqueInstance = new badSingleton(); }
                return _uniqueInstance;
            }
        }
    }

    public sealed class Singleton
    {
        private static Singleton _uniqueInstance = new Singleton();
        private Singleton() { }
        public static Singleton uniqueInstance
        {
            get
            {
                return _uniqueInstance;
            }
        }
    }

    public sealed class goodSingleton
    {
        private static volatile goodSingleton _uniqueInstance = null;
        private static object syncRoot = new Object();
        private goodSingleton() { }
        public static goodSingleton uniqueInstance
        {
            get
            {
                if (_uniqueInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (_uniqueInstance == null)
                            _uniqueInstance = new goodSingleton();
                    }
                }
                return _uniqueInstance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Thread 이용한 테스트용 코드 미작성. 조만간 작성예정*/
        }
    }
}
