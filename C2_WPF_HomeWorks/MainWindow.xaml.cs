using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// List of Departments
        /// </summary>
        // private Company _company;
        private List<Department> _company;

        private Random rnd = new Random();

        /// <summary>
        /// Method Click on btnLoad
        /// </summary>
        private void btnLoad_Click()
        {
            // _company = new Company();
            _company = new List<Department>();
            _company.Add(new Department("IT", 1));
            _company.Add(new Department("Accounting", 2));
            _company.Add(new Department("Sales", 3));
            _company.Add(new Department("Administration", 4));

            foreach (var department in _company)
            {
                MessageBox.Show(department.Name.ToString());
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            btnLoad.Click += delegate
            {
                btnLoad_Click();
            };
        }
    }
}
