using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Week1Homework1.Entity;

namespace Week1Homework1.Data
{
    public sealed class SingletonData<T>
    {

        private static readonly SingletonData<T> _instance = new SingletonData<T>();

        public  List<T> entities = new List<T>();

        static SingletonData()
        {
            
        }

        private SingletonData()
        { 
            
        }

        public static SingletonData<T> Instance
        {
            get
            {
                return _instance;
            }
        }
        
        
        
    }
}
