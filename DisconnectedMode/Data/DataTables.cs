using System;
using System.Data;
using System.Windows.Forms;

namespace DisconnectedMode.Data
{

    internal class DataTables
    {

        public DataSet ds = new DataSet();
        DataTable types = new DataTable();
        DataTable suppliers = new DataTable();
        DataTable goods = new DataTable();
        public DataTables() 
        {
            CreateTableTypes();
            CreateTableSuppliers();
            CreateTableGoods();

        }

        void CreateTableTypes()
        { 
            types.Columns.Add("type_id",typeof(Int32));
            types.Columns.Add("type_name");
            string[] TypesItems = { "Електроніка", "Одяг", "Їжа, напої", "Книги", "Побутові", "Спортивні", "Канцтовари", "Косметика", "Подарунки" };
            for (int i = 0; i < 9; i++)
            {
                DataRow row = types.NewRow();
                row[0] = i;
                row[1] = TypesItems[i];
                types.Rows.Add(row);
            }
            ds.Tables.Add(types);
        }
        void CreateTableSuppliers()
        {
            
            suppliers.Columns.Add("supplier_id", typeof(Int32));
            suppliers.Columns.Add("supplier_name");
            string[] SuppliersItems = { "Зелений Луг", "БудТорг", "ЕкоСвіт", "Інтелект", "Екофуд", "Віташ" };
            for (int i = 0; i < 6; i++)
            {
                DataRow row = suppliers.NewRow();
                row[0] = i;
                row[1] = SuppliersItems[i];
                suppliers.Rows.Add(row);
            }
            ds.Tables.Add(suppliers);
        }
        void CreateTableGoods()
        {
            
            goods.Columns.Add("goods_id",typeof(Int32));
            goods.Columns.Add("name");
            goods.Columns.Add("type_id", typeof(Int32));
            goods.Columns.Add("supplier_id", typeof(Int32));
            goods.Columns.Add("quantity", typeof(Int32));
            goods.Columns.Add("cost", typeof(Int32));
            goods.Columns.Add("delivery_date", typeof(DateTime));

            string[,] GoodsItems = {
    {"Олівець", "6","1","1000","3","2023-11-29 14:30:00"},
    {"Шампунь", "7","3","250","50","2023-04-03 17:45:00"},
    {"Футболка", "1","4","50","250","2023-01-27 10:15:00"},
    {"Магніт", "8","2","100","30","2023-12-30 18:25:00"},
    {"Абетка", "3", "5", "150", "100", "2023-01-18 08:00:00"},
    {"Келихи", "4", "2", "50", "400", "2023-05-07 16:20:00"},
    {"Кавоварка","0", "0", "20", "5000", "2023-09-19 11:20:00"},
    {"Планшет", "0", "3", "10", "8000", "2023-12-05 18:25:00"},
    {"Гантелі", "5", "1", "75", "300", "2023-10-11 11:20:00"},
    {"Снігова куля", "8", "0", "200", "230", "2023-07-10 16:20:00"},
    {"Фанта", "2", "5", "500", "25", "2023-02-08  12:35:00"},
    {"Макарони", "2", "3", "34", "30", "2023-11-27  12:35:00"},
    {"Зошит", "6", "0", "100", "3", "2023-04-22 18:25:00"}
        };
            for (int i = 0; i < 13; i++)
            {
                DataRow row = goods.NewRow();
                row[0] = i;
                row[1] = GoodsItems[i, 0];
                row[2] = GoodsItems[i, 1];
                row[3] = GoodsItems[i, 2];
                row[4] = GoodsItems[i, 3];
                row[5] = GoodsItems[i, 4];
                row[6] = GoodsItems[i, 5];
                goods.Rows.Add(row);
            }
            ds.Tables.Add(goods);
        }
        public void AddItemToTypes(int number)
        {
            if (number < 11)
            {
                string[] AdditionalTypesItems = {"Меблі", "Техніка для кухні", "Автотовари", "Здоров'я та краса","Дитячі товари", "Музикальні інструменти",
            "Подорожі та відпочинок","Сад та город", "Тварини", "Ювелірні вироби", "Офісні товари"};
                DataRow row = types.NewRow();
                row[0] = 9 + number;
                row[1] = AdditionalTypesItems[number];
                types.Rows.Add(row);
                types.AcceptChanges();
                MessageBox.Show("Додано тип", "Повідомлення");
            }
            else
            {
                MessageBox.Show("Більше не можна додати типи", "Повідомлення");
            }
        }
        public void AddItemToSuppliers(int number)
        {
            if (number < 14)
            {
                string[] AdditionalSuppliersItems = {"Екоімпульс", "Інтергал-Еко", "Техніка Лайф", "ГрінЕко",
    "ОрганікІнвест", "Сонячний Острів", "Єкофлора", "ЕкоГрад", "Здоровий Вибір",
    "Екохаб", "ЕкоАгро", "АгроЕко", "ЕкоТех", "ОргТрейд"};
                DataRow row = suppliers.NewRow();
                row[0] = 6 + number;
                row[1] = AdditionalSuppliersItems[number];
                suppliers.Rows.Add(row);
                suppliers.AcceptChanges();
                MessageBox.Show("Додано постачальника", "Повідомлення");
            }
            else
            {
                MessageBox.Show("Більше не можна додати постачальників", "Повідомлення");
            }
        }

