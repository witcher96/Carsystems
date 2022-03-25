using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Manager
{
    public class ModelManager
    {
        Models[] data = new Models[0];
        public void Add(Models entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public Models[] GetAll()
        {
            return data;
        }
        public void Remove(Models entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
                return;
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
                Array.Resize(ref data, data.Length - 1);
        }
        public void Edit(Models entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
                return;

            data[index] = entity;
        }
    }
}
