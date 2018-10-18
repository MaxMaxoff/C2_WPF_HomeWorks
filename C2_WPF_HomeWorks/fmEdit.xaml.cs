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
using System.Windows.Shapes;

namespace C2_WPF_HomeWorks
{
    /// <summary>
    /// Interaction logic for fmEdit.xaml
    /// </summary>
    public partial class fmEdit : Window
    {
        public int DepartmentID = -1;
        public int EmployeeID = -1;

        private void btnSave_Click()
        {
            if (cbDepartment.SelectedIndex != DepartmentID && DepartmentID != -1)
                ChangeDepartment();

            fmMain._company[DepartmentID].Employees[EmployeeID].Name = tbName.Text;
            fmMain._company[DepartmentID].Employees[EmployeeID].Number = Convert.ToInt32(tbNumber.Text);
            fmMain._company[DepartmentID].Employees[EmployeeID].Position = tbPosition.Text;
            fmMain._company[DepartmentID].Employees[EmployeeID].Salary = Convert.ToInt32(tbSalary.Text);
            
            // this.OnClosing();
            this.Close();
            
        }

        private void ChangeDepartment()
        {
            fmMain._company[cbDepartment.SelectedIndex].Add(fmMain._company[DepartmentID].Employees[EmployeeID]);
            fmMain._company[DepartmentID].Remove(fmMain._company[DepartmentID].Employees[EmployeeID]);
            DepartmentID = cbDepartment.SelectedIndex;
        }

        public fmEdit()
        {
            InitializeComponent();

            btnSave.Click += delegate { btnSave_Click(); };
        }
    }
}
