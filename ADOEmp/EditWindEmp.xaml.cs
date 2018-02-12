
using System.Windows;
using System.Data;


namespace ADOEmp
{
    /// <summary>
    /// Логика взаимодействия для EditWindEmp.xaml
    /// </summary>
    public partial class EditWindEmp : Window
    {
        public DataRow resultRow { get; set; }

        public EditWindEmp(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    nameDepTextBox.Text = resultRow["FIO"].ToString();
        //    birthdayTextBox.Text = resultRow["Birthday"].ToString();
        //    emailTextBox.Text = resultRow["Email"].ToString();
        //    phoneTextBox.Text = resultRow["Phone"].ToString();
        //}
    }
}
