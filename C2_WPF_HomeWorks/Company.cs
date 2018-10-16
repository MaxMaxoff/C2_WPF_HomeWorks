using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Departments Class
    /// </summary>
    class Company : IEnumerable
    {
        List<Department> _company;

        /// <summary>
        /// Default ctor
        /// </summary>
        public Company()
        {
            _company = new List<Department>();
        }

        /// <summary>
        /// Method Add
        /// </summary>
        /// <param name="department">Department</param>
        public void Add(Department department)
        {
            _company.Add(department);
        }

        /// <summary>
        /// Method Remove
        /// </summary>
        /// <param name="department">Department</param>
        public void Remove(Department department)
        {
            _company.RemoveAt(_company.IndexOf(department));
        }

        /// <summary>
        /// Method Get By Number
        /// </summary>
        /// <param name="number">Department number</param>
        /// <returns>Department</returns>
        public Department GetByNumber(int number)
        {
            return _company.Find(x => x.Number == number);
        }

        /// <summary>
        /// Method Get By Name
        /// </summary>
        /// <param name="name">Department name</param>
        /// <returns>Department</returns>
        public Department GetByName(string name)
        {
            return _company.Find(x => x.Name == name);
        }

        /// <summary>
        /// Method Find By Part Of Name
        /// </summary>
        /// <param name="partOfName">part of Department name</param>
        /// <returns>list of Departments</returns>
        public List<Department> FindByPartOfName(string partOfName)
        {
            return _company.FindAll(x => x.Name.Contains(partOfName));
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_company).GetEnumerator();
        }
    }
}
