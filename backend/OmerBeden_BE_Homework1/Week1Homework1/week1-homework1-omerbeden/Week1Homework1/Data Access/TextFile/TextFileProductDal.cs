using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Week1Homework1.Data;
using Week1Homework1.Entity;

namespace Week1Homework1.Data_Access.TextFile
{
    public class TextFileProductDal : TextFileRepositoryBase<Product>, IProductDal
    {

        public TextFileProductDal()
        {

        }

        private string[] ReadTxt(string path)
        {
            string[] lines = File.ReadAllLines(_path);
            return lines;
        }

        private void UpdateTxt(int id, Product entity)
        {
            var lines = ReadTxt(_path);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split("\t");
                string IdinTxt = line[0];

                if (IdinTxt == id.ToString())
                {
                    line[0] = entity.Id.ToString();
                    line[1] = entity.Name;
                    line[2] = entity.Price.ToString();
                    lines[i] = line[0] + "\t" + line[1] + "\t" + line[2];
                    break;
                }
            }

            File.WriteAllLines(_path, lines);
        }

        private void DeleteTxt(int id)
        {
            string[] lines = ReadTxt(_path);
            string[] newLines = new string[lines.Length - 1];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split("\t");
                string IdinTxt = line[0];

                if (IdinTxt == id.ToString())
                {
                    continue;
                }

                newLines[i] = lines[i];

            }
            File.WriteAllLines(_path, newLines);


        }

        private void FillList(string[] strings)
        {
            for (int i = 1; i < strings.Length; i++)
            {
                string[] line = strings[i].Split("\t");

                Product product = new Product
                {
                    Id = Convert.ToInt32(line[0]),
                    Name = line[1],
                    Price = Convert.ToDecimal(line[2])
                };

                _singletonData.entities.Add(product);
            }
        }

        public override Product Get(int id)
        {

            if (_singletonData.entities.Count > 0)
            {
                return _singletonData.entities.FirstOrDefault(c => c.Id == id);
            }


            var lines = ReadTxt(_path);
            FillList(lines);
            return _singletonData.entities.FirstOrDefault(c => c.Id == id);
        }

        public override List<Product> GetList()
        {
            if (_singletonData.entities.Count > 0)
            {
                return _singletonData.entities;
            }

            else
            {
                var lines = ReadTxt(_path);
                FillList(lines);
                return _singletonData.entities;
            }
        }

        public override void Update(int id, Product entity)
        {
            if (_singletonData.entities.Count > 0)
            {
                Product productUpdated = _singletonData.entities.FirstOrDefault(c => c.Id == id);
                productUpdated.Id = entity.Id;
                productUpdated.Name = entity.Name;
                productUpdated.Price = entity.Price;

                UpdateTxt(id, entity);
            }
        }

        public override void Delete(int id)
        {
            if (_singletonData.entities.Count > 0)
            {
                Product productDeleted = _singletonData.entities.FirstOrDefault(c => c.Id == id);
                _singletonData.entities.Remove(productDeleted);
                DeleteTxt(id);
            }
        }
    }
}
