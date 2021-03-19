using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1Homework1.Data;
using Week1Homework1.Entity;
using  System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Week1Homework1.Data_Access
{
    public class TextFileRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected SingletonData<TEntity> _singletonData;
        protected String _path;

        public TextFileRepositoryBase()
        {
            _singletonData = SingletonData<TEntity>.Instance;
            _path =
                @"C:\Users\omer\source\repos\Week1Homework1\week1-homework1-omerbeden\Week1Homework1\Data\Products.txt";
        }

        public virtual TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            string textToWrite = entity.ToString();
            using (StreamWriter file = new StreamWriter(_path,true))
            {
                file.WriteLine(textToWrite);
            }
        }

        public virtual void Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
