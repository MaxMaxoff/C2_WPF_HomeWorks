using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Interaction logic for fmMain.xaml
    /// </summary>
    public partial class fmMain : Window
    {
        /// <summary>
        /// List of Departments
        /// </summary>
        public static List<Department> _company;
        
        private Random rnd = new Random();

        /// <summary>
        /// Method Click on btnLoad
        /// </summary>
        private void btnLoad_Click()
        {
            lbxEmployees.ItemsSource = null;
            lbxDepartments.ItemsSource = null;

            LoadData();
          
            lbxDepartments.ItemsSource = _company;
        }

        /// <summary>
        /// Method Load Data
        /// </summary>
        private void LoadData()
        {
            _company = new List<Department>();

            for (int j = 0; j < 4; j++)
                _company.Add(new Department($"Department_{j}", j));
            
            foreach (var department in _company)
            {
                int qty = rnd.Next(1, 10);
                for (int i = 0; i < qty; i++)
                    department.Add(new Employee($"{department.Name}_{i}", department.Number * 10 + i, $"{department.Name}_{i}", rnd.Next(1000, 5000)));
            }
        }

        /// <summary>
        /// Method Select Item in lbxDepartment
        /// </summary>
        private void lbxDepartment_SelectItem()
        {
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = _company[lbxDepartments.SelectedIndex].Employees;
        }
        
        /// <summary>
        /// Method Update listbox Employees
        /// </summary>
        public void UpdateLbxEmployees()
        {
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = _company[lbxDepartments.SelectedIndex].Employees;
        }

        /// <summary>
        /// Method Edit Employee
        /// </summary>
        private void btnEdit_Click()
        {
            try
            {
                fmEdit form = new fmEdit();
                form.DepartmentID = lbxDepartments.SelectedIndex;
                form.EmployeeID = lbxEmployees.SelectedIndex;
                form.tbName.Text = _company[lbxDepartments.SelectedIndex].Employees[lbxEmployees.SelectedIndex].Name;
                form.tbNumber.Text = _company[lbxDepartments.SelectedIndex].Employees[lbxEmployees.SelectedIndex].Number.ToString();
                form.tbPosition.Text = _company[lbxDepartments.SelectedIndex].Employees[lbxEmployees.SelectedIndex].Position;
                form.tbSalary.Text = _company[lbxDepartments.SelectedIndex].Employees[lbxEmployees.SelectedIndex].Salary.ToString();
                form.cbDepartment.ItemsSource = _company;
                form.cbDepartment.SelectedIndex = lbxDepartments.SelectedIndex;

                form.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не выбран сотрудник!");
                //Console.WriteLine(e);
                //throw;
            }
        }

        /// <summary>
        /// Method new employee
        /// </summary>
        private void btnNew_Click()
        {
            try
            {
                fmEdit form = new fmEdit();
                form.cbDepartment.ItemsSource = _company;
                form.Show();

                form.Closed += delegate { UpdateLbxEmployees(); };
            }
            catch (Exception e)
            {
                MessageBox.Show("Не выбран сотрудник!");
                //Console.WriteLine(e);
                //throw;
            }
        }

        public fmMain()
        {
            InitializeComponent();

            btnLoad.Click += delegate { btnLoad_Click(); };

            lbxDepartments.SelectionChanged += delegate { lbxDepartment_SelectItem(); };

            btnEdit.Click += delegate { btnEdit_Click(); };
            btnNew.Click += delegate { btnNew_Click(); };
        }

        /// <summary>
        /// Method on Event OnMouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbxEmployees_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit_Click();
            // MessageBox.Show("Double Click");
        }
    }
}