        public void AddItemToGoods(int number)
        {
            if (number < 12)
            { 
            string[,] AdditionalGoodsItems = {
    { "Флешка", "1", "1", "80", "150", "2023-12-20 09:30:00" },
    { "Смартфон", "0", "1", "30", "8000", "2023-07-01 15:00:00"},
    { "Ліхтарик", "5", "5", "300", "50", "2023-09-25 16:45:00"},
    { "Пазли 'Пейзаж'", "4", "3", "15", "300", "2023-05-12 10:00:00"},
    { "Телефон", "0", "1", "20", "12000", "2023-11-15 09:45:00"},
    { "Книга 'Війна і мир'", "3", "4", "10", "450", "2023-08-05 14:30:00"},
    { "Комп'ютерна миша", "6", "2", "40", "150", "2023-10-30 11:10:00"},
    { "Ноутбук", "0", "1", "1", "20000", "2023-06-15 12:20:00"},
    { "Футляр для телефону", "4", "2", "60", "100", "2023-09-08 09:00:00"},
    { "Ковдра", "5", "3", "20", "400", "2023-03-18 19:30:00"},
    { "Подушка", "2", "4", "30", "250", "2023-10-01 08:45:00"},
    { "Спортивні штани", "1", "5", "40", "350", "2023-11-24 14:15:00"}
};

            DataRow row = goods.NewRow();
            row[0] = 13 + number;
            row[1] = AdditionalGoodsItems[number, 0];
            row[2] = AdditionalGoodsItems[number, 1];
            row[3] = AdditionalGoodsItems[number, 2];
            row[4] = AdditionalGoodsItems[number, 3];
            row[5] = AdditionalGoodsItems[number, 4];
            row[6] = AdditionalGoodsItems[number, 5];
            goods.Rows.Add(row);
            goods.AcceptChanges();
            MessageBox.Show("Додано товар", "Повідомлення");
            }
            
            else
            {
                MessageBox.Show("Більше не можна додати товари", "Повідомлення");
            }
        }

        public void RemoveLastType()
        {
            if (types.Rows.Count > 0)
            {
                types.Rows.RemoveAt(types.Rows.Count - 1);
                MessageBox.Show("Видалено тип товару", "Повідомлення");
            }
            else
            {
                MessageBox.Show("Таблиця порожня", "Повідомлення");
            }
        }
        public void RemoveLastSupplier()
        {
            if (suppliers.Rows.Count > 0)
            {
                suppliers.Rows.RemoveAt(suppliers.Rows.Count - 1);
                MessageBox.Show("Видалено постачальника", "Повідомлення");
            }
            else
            {
                MessageBox.Show("Таблиця порожня", "Повідомлення");
            }
        }
        public void RemoveLastGoods()
        {
            if (goods.Rows.Count > 0)
            {
                goods.Rows.RemoveAt(goods.Rows.Count - 1);
                MessageBox.Show("Видалено товар", "Повідомлення");
            }
            else
            {
                MessageBox.Show("Таблиця порожня", "Повідомлення");
            }
        }
    }
}
