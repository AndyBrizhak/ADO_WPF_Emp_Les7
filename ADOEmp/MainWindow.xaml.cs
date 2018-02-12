using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace ADOEmp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dtDep;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = Properties.Settings.Default.ADOEmpConnectionString;
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
            SqlCommand commandDep = new SqlCommand("SELECT Id, Name", connection );
            adapter.SelectCommand = commandDep;

            //insert
            commandDep = new SqlCommand(@"INSERT INTO Dep (Name) VALUES (@Name); SET @Id = @@IDENTITY;", connection);
            commandDep.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            SqlParameter param = commandDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = commandDep;
        }

        private void addButtonDep_Click(object sender, RoutedEventArgs e)
        {
            // добавим новую строку
            DataRow newRow = dtDep.NewRow();
            EditWindDep editWindow = new EditWindDep(newRow);
        }
    }
}
