using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class StatsCalc
    {
        public void MostPurchasedSKU()
        {
            string FileName = @"C:\Users\aisadmin\Desktop\Stamps\wineoutlet-data\order-by-product\all-data-in-one-file.xls";
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'";

            List<Item> ret = new List<Item>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string sku = dr[0].ToString();
                        var qty = dr[2];

                        Item temp = ret.FirstOrDefault(i => i.SKU == sku);
                        if (temp == null)
                        {
                            temp = new Item();
                            temp.SKU = sku;
                            temp.Quantity = (int)qty;
                            ret.Add(temp);
                        }
                        else
                        {
                            temp.Quantity += (int)qty;
                        }
                        //Console.WriteLine(row1Col0);
                    }
                }
            }
            //ret.Sort();
        }

        
    }
    public class Item
    {
        public string SKU;
        public int Quantity;
        public int Cost;
    }
}
