using System;
using System.IO;

namespace DBMS
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация наблюдателя

            //FileSystemWatcher watcher = new FileSystemWatcher()
            //{
            //    Path = dataBase.Tables[0].tableInfo.FullName,
            //    EnableRaisingEvents = true
            //};

            //watcher.Deleted += watcher_Changed;
            //watcher.Created += watcher_Changed;

            #endregion

            DataBase dataBase = new DataBase();
            dataBase.Connect();
            dataBase.Show();

            foreach (Table table in dataBase.Tables)
            {
                table.ShowIndexTree();
            }

            Console.WriteLine(">>Введите значение индексируемого поля для поиска в таблице {0}: ", dataBase.Tables[0].Name);
            dataBase.Tables[0].Find(int.Parse(Console.ReadLine()));

            Console.WriteLine(">>Введите информацию для добавления строки в таблицу {0}: ", dataBase.Tables[0].Name);
            dataBase.Tables[0].Add(Console.ReadLine());

            dataBase.Tables[0].ShowTable();
            dataBase.Tables[0].ShowIndexTree();

            Console.WriteLine(">>Введите значение индексируемого поля для удаления строки из таблицы {0}: ", dataBase.Tables[0].Name);
            dataBase.Tables[0].Remove(int.Parse(Console.ReadLine()));

            dataBase.Tables[0].ShowTable();
            dataBase.Tables[0].ShowIndexTree();

            Console.ReadKey(true);
        }

        // обработчик события для наблюдателя за репозиторием
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(String.Format("Изменение: {0} Директория: {1}", e.ChangeType, e.FullPath));
        }
    }
}
