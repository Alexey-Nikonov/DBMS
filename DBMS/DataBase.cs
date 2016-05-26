using System;
using System.IO;
using System.Collections.Generic;

namespace DBMS
{
    class DataBase
    {
        public DirectoryInfo dataBaseInfo { get; private set; } // информация о директории БД
        public string Name { get; private set; }

        Collection<Table> tables = new Collection<Table>();
        public Collection<Table> Tables { get { return this.tables; } }

        public void Connect()
        {
            this.dataBaseInfo = new DirectoryInfo(@".\ShopDb"); // можно использовать FolderBrowserDialog
            this.Name = dataBaseInfo.Name; // задаём название базы данных

            foreach (DirectoryInfo tableInfo in this.dataBaseInfo.GetDirectories())
            {
                this.tables.Add(new Table(tableInfo));
            }
        }

        public void Show()
        {
            Console.WriteLine("Data base name: " + this.Name);

            foreach (Table table in this.tables)
            {
                table.Show();
            }
        }
    }
}
