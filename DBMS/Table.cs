using System;
using System.IO;
using System.Collections.Generic;

namespace DBMS
{
    class Table
    {
        public DirectoryInfo tableInfo { get; private set; } // информация о директории таблицы
        public string Name { get; private set; }

        Collection<Row> rows = new Collection<Row>();
        public Collection<Row> Rows { get { return this.rows; } }

        BinaryTree indexTree = new BinaryTree(); // индексный файл таблицы

        public Table(DirectoryInfo tableInfo)
        {
            this.tableInfo = tableInfo;
            this.Name = tableInfo.Name; // задаём название таблицы

            foreach (FileInfo fileInfo in this.tableInfo.GetFiles("*.row"))
            {
                this.rows.Add(new Row(fileInfo, indexTree));
            }
        }
        
        public void Show()
        {
            Console.WriteLine("\tTable name: " + this.Name);

            foreach (Row row in this.Rows)
            {
                Console.Write("\t\t" + row.Index);

                foreach (string element in row.Elements)
                {
                    Console.Write(" " + element);
                }

                Console.WriteLine();
            }
        }

        public void ShowIndexTree()
        {
            Console.WriteLine("Обход дерева таблицы {0} в прямом порядке: ", this.Name);
            this.indexTree.Show();
        }

        // метод поиска по индексируемому полю
        public void Find(int key)
        {
            this.indexTree.Find(key);
        }

        // метод удаления строки по индексируемому полю
        public void Remove(int key)
        {
            this.indexTree.Remove(key); // удаление из индексного файла

            foreach (Row row in this.rows)
            {
                if (int.Parse(row.Elements[1]) == key)
                {
                    this.Rows.Delete(row); // удаление из коллекции строк

                    File.Delete(row.fileInfo.FullName); // удаление из директории
                }
            }
        }

        // метод добавления строки
        public void Add(string rowContent)
        {
            // добавление файла в файловую систему
            FileInfo newRow = new FileInfo(@".\ShopDB\" + this.Name + @"\" + (this.rows.Length + 1) + @".row");

            using (FileStream fileStream = new FileStream(newRow.FullName, FileMode.CreateNew, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(rowContent);
            }

            // добавление строки в коллекцию и в бинарное дерево
            this.rows.Add(new Row(newRow, this.indexTree));
        }
    }
}
