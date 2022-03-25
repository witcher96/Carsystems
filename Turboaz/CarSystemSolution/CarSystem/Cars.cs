using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    public class Cars
    {
        static int counter;
        public Cars()
        {
            this.Id = ++counter;
        }
        public int Id { get; private set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int Engine { get; set; }

        public enum Fueltype 
        {
            gasoline,
            diesel,
            fullelectric,
            hybrid
        }
        public override string ToString()
        {
            return $"{Id}  İl: {Year} Qiymət: {Price} Rəng: {Color} Mühərrik: {Engine} ModelID: {ModelId}";
        }
    }
}
