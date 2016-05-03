using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class ExcelCompare
    {
        public void Compare()
        {
            string File1 = "2WalkingDead.xls";
            string File2 = "3Treana.xls";
            var l1 = Compare(File1, File2);

            File1 = "3Treana.xls";
            File2 = "4InStoreAd.xls";
            var l2 = Compare(File1, File2);
            int count = 0;
            foreach (string str in l1)
            {
                if (l2.Contains(str))
                {
                    count++;
                }
            }
            Console.WriteLine("Result: " + count);
        }
        public List<string> Compare(string File1, string File2)
        {
            List<string> list1 = GetList(File1);
            List<string> list2 = GetList(File2);

            list1.Sort();
            list2.Sort();

            int count = 0;
            List<string> ret = new List<string>();

            foreach (string str in list1)
            {
                if(list2.Contains(str))
                {
                    count++;
                    ret.Add(str);
                }
            }
            Console.WriteLine("List 1:" + list1.Count);
            Console.WriteLine("List 2:" + list2.Count);
            Console.WriteLine(count);
            return ret;
        }


        public List<string> GetList(string FileName, string folder = @"C:\Users\aisadmin\Desktop\Export\", int col = 2)
        {
            string con =
  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + folder + FileName + ";" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'";

            List<string> ret = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row1Col0 = dr[col];
                        ret.Add(row1Col0.ToString().ToLower());
                        //Console.WriteLine(row1Col0);
                    }
                }
            }
            return ret;
        }

        public void FindNewContacts()
        {
            string folder = @"C:\Users\aisadmin\Desktop\NC\";
            List<string> l1 = GetList("Order.xls", folder, 0);
            List<string> l2 = GetList("CC.xls", folder);
            List<string> l3 = GetList("unSub.xls", folder);

            List<string> newContacts = new List<string>();
            int count = 0;
            foreach (string s in l1)
            {
                if (!l2.Contains(s))
                {
                    count++;
                    newContacts.Add(s);
                }
            }
            Console.WriteLine(count);
            count = 0;

            List<string> brandNew = new List<string>();
            foreach (string s in newContacts)
            {
                if (!l3.Contains(s) && !brandNew.Contains(s))
                {
                    count++;
                    brandNew.Add(s);
                }
            }
            Console.WriteLine("Missed = " + count);
            using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(@"C:\Users\aisadmin\Desktop\NC\BN.txt"))
            {
                foreach (string line in brandNew)
                {
                    file.WriteLine(line);
                }
            }
            Console.ReadLine();
        }
    }
}
