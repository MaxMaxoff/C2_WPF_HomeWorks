using System.Collections.Generic;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Department Class
    /// </summary>
    public class Department
    {

        private List<Employee> _department;

        /// <summary>
        /// Property 
        /// </summary>
        public List<Employee> Employees
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
            _department.Remove(employee);
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
