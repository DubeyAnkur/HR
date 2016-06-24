using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
//using System.Net.Http.HttpMessageInvoker

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
                            temp.Quantity = Convert.ToInt32(qty);
                            ret.Add(temp);
                        }
                        else
                        {
                            temp.Quantity += Convert.ToInt32(qty);
                        }
                        //Console.WriteLine(row1Col0);
                    }
                }
            }
            ret.Sort(delegate (Item c1, Item c2) { return c2.Quantity.CompareTo(c1.Quantity);});
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(ret[i].SKU + ':' + ret[i].Quantity);
            }
            Console.ReadLine();

        }
        public void PurchaseTarget()
        {
            string FileName = @"C:\Users\aisadmin\Desktop\Stamps\wineoutlet-data\order-by-transaction\all-data-in-one-file.xls";
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'";

            List<Sales> ret = new List<Sales>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sum$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                        {
                            DateTime dt = Convert.ToDateTime(dr[0]);
                            decimal qty = Convert.ToDecimal(dr[1]);
                            Sales itm = new Sales();
                            itm.saleDate = dt;
                            itm.Revenue = qty;
                            ret.Add(itm);
                        }
                    }
                }
            }
            var dict = ret.GroupBy(x => new { Month = x.saleDate.Month, Year = x.saleDate.Year }).ToDictionary(g => g.Key, g => g.Sum(x => x.Revenue));
            string str = "";
            foreach (var x in dict)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine(x.Value);
                str = str + x.Key.Year + "\t" + x.Key.Month + "\t" + x.Value + Environment.NewLine;
            }
        }

        public void PopularWinesByMonth()
        {
            string FileName = @"C:\Users\aisadmin\Desktop\Stamps\wineoutlet-data\order-by-product\all-data-in-one-file.xls";
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'";

            List<Item> ret = new List<Item>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [June15$]", connection);
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
                            temp.Quantity = Convert.ToInt32(qty);
                            ret.Add(temp);
                        }
                        else
                        {
                            temp.Quantity += Convert.ToInt32(qty);
                        }
                        //Console.WriteLine(row1Col0);
                    }
                }
            }
            ret.Sort(delegate (Item c1, Item c2) { return c2.Quantity.CompareTo(c1.Quantity); });
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(ret[i].SKU + ':' + ret[i].Quantity);
            }
            Console.ReadLine();
        } 

        public void TryDownload()
        {
            string urlAddress = "http://208.72.24.81:80/sku11116.html";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response;

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
        }

        public async void CURL()
        {
            var client = (HttpWebRequest)WebRequest.Create("http://www.wineoutlet.com/sku11110.html");
            client.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            client.CookieContainer = new CookieContainer();
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            var response = client.GetResponse() as HttpWebResponse;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
        }
    }

    public class Item
    {
        public string SKU;
        public int Quantity;
        public int Cost;
    }

    public class Sales
    {
        public DateTime saleDate ;
        public decimal Revenue;
    }
}
