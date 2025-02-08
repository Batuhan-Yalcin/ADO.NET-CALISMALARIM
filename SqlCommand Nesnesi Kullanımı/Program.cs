using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommand_Nesnesi_Kullanımı
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Login table tablosunda ki kayıtları çekip burada konsola yazdıracağız..

            // Veri tabanı bağlantısını aktif ettik.
            SqlConnection connection = new SqlConnection("data source=BATUHAN;Initial Catalog=adonet;User ID=sa; password=1;Trust Server Certificate=True");

            // Sql Command = Bizim SQL de Yazdığımız sorguların aynısıdır. Yani sorgulama işlemi görür..

            // Logintable tablosunu seç connection yazma sebebimiz hangi bağlantıya select atacağını göstermiş olduk
            SqlCommand cmd = new SqlCommand("select * from loginTable",connection);
      


        }
    }
}
