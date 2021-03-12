using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account(string UserName, string displayName, int type, string password = null, string id = null)
        {
            this.UserName = UserName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Password = password;
            this.ID = id;
        }

        public Account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Type = (int)row["Type"];
            this.Password = row["PassWord"].ToString();
            this.ID = row["ID"].ToString();
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
