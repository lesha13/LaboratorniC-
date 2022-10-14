using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ToysJSON
{
    public class Toy
    {
        public string name { get; set; }
        public float price { get; set; }
        public int[] age { get; set; }

        public Toy(string name, float price, int age1, int age2)
        {
            this.name = name;
            this.price = price;
            this.age = new int[] { age1, age2 };
        }

        public Toy()
        {

        }

        public override string ToString()
        {
            return $"Toy: '{name}' for {price}$ for {age[0]}-{age[1]} aged kids";
        }
    }
    public class Toys
    {
        public List<Toy> toys = new List<Toy>();

        public Toys()
        {

        }

        public void Add(string name, float price, int age1, int age2)
        {
            toys.Add(new Toy(name, price, age1, age2));
        }

        public void CreatePO(string filename)
        {
            string json = JsonSerializer.Serialize(toys);

            File.WriteAllText(filename, json);
        }

        public void ReadPO(string filename)
        {
            string json = File.ReadAllText(filename);
            this.toys = JsonSerializer.Deserialize<List<Toy>>(json);
        }

        public void Delete()
        {
            float maxPrice = this.toys.Max(x => x.price);
            this.toys = this.toys.Where(elem => elem.price < maxPrice).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Льоша\source\repos\ToysJSON\json1.json";

            Toys toys = new Toys();
            toys.Add("Tetris", 200, 1, 99);
            toys.Add("Football", 100, 1, 99);
            toys.Add("Basketball", 120, 12, 16);
            toys.Add("VideGame", 300, 12, 16);
            toys.Add("Paint", 50, 12, 16);
            toys.Add("GTA", 150, 12, 16);

            toys.CreatePO(fileName);

            Toys toys2 = new Toys();
            toys2.ReadPO(fileName);

        
            foreach (Toy toy in toys2.toys)
            {
                Console.WriteLine(toy.ToString());  
            }

            toys2.Delete();

            foreach (Toy toy in toys2.toys)
            {
                Console.WriteLine(toy.ToString());
            }
            Console.WriteLine();

            var task = toys.toys
                .GroupBy(group => $"{group.age[0]}-{group.age[1]}")
                .Select(item => new { item.Key, Value = item.Count() });

            foreach (var item in task)
            {
                Console.WriteLine($"Age: {item.Key}, number o toys: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
