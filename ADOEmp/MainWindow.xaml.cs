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
        SqlDataAdapter adapterDep;
        SqlDataAdapter adapterEmp;
        DataTable dtDep;
        DataTable dtEmp;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = Properties.Settings.Default.ADOEmpConnectionString;
            connection = new SqlConnection(connectionString);
            adapterDep = new SqlDataAdapter();
            adapterEmp = new SqlDataAdapter();

            SqlCommand commandDep = new SqlCommand("SELECT Id, Name", connection );
            adapterDep.SelectCommand = commandDep;

            SqlCommand commandEmp = new SqlCommand("SELECT Id, Name, NameDep", connection);
            adapterEmp.SelectCommand = commandEmp;

            //insert Dep
            commandDep = new SqlCommand(@"INSERT INTO Dep (Name) VALUES (@Name); SET @Id = @@IDENTITY;", connection);
            commandDep.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            SqlParameter paramDep = commandDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            paramDep.Direction = ParameterDirection.Output;
            adapterDep.InsertCommand = commandDep;

            //insert Emp
            commandEmp = new SqlCommand(@"INSERT INTO Emp (Name, NameDep) VALUES (@Name, NameDep); SET @Id = @@IDENTITY;", connection);
            commandEmp.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            commandEmp.Parameters.Add("@NameDep", SqlDbType.NVarChar, -1, "NameDep");
            SqlParameter paramEmp = commandEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            paramEmp.Direction = ParameterDirection.Output;
            adapterEmp.InsertCommand = commandEmp;


        }

        private void addButtonDep_Click(object sender, RoutedEventArgs e)
        {
            
            DataRow newRow = dtDep.NewRow();
            EditWindDep editWindow = new EditWindDep(newRow);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                dtDep.Rows.Add(editWindow.resultRow);
                adapterDep.Update(dtDep);
            }
        }
    }
}
