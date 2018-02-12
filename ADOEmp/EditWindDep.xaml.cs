using System.Data;
using System.Windows;


namespace ADOEmp
{
    /// <summary>
    /// Логика взаимодействия для EditWindDep.xaml
    /// </summary>
    public partial class EditWindDep : Window
    {
        public DataRow resultRow { get; set; }

        public EditWindDep(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameDepTextBox.Text = resultRow["Name"].ToString();
        }

        private void saveButtonDep_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = nameDepTextBox.Text;
            DialogResult = true;
        }

        private void cancelButtonDep_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
