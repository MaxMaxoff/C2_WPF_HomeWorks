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
    /// Interaction logic for fmDep.xaml
    /// </summary>
    public partial class fmDep : Window
    {
        public int DepartmentID = -1;

        /// <summary>
        /// Method on Event
        /// </summary>
        private void btnSave_Click()
        {
            if (DepartmentID == -1)
            {
                fmMain._company.Add(new Department($"{tbName.Text}", Convert.ToInt32(tbNumber.Text)));
            }
            else
            {
                fmMain._company[DepartmentID].Name = tbName.Text;
                fmMain._company[DepartmentID].Number = Convert.ToInt32(tbNumber.Text);
            }

            this.Close();
        }

        public fmDep()
        {
            InitializeComponent();

            btnSave.Click += delegate { btnSave_Click(); };
        }
    }
}
