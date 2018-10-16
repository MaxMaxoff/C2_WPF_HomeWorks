using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Department Class
    /// </summary>
    public class Department : IEnumerable
    {

        List<Employee> _department;

        /// <summary>
        /// Properties Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Properties Department Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        public Department()
        {
            _department = new List<Employee>();
        }

        /// <summary>
        /// Extended ctor
        /// </summary>
        /// <param name="name">Name of the Department</param>
        /// <param name="number">Number of the Department</param>
        public Department(string name, int number) : this()
        {
            Name = name;
            Number = number;
        }

        /// <summary>
        /// Method Add
        /// </summary>
        /// <param name="employee">Employee</param>
        public void Add(Employee employee)
        {
            _department.Add(employee);
        }

        /// <summary>
        /// Method Remove
        /// </summary>
        /// <param name="employee">Employee</param>
        public void Remove(Employee employee)
        {
            _department.RemoveAt(_department.IndexOf(employee));
        }

        /// <summary>
        /// Method Get By Number
        /// </summary>
        /// <param name="number">Employee number</param>
        /// <returns>Employee</returns>
        public Employee GetByNumber(int number)
        {
            return _department.Find(x => x.Number == number);
        }

        /// <summary>
        /// Method Get By Name
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <returns>Employee</returns>
        public Employee GetByName(string name)
        {
            return _department.Find(x => x.Name == name);
        }

        /// <summary>
        /// Method Find By Part Of Name
        /// </summary>
        /// <param name="partOfName">part of Employee name</param>
        /// <returns>list of Employees</returns>
        public List<Employee> FindByPartOfName(string partOfName)
        {
            return _department.FindAll(x => x.Name.Contains(partOfName));
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Name).GetEnumerator();
        }
    }
}
