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
                using (var fstream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    Console.WriteLine($"{fileName} has been created");
                }
            }
            public void AppendData(string data)
            {

                if (File.Exists(fileName))
                {
                    using (var writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine(data);
                        Console.WriteLine($"{fileName} has been changed");
                    }
                }
                else
                {
                    Console.WriteLine($"There's no file named {fileName} to add new information");
                }
            }
            public void Delete()
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    Console.WriteLine($"{fileName} has been deleted");
                }
                else
                {
                    Console.WriteLine();
                }
            }

        }
        public static void Main()
        {
            var fileManager = new SingleFileManager("newfile.txt");

            /*fileManager.OnFileCreated += x => Console.WriteLine($"Файл {x.FileName} создан");
            fileManager.OnFileDeleted += x => Console.WriteLine($"Файл {x.FileName} удален");
            fileManager.OnFileModified += x => Console.WriteLine($"В файл {x.FileName} была добавлено {x.AppendData}");*/

            fileManager.Create();
            fileManager.AppendData("Новая инфа");
            //fileManager.Delete();
        }
    }
}
