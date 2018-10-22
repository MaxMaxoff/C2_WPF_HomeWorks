using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<Department> _company;
        
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
            // lbxEmployees.ItemsSource = _company[lbxDepartments.SelectedIndex].Employees;
        }

        /// <summary>
        /// Method Load Data
        /// </summary>
        private void LoadData()
        {
            if (_company is null)
            {
                _company = new ObservableCollection<Department>();

                for (int j = 0; j < 4; j++)
                    _company.Add(new Department($"Department_{j}", j));

                foreach (var department in _company)
                {
                    int qty = rnd.Next(1, 10);
                    for (int i = 0; i < qty; i++)
                        department.Add(new Employee($"{department.Name}_{i}", department.Number * 10 + i,
                            $"{department.Name}_{i}", rnd.Next(1000, 5000)));
                }
            }
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

                form.Closed += delegate { UpdateLbxEmployees(); };

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
        private void btnNewEmp_Click()
        {
            try
            {
                if (lbxDepartments.SelectedIndex > -1)
                {
                    fmEdit form = new fmEdit();
                    form.cbDepartment.ItemsSource = _company;
                    form.cbDepartment.SelectedIndex = lbxDepartments.SelectedIndex;

                    form.Closed += delegate { UpdateLbxEmployees(); };

                    form.Show();
                } else MessageBox.Show("Не выбран отдел!");

            }
            catch (Exception e)
            {
                MessageBox.Show("Не выбран отдел!");
                //Console.WriteLine(e);
                //throw;
            }
        }

        /// <summary>
        /// Method Update listbox Department
        /// </summary>
        private void UpdateLbxDepartment()
        {
            {
                try
                {
                    lbxDepartments.ItemsSource = null;
                    lbxDepartments.ItemsSource = _company;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    //throw;
                }

            }
        }

        /// <summary>
        /// Method Update listbox Employees
        /// </summary>
        private void UpdateLbxEmployees()
        {
            try
            {
                lbxEmployees.ItemsSource = null;
                lbxEmployees.ItemsSource = _company[lbxDepartments.SelectedIndex].Employees;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }

        }

        /// <summary>
        /// Method new Department
        /// </summary>
        private void btnDep_Click()
        {
            if (_company is null)
                btnLoad_Click();
                //LoadData();

            try
            {
                fmDep form = new fmDep();

                form.DepartmentID = lbxDepartments.SelectedIndex;

                form.tbName.Text = _company[lbxDepartments.SelectedIndex].Name;
                form.tbNumber.Text = _company[lbxDepartments.SelectedIndex].Number.ToString();
                
                form.Closed += delegate{UpdateLbxDepartment();};

                form.Show();
            }
            catch (Exception e)
            {
                fmDep form = new fmDep();

                form.DepartmentID = lbxDepartments.SelectedIndex;

                form.Show();
            }
        }

        /// <summary>
        /// Method for Update listbox Employees
        /// </summary>
        private void lbxDepartment_SelectItem()
        {
            try
            {
                lbxEmployees.ItemsSource = _company[lbxDepartments.SelectedIndex].Employees;
            }
            catch (Exception e) 
            {
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
            btnNewEmp.Click += delegate { btnNewEmp_Click(); };
            btnDep.Click += delegate { btnDep_Click(); };
        }

        /// <summary>
        /// Method on Event OnMouseDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbxEmployees_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit_Click();
        }

        private void LbxDepartment_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnDep_Click();
        }
    }
}
