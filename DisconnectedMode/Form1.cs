using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using DisconnectedMode.Data;
using Microsoft.Data.Sqlite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
namespace DisconnectedMode
{
    public partial class Form1 : Form
    {
        DataTables dataTables = new DataTables();
        private static string connectionString = "Data Source=storage.sqlite;";
        int numberAddinionalTypes =0;
        int numberAddinionalSupplier = 0;
        int numberAddinionalGoods = 0;
        DateTime fiftyDaysAgo = DateTime.Today.AddDays(-50);
        public Form1()
        {
            InitializeComponent();
        }

        void BindDataToDataGridView(DataTable table, string filter)
        {
            DataTable originalTable = table.Copy();
            DataView view = new DataView(originalTable);
            view.RowFilter = filter;
            dataGridView1.DataSource = view.ToTable();
        }

        void SuppliersMaxQuantity(DataTable table1, DataTable table2)
        {
            var joinedData = (from t1 in table1.AsEnumerable()
                              join t2 in table2.AsEnumerable()
                              on t1.Field<int>("supplier_id") equals t2.Field<int>("supplier_id")
                              orderby t2.Field<int>("quantity") descending
                              select new
                              {
                                  SupplierID = t1.Field<int>("supplier_id"),
                                  SupplierName = t1.Field<string>("supplier_name"),
                                  GoodsQuantity = t2.Field<int>("quantity")
                              }).ToList();


            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("SupplierID", typeof(int));
            resultTable.Columns.Add("SupplierName", typeof(string));
            resultTable.Columns.Add("MaxQuantity", typeof(int));
            resultTable.Rows.Add(joinedData[0].SupplierID, joinedData[0].SupplierName, joinedData[0].GoodsQuantity);
            dataGridView1.DataSource = resultTable;
        }
        void SuppliersMinQuantity(DataTable table1, DataTable table2)
        {
            var joinedData = (from t1 in table1.AsEnumerable()
                              join t2 in table2.AsEnumerable()
                              on t1.Field<int>("supplier_id") equals t2.Field<int>("supplier_id")
                              orderby t2.Field<int>("quantity") descending
                              select new
                              {
                                  SupplierID = t1.Field<int>("supplier_id"),
                                  SupplierName = t1.Field<string>("supplier_name"),
                                  GoodsQuantity = t2.Field<int>("quantity")
                              }).ToList();


            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("SupplierID", typeof(int));
            resultTable.Columns.Add("SupplierName", typeof(string));
            resultTable.Columns.Add("MinQuantity", typeof(int));
            resultTable.Rows.Add(joinedData.LastOrDefault().SupplierID, joinedData.LastOrDefault().SupplierName, joinedData.LastOrDefault().GoodsQuantity);
            dataGridView1.DataSource = resultTable;
        }
        void TypesMaxQuantity(DataTable table1, DataTable table2)
        {
            var joinedData = (from t1 in table1.AsEnumerable()
                              join t2 in table2.AsEnumerable()
                              on t1.Field<int>("type_id") equals t2.Field<int>("type_id")
                              orderby t2.Field<int>("quantity") descending
                              select new
                              {
                                  TypeID = t1.Field<int>("type_id"),
                                  TypeName = t1.Field<string>("type_name"),
                                  GoodsQuantity = t2.Field<int>("quantity")
                              }).ToList();


            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("TypeID", typeof(int));
            resultTable.Columns.Add("TypeName", typeof(string));
            resultTable.Columns.Add("MaxQuantity", typeof(int));
            resultTable.Rows.Add(joinedData[0].TypeID, joinedData[0].TypeName, joinedData[0].GoodsQuantity);
            dataGridView1.DataSource = resultTable;
        }
        void TypesMinQuantity(DataTable table1, DataTable table2)
        {
            var joinedData = (from t1 in table1.AsEnumerable()
                              join t2 in table2.AsEnumerable()
                              on t1.Field<int>("type_id") equals t2.Field<int>("type_id")
                              orderby t2.Field<int>("quantity") descending
                              select new
                              {
                                  TypeID = t1.Field<int>("type_id"),
                                  TypeName = t1.Field<string>("type_name"),
                                  GoodsQuantity = t2.Field<int>("quantity")
                              }).ToList();

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("TypeID", typeof(int));
            resultTable.Columns.Add("TypeName", typeof(string));
            resultTable.Columns.Add("MaxQuantity", typeof(int));
            resultTable.Rows.Add(joinedData.LastOrDefault().TypeID, joinedData.LastOrDefault().TypeName, joinedData.LastOrDefault().GoodsQuantity);
            dataGridView1.DataSource = resultTable;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            { 
                case 0: BindDataToDataGridView(dataTables.ds.Tables[2], null); break;
                case 1: BindDataToDataGridView(dataTables.ds.Tables[0], null); break;
                case 2: BindDataToDataGridView(dataTables.ds.Tables[1], null); break;
                case 3: BindDataToDataGridView(dataTables.ds.Tables[2], "quantity=MAX(quantity)"); break;
                case 4: BindDataToDataGridView(dataTables.ds.Tables[2], "quantity=MIN(quantity)"); break;
                case 5: BindDataToDataGridView(dataTables.ds.Tables[2], "cost = MAX(cost)"); break;
                case 6: BindDataToDataGridView(dataTables.ds.Tables[2], "cost = MIN(cost)"); break;
                case 7: BindDataToDataGridView(dataTables.ds.Tables[2], "type_id=0"); break;
                case 8: BindDataToDataGridView(dataTables.ds.Tables[2], "supplier_id=0"); break;
                case 9: BindDataToDataGridView(dataTables.ds.Tables[2], "delivery_date = MIN(delivery_date)"); break;
                case 10: SuppliersMaxQuantity(dataTables.ds.Tables[1], dataTables.ds.Tables[2]); break;
                case 11: SuppliersMinQuantity(dataTables.ds.Tables[1], dataTables.ds.Tables[2]); break;
                case 12: TypesMaxQuantity(dataTables.ds.Tables[0], dataTables.ds.Tables[2]); break;
                case 13: TypesMinQuantity(dataTables.ds.Tables[0], dataTables.ds.Tables[2]); break;
                case 14: BindDataToDataGridView(dataTables.ds.Tables[2], $"delivery_date > '{fiftyDaysAgo}'"); break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: dataTables.AddItemToTypes(numberAddinionalTypes); numberAddinionalTypes++; break;
                case 1: dataTables.AddItemToSuppliers(numberAddinionalSupplier); numberAddinionalSupplier++; break;
                case 2: dataTables.AddItemToGoods(numberAddinionalGoods); numberAddinionalGoods++; break;
                case 3:
                    {
                        dataTables.AddItemToTypes(numberAddinionalTypes); numberAddinionalTypes++; 
                        dataTables.AddItemToSuppliers(numberAddinionalSupplier); numberAddinionalSupplier++;
                        dataTables.AddItemToGoods(numberAddinionalGoods); numberAddinionalGoods++; break;
                    } 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: dataTables.RemoveLastType(); numberAddinionalTypes--; break;
                case 1: dataTables.RemoveLastSupplier(); numberAddinionalSupplier--; break;
                case 2: dataTables.RemoveLastGoods(); numberAddinionalGoods--; break;
                case 3:
                    {
                        dataTables.RemoveLastType(); numberAddinionalTypes--;
                        dataTables.RemoveLastSupplier(); numberAddinionalSupplier--;
                        dataTables.RemoveLastGoods(); numberAddinionalGoods--; break;
                    }
            }
        }


    }
}
