using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Department Class
    /// </summary>
    public class Department
    {

        private ObservableCollection<Employee> _department;

        /// <summary>
        /// Property 
        /// </summary>
        public ObservableCollection<Employee> Employees
        {
            get { return _department; }
        }

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
            _department = new ObservableCollection<Employee>();
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
            _department.Remove(employee);
        }

        /// <summary>
        /// Method Change Department for Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        /// <returns></returns>
        public Employee ChangeDepartment(Employee employee)
        {
            _department.Remove(employee);
            return employee;
        } 

        public override string ToString()
        {
            return $"{Number}: {Name}";
        }
    }
}
