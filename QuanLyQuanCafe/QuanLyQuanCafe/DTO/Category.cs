using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        public Category(int id, string name, string mota = null)
        {
            this.ID = id;
            this.Name = name;
            this.Mota = mota;
        }

        public Category(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.mota = row["mota"].ToString();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string mota;

        public string Mota
        {
            get { return mota; }
            set { mota = value; }
        }
    }
}
