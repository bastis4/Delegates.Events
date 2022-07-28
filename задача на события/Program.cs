class Program
{

    public class EventUsing
    {
        class SingleFileManager
        {
            public string fileName;
            public SingleFileManager(string fileName) => this.fileName = fileName;
            public void Create()
            {
                if (!File.Exists(fileName)) File.Create(fileName);
                Console.WriteLine("The file has been created");
            }
            public void AppendData(string data)
            {
                using (var fstream = new FileStream(fileName, FileMode.Open))
                {
                    
                    Console.WriteLine("The file has been deleted");
                }
            }
            public void Delete()
            {
                if (File.Exists(fileName)) File.Delete(fileName);
            }

        }
        public void Main()
        {
            var fileManager = new SingleFileManager("newfile.txt");

            fileManager.OnFileCreated += x => Console.WriteLine($"Файл {x.FileName} создан");
            fileManager.OnFileDeleted += x => Console.WriteLine($"Файл {x.FileName} удален");
            fileManager.OnFileModified += x => Console.WriteLine($"В файл {x.FileName} была добавлено {x.AppendData}");

            fileManager.Create();
            fileManager.AppendData("Новая инфа");
            fileManager.Delete();
        }
    }
}
