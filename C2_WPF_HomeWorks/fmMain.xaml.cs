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
        private List<Department> _company;
        
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
        /// Method Select Item in lbxEmployees
        /// </summary>
        private void lbxEmployees_SelectItem()
        {

        }

        private void ChangeDepartment()
        {
            // _company[]
        }

        public fmMain()
        {
            InitializeComponent();

            btnLoad.Click += delegate { btnLoad_Click(); };

            lbxDepartments.SelectionChanged += delegate { lbxDepartment_SelectItem(); };

            // lbxEmployees.SelectionChanged += delegate { lbxEmployees_SelectItem(); };

            // lbxEmployees.MouseDoubleClick += delegate { LbxEmployees_OnMouseDoubleClick(object, new MouseButtonEventArgs()); };

            // lbxEmployees.dra
        }

        private void LbxEmployees_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double Click");
        }
    }
}
