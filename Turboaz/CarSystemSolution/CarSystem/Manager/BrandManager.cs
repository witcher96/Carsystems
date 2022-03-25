using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Manager
{
    public class BrandManager
    {
        Brands [] data = new Brands [0];
        public void Add(Brands entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public Brands[] GetAll()
        {
            return data;
        }
        public void Remove(Brands entity)
        {
            int index=Array.IndexOf(data, entity);
            if (index == -1)
                return;
            for(int i = index; i< data.Length - 1; i++)
            {
                data[i] = data[i+1];
            }
            if (data.Length > 0)
                Array.Resize(ref data, data.Length - 1);
        }
        public void Edit(Brands entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
                return;

            data[index] = entity;
        }
    }
}
