using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudApplicationLINQ
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            DataLinqToSqlDataContext linq = new DataLinqToSqlDataContext();

            DataView.DataSource = linq.PRODUCTs;

            Insert.Visible = true;
            Delete.Visible = true;
            Update.Visible = true;
            DataView.Visible = true;
            Maded_by.Visible = true;
            Name.Visible = true;
            Category.Visible = true;
            dateTimePicker1.Visible = true;
            numericUpDown1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            Date.Visible = true;
            Price.Visible = true;
            label1.Visible = true;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                DataLinqToSqlDataContext dbinstall = new DataLinqToSqlDataContext();

                PRODUCT prod = new PRODUCT();

                prod.NAME = Name.Text;
                prod.CATEGORY = Category.Text;
                prod.MADED_BY = Maded_by.Text;
                prod.PRODUCT_DATE = dateTimePicker1.Value;
                prod.PRICE = numericUpDown1.Value;

                dbinstall.PRODUCTs.InsertOnSubmit(prod);

                dbinstall.SubmitChanges();

                DataView.DataSource = dbinstall.PRODUCTs;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            try
            {
                DataLinqToSqlDataContext dbdelete = new DataLinqToSqlDataContext();

                int prodID = Convert.ToInt32(DataView.CurrentRow.Cells["ID"].Value);

                PRODUCT prod = dbdelete.PRODUCTs.SingleOrDefault(o => o.ID == prodID);
                dbdelete.PRODUCTs.DeleteOnSubmit(prod);
                dbdelete.SubmitChanges();
                DataView.DataSource = dbdelete.PRODUCTs;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Retry please ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                DataLinqToSqlDataContext dbupcon = new DataLinqToSqlDataContext();
                int prodId = Convert.ToInt32(Name.Tag);

                PRODUCT prod = dbupcon.PRODUCTs.SingleOrDefault(product => product.ID == prodId);

                prod.NAME = Name.Text;
                prod.CATEGORY = Category.Text;
                prod.MADED_BY = Maded_by.Text;
                prod.PRODUCT_DATE = Convert.ToDateTime(dateTimePicker1.Text);
                prod.PRICE = numericUpDown1.Value;

                dbupcon.SubmitChanges();

                DataView.DataSource = dbupcon.PRODUCTs;

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong :( , please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void DataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow Row = DataView.CurrentRow;
                Name.Text = Row.Cells["Name"].Value.ToString();

                Name.Tag = Row.Cells["ID"].Value;

                Category.Text = Row.Cells["CATEGORY"].Value.ToString();
                Maded_by.Text = Row.Cells["MADED_BY"].Value.ToString();
                dateTimePicker1.Text = Row.Cells["PRODUCT_DATE"].Value.ToString();
                numericUpDown1.Value = (decimal)Row.Cells["PRICE"].Value;
            }
            catch (Exception)
            {


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to my Application. In this Application you can Create, Insert, Update and Delete any data you added. Good luck :)","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

            Insert.Visible = false;
            Delete.Visible = false;
            Update.Visible = false;
            DataView.Visible = false;
            Name.Visible = false;
            Category.Visible = false;
            Maded_by.Visible = false;
            dateTimePicker1.Visible = false;
            numericUpDown1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            Date.Visible = false;
            Price.Visible = false;
            label1.Visible = false;
        }
    }
}
