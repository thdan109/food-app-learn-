using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public List<Category> SearchByCategory(string name)
        {

            List<Category> list = new List<Category>();

            string query = string.Format("SELECT * FROM dbo.FoodCategory WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        public bool InsertCategory(string name, string mota)
        {
            string query = string.Format("INSERT dbo.FoodCategory (name, mota)VALUES  ( N'{0}', N'{1}')",name, mota);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(int id,string name, string mota)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}', mota = N'{1}' WHERE id = {2}", name, mota, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteCategoryByCateID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.Food WHERE idCategory = " + id);
        }
        public bool DeleteCategory(int id)
        {
            DeleteCategoryByCateID(id);
            string query = string.Format("Delete dbo.FoodCategory where id = N'{0}'", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
