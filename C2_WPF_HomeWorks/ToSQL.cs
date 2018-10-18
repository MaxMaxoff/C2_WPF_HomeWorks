using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_WPF_HomeWorks
{
    //class ToSQL
    //{
    //    private void CreateCompany()
    //    {
    //        int numberOfStartDeps = 10;
    //        int numberOfStartEmployees = 10;
    //        try
    //        {
    //            var random = new Random();
    //            for (var i = 0; i < numberOfStartDeps; i++)
    //            {
    //                var department = new Department($"Отдел_{random.Next(0, 100)}");
    //                var sql = $@"INSERT INTO Departments (Name)
    //                    VALUES(N'{department.DepartmentName}')";
    //                SomeDatabaseShit.NonQueryCommand(sql, connectionString);
    //            }
    //            for (var i = 0; i < numberOfStartDeps; i++)
    //            {
    //                for (int j = 0; j < numberOfStartEmployees; j++)
    //                {
    //                    var employee = new Employee(
    //                        $"Имя_{random.Next(0, 100)}",
    //                        $"Фам_{random.Next(0, 100)}",
    //                        random.Next(0, 100),
    //                        random.Next(1, numberOfStartDeps));
    //                    var sql = $@"INSERT INTO Employees(Name,Surname,Salary,id_Department)
    //                        VALUES(N'{employee.EmployeeName}',
    //                            N'{employee.EmployeeSurname}',
    //                              {employee.Salary},
    //                              {employee.DepartmentName})";
    //                    SomeDatabaseShit.NonQueryCommand(sql, connectionString);
    //                }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}
}
