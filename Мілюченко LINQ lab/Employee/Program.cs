using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Program
    {
        public class Employee
        {
            protected double id;
            public double Id { get { return id; } set { id = value; } }
            // { get; set; } в цьому випадку не працює тому що атрибут повертає інший атрибут

            protected string name;
            public string Name { get { return name; } set { name = value; } }

            protected char sex;
            public char Sex { get { return sex; } set { sex = ((value == 'M' || value == 'F') ? value : 'U'); } }

            protected string departmnent;
            public string Departmnent { get { return departmnent; } set { departmnent = value; } }

            protected string position;
            public string Position { get { return position; } set { position = value; } }

            protected float experience;
            public float Experience { get { return experience; } set { experience = (value >= 0 ? value : 0); } }

            protected float salary;
            public float Salary { get { return salary; } set { salary = (value >= 0 ? value : 0); } }


            public Employee(int id, string name, char sex, string departmnent, string position, float experience, float salary)
            {
                this.id = id;
                this.name = name;
                this.sex = sex;
                this.departmnent = departmnent;
                this.position = position;
                this.experience = experience;
                this.salary = salary;
            }

            public override string ToString()
            {
                return $"Employee {name} working in {departmnent} department on {position} position. Experience: {experience} years, salary: {salary}$";
            }
        }

        public interface IListEmployees
        {
            void Add(Employee employee);
            void Delete(int id);
            void EditExperience(int id, float experience);
            void EditSalary(int id, float salary);
            void Show();
        }

        public class ListEmployees : IListEmployees
        {
            protected List<Employee> employees;
            public List<Employee> Employees { get { return employees; } set { employees = value; } }

            public ListEmployees(List<Employee> employees)
            {
                this.employees = employees;
            }

            public void Add(Employee employee)
            {
                employees.Add(employee);
            }
            public void Delete(int id)
            {
                try
                {
                    employees = employees.Where(item => item.Id != id).ToList();
                }
                catch (Exception exexception)
                {
                    Console.WriteLine(exexception.Message);
                    Console.WriteLine("Smth wrong, check the id.");
                }
            }
            public void EditExperience(int id, float experience)
            {
                try
                {
                    employees.First(item => item.Id == id).Experience = experience;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Smth wrong, check the id.");
                }
            }
            public void EditSalary(int id, float salary)
            {
                try
                {
                    employees.First(item => item.Id == id).Salary = salary;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Smth wrong, check the id.");
                }
            }
            public void Show()
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            ListEmployees workers = new ListEmployees(
                new List<Employee>
                {
                    new Employee(1, "Bob", 'M', "It", "Developer", 10, 10000),
                    new Employee(2, "Hank", 'M', "Finance", "Analyst", 5, 6000),
                    new Employee(3, "Todd", 'M', "Sales", "Manager", 12, 12000),
                    new Employee(4, "Olivia", 'F', "It", "Developer", 15, 16000),
                    new Employee(5, "Emma", 'F', "It", "Developer", 9, 8000),
                    new Employee(6, "Grace", 'F', "Sales", "SMM", 10, 11000),
                }
            );

            /* test */

            workers.Show();
            workers.Add(new Employee(7, "Jack", 'M', "It", "Team lead", 20, 20000));
            workers.Show();
            workers.Delete(7);
            workers.Delete(42);
            workers.Show();
            workers.EditExperience(3, 13);
            workers.Show();
            workers.EditSalary(3, 13000);
            workers.Show();
            workers.EditExperience(42, 42);
            workers.EditSalary(42, 42);


            var task1 = workers.Employees.Where(item => item.Sex == 'F' && item.Departmnent == "It");
            float taskAvg = task1.Average(item => item.Salary);

            Console.WriteLine();
            Console.WriteLine($"Avg female salary in It department: {taskAvg}");
            Console.WriteLine();


            var task2 = workers.Employees.GroupBy(group => group.Departmnent).Select(item => new { item.Key, Value = item.Count() });

            foreach (var item in task2)
            {
                Console.WriteLine($"Department: {item.Key}, number of employees: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
