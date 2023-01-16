using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;        /*SQL  ULASMAK ICIN KUTUPHANE EKLENDI*/

namespace TicariOtomasyon
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            // Data Source=DESKTOP-7AP9EA1;Initial Catalog=DboTicariOtomasyon;Integrated Security=True

            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-7AP9EA1;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
