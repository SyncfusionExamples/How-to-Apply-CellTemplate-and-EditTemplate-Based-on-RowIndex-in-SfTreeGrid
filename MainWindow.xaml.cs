﻿using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfTreeGrid_WPF_NET60
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            CustomCellTemplateSelector.SfTreeGridCell = this.treeGrid;
            CustomEditTemplateSelector.SfTreeGridEdit = this.treeGrid;
        }
    }

    public class EmployeeInfo
    {
        int _id;
        string _firstName;
        string _lastName;
        private string _title;
        double? _salary;
        int _reportsTo;
        string _country;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private object _selectedItemcombo;

        public object SelectedComboItem
        {
            get { return _selectedItemcombo; }
            set { _selectedItemcombo = value; }
        }
        
        public ObservableCollection<object> ComboBoxItems { get; set; } = new ObservableCollection<object>() { "United States", "Canada", "Australia", "Brazil", "Germany", "France" };

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int ReportsTo
        {
            get { return _reportsTo; }
            set { _reportsTo = value; }
        }
    }


    public class ViewModel
    {
        public ViewModel()
        {
            this.Employees = this.GetEmployees();
        }
        private ObservableCollection<EmployeeInfo> _employees;

        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private ObservableCollection<EmployeeInfo> GetEmployees()
        {
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = "Joseph",Country = "United States", ReportsTo = -1, ID = 2 });
            employeeDetails.Add(new EmployeeInfo() {  FirstName = "John", LastName = "Adams",Country = "Canada", ReportsTo = -1, ID = 3 });
            employeeDetails.Add(new EmployeeInfo() {  FirstName = "Thomas", LastName = "Jefferson",Country = "Australia", ReportsTo = -1, ID = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Madison",Country = "Brazil", ReportsTo = -1, ID = 5 });
            employeeDetails.Add(new EmployeeInfo() {  FirstName = "Ulysses", LastName = "Pierce",Country = "Germany", ReportsTo = -1, ID = 6 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Jimmy", LastName = "Harrison",Country = "France", ReportsTo = -1, ID = 7 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ronald", LastName = "Fillmore",Country = "Canada", ReportsTo = -1, ID = 8 });
            //Management

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", ID = 9 ,Country = "Canada", ReportsTo = 2});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", ID = 10, Country = "Australia", ReportsTo = 2});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", ID = 11, Country = "United States", ReportsTo = 2 });

            //Accounts
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ID = 12, ReportsTo = 3, Country = "Canada"});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 13, ReportsTo = 3, Country = "United States" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 14, Country = "Australia", ReportsTo = 3 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", Country = "Brazil", ID = 15, ReportsTo = 3 });

            //Sales
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Laura", LastName = "Callahan", ID = 16, ReportsTo = 4, Country = "Canada" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", ID = 17, Country = "United States", ReportsTo = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", ID = 18, Country = "Australia", ReportsTo = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Tim", LastName = "Smith", ID = 19, ReportsTo = 4, Country = "Canada" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", ID = 20, Country = "Brazil", ReportsTo = 4 });

            //Back Office
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", ID = 21, Country = "United States", ReportsTo = 5 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = "Martin", ID = 22, Country = "Australia", ReportsTo = 5 });

            //HR
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = "Pereira", ID = 23, Country = "Canada", ReportsTo = 6 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Syed", LastName = "Abbas", ID = 24, Country = "Australia", ReportsTo = 6});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", Country = "United States", ID = 25, ReportsTo = 6});

            //Purchasing

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Pamela", LastName = "Ansman-Wolfe", Country = "United States", ID = 26, ReportsTo = 7});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", ID = 27, Country = "Canada", ReportsTo = 7 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "David", LastName = "Campbell", ID = 28, Country = "Australia", ReportsTo = 7});

            //Production
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Jillian", LastName = "Carson", ID = 29, Country = "Canada", ReportsTo = 8});
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Shu", LastName = "Ito", ID = 30, Country = "Brazil", ReportsTo = 8 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Stephen", LastName = "Jiang", ID = 31, Country = "Canada", ReportsTo = 8 });

            return employeeDetails;
        }
    }

    public class CustomEditTemplateSelector : DataTemplateSelector
    {
        public static SfTreeGrid SfTreeGridEdit { get; set; }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {

            if (item == null)
                return null;
            var data = item as EmployeeInfo;
            var recordRowIndex = (SfTreeGridEdit.DataContext as ViewModel).Employees.IndexOf(data);
            var rowIndex = SfTreeGridEdit.ResolveToRowIndex(recordRowIndex);
            if (rowIndex == 1 || rowIndex == 3)
                return Application.Current.MainWindow.FindResource("DefaultEditTemplate") as DataTemplate;

            else
                return Application.Current.MainWindow.FindResource("AlternateEditTemplate") as DataTemplate;
        }
    }

    public class CustomCellTemplateSelector : DataTemplateSelector
    {
        public static SfTreeGrid SfTreeGridCell { get; set; }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item == null)
                return null;
            var data = item as EmployeeInfo;
            var recordRowIndex = (SfTreeGridCell.DataContext as ViewModel).Employees.IndexOf(data);
            var rowIndex = SfTreeGridCell.ResolveToRowIndex(recordRowIndex);
            if (rowIndex == 1 || rowIndex == 3)
                return Application.Current.MainWindow.FindResource("DefaultCellTemplate") as DataTemplate;

            else
                return Application.Current.MainWindow.FindResource("AlternateCellTemplate") as DataTemplate;
        }
    }
}