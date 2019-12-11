using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Spark
{
    /// <summary>
    /// Interaction logic for Satis.xaml
    /// </summary>
    public partial class Satis : UserControl
    {
        public Satis()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=prog_kassa;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblproducts", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            List<Person> people = new List<Person>();
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            people.Add(new Person { Id = 1, Name = "Murad", SurnameSurname = "Suleymanov" });
            adp.Fill(dataTable);
            dtg_Selling.ItemsSource = null;
            dtg_Selling.ItemsSource = people;
        }
    }
}
