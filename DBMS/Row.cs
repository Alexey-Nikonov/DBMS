using System;
using System.IO;

namespace DBMS
{
    class Row
    {
        public FileInfo fileInfo { get; private set; } // информация о файле строки
        public string Index { get; private set; }

        string[] elements = null;
        public string[] Elements { get { return this.elements; } }

        public Row(FileInfo fileInfo, BinaryTree intexTree)
        {
            this.fileInfo = fileInfo;
            this.Index = Path.GetFileNameWithoutExtension(this.fileInfo.FullName); // задаём индекс строки из названия файла

            FileStream fileStream = fileInfo.OpenRead();

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                this.elements = streamReader.ReadLine().Split('|');
            }

            intexTree.Add(int.Parse(elements[1]), int.Parse(this.Index)); // добавления значений в индексный файл
        }
    }
}
