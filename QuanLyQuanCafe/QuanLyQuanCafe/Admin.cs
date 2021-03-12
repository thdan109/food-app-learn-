using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class Admin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        public Account loginAccount;
        public Admin()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods

        void LoadData()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListFood();
            LoadCategoryIntoCombobox(cbFoodCategory);
            LoadAccount();
            LoadCategory();
            LoadTable();
            AddFoodBinding();
            AddAccountBinding();
            AddCategoryBinding();
            AddTableBinding();
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
           dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
           dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
           dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void AddFoodBinding()
        {
            txtFoodname.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nudfoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
            txtFoodCategoryID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "CategoryID", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            txtAccountName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtAccountFullname.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txtAccountType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
            txtAccountID.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "ID", true, DataSourceUpdateMode.Never));

        }
        void AddCategoryBinding()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtCategoryname.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtCategorymota.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Mota", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txtTableid.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtTablestatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type, int id)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type, id))
            {
                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            //if (loginAccount.UserName.Equals(userName))
            // {
            //    MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
            //    return;
            //}
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadAccount();
        }
        void AddTable( string name, string status)
        {
            if (TableDAO.Instance.InsertTable( name, status))
            {
                MessageBox.Show("Thêm bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadTable();
        }
        void EditTable( int id, string name, string status)
        {
            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Cập nhật bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật bàn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadTable();
        }
        void DeleteTable(int id)
        {
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadTable();
        }
        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region events
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cbFoodCategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbFoodCategory.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbFoodCategory.SelectedIndex = index;
            }
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
           // LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        #endregion

        private void btnAccountadd_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;
            string displayName = txtAccountFullname.Text;
            int type = Int32.Parse(txtAccountType.Text);
            AddAccount(userName, displayName, type);
        }

        private void btnAccountdelete_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;

            DeleteAccount(userName);
        }

        private void btnAccountshow_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAccountedit_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;
            string displayName = txtAccountFullname.Text;
            int type = Int32.Parse(txtAccountType.Text);
            int id = Int32.Parse(txtAccountID.Text);
            EditAccount(userName, displayName, type,id);
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        List<Category> SearchByCategory(string name)
        {
            List<Category> listCategory = CategoryDAO.Instance.SearchByCategory(name);

            return listCategory;
        }
        List<Table> SearchByTable(string name)
        {
            List<Table> listTable = TableDAO.Instance.SearchByTable(name);

            return listTable;
        }
        List<Account> SearchAccountByName(string UserName)
        {
            List<Account> listAccount = AccountDAO.Instance.SearchAccountByName(UserName);

            return listAccount;
        }
        private void btnFoodSearch_Click(object sender, EventArgs e)
        {
            string search = txtFoodsearch.Text;
            foodList.DataSource = SearchFoodByName(search);
        }

        private void btnCategoryshow_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }
        void AddCategory( string name, string mota)
        {
            if (CategoryDAO.Instance.InsertCategory(name, mota))
            {
                MessageBox.Show("Thêm danh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadCategory();
        }
        void EditCategory(int id,string name, string mota)
        {
            if (CategoryDAO.Instance.UpdateCategory(id,name, mota))
            {
                MessageBox.Show("Sửa danh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa danh mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadCategory();
        }
        private void btnCategoryadd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryname.Text;
            string mota = txtCategorymota.Text;
            AddCategory(name, mota);
        }

        void DeleteCategory(int id)
        {
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadCategory();
        }
        private void btnCategorydelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtCategoryID.Text);

            DeleteCategory(id);
        }

        private void btnfoodedit_Click(object sender, EventArgs e)
        {
            string name = txtFoodname.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nudfoodPrice.Value;
            int id = Convert.ToInt32(txtFoodCategoryID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnfoodadd_Click(object sender, EventArgs e)
        {
            string name = txtFoodname.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nudfoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnfooddelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnfoodseen_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnTabledelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableid.Text);
            DeleteTable(id);
        }

        private void btnTableshow_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnTableedit_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            string status = txtTablestatus.Text;
            int id = Int32.Parse(txtTableid.Text);
            EditTable(id, name, status);
        }

        private void btnTableadd_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            string status = txtTablestatus.Text;
            AddTable(name, status);
        }

        private void btnAccountsearch_Click(object sender, EventArgs e)
        {
            string UserName = txtAccountsearch.Text;
            accountList.DataSource = SearchAccountByName(UserName);
        }

        private void btnCategoryedit_Click(object sender, EventArgs e)
        {
            string name = txtCategoryname.Text;
            string mota = txtCategorymota.Text;
            int id = Int32.Parse(txtCategoryID.Text);
            EditCategory(id, name, mota);
        }

        private void btnCategorySearch_Click(object sender, EventArgs e)
        {
            string name = txtCategorySearch.Text;
            categoryList.DataSource = SearchByCategory(name);
        }

        private void btnTableSearch_Click(object sender, EventArgs e)
        {
            string name = txtTableSearch.Text;
            tableList.DataSource = SearchByTable(name);
        }

        private void ResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;

            ResetPass(userName);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txtPage.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txtPage.Text = lastPage.ToString();
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txtPage.Text));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPage.Text);

            if (page > 1)
                page--;

            txtPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPage.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            txtPage.Text = page.ToString();
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport, dtpkFromDate.Value, dtpkToDate.Value);
            // this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyQuanCafeDataSet2.USP_GetListBillByDateForReport,);
            this.reportViewer.RefreshReport();
        }
    }
}
