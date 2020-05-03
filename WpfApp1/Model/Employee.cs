using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    public class Employee
    {
        #region Fields
        private float[] _salary;
        #endregion

        #region Constructor
        public Employee()
        {
        }

        public Employee(Employee employee)
        {
            Surname = employee.Surname;
            DepartmentName = employee.DepartmentName;
            Salary = employee.Salary;
        }
        #endregion

        #region Properties

        public string Surname { get; set; }

        public string DepartmentName { get; set; }

        public string Salary
        {
            get => string.Join(", ", _salary);
            set => _salary = Array.ConvertAll(value.Split(new[] { ", ", }, StringSplitOptions.RemoveEmptyEntries), float.Parse);
        }
        #endregion

        #region Indexer
        public float this[int i]
        {
            get
            {
                return _salary[i];
            }

            set
            {
                _salary[i] = value;
            }
        }
        #endregion

        #region Methods
        public static List<(string, float)> SearchMaxSalary(List<(string, float)> tempItem)
        {
            for (int i = 0; i < tempItem.Count; i++)
            {
                for (int j = i + 1; j < tempItem.Count; j++)
                {
                    if (tempItem[i].Item1 == tempItem[j].Item1)
                    {
                        if (tempItem[i].Item2 > tempItem[j].Item2)
                        {
                            tempItem.RemoveAt(j);
                        }
                        else
                        {
                            tempItem.RemoveAt(i);
                        }
                    }
                }
            }

            return tempItem;
        }

        public static List<Employee> Sorting(List<Employee> temp) => temp.OrderBy(i => i._salary.Average()).ToList();

        public (string, float) CheckAverageSalaryForHalfYear() => (Surname, _salary.Average());

        public (string, float) CheckMaxSalaryForHalfYear() => (DepartmentName, _salary.Max());
        #endregion
    }
}