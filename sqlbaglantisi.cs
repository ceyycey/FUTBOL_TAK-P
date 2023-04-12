using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BAA_FUTBOLCU_TAKİP
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {

            SqlConnection baglan=new SqlConnection("Data Source = LAPTOP-NLUCOQ76\\SQLEXPRESS; Initial Catalog = BAA_FUTBOLCU; Integrated Security = True");
            baglan.Open();
            return baglan;

        }




    }
}
