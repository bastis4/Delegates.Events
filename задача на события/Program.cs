class Program
{

    public class EventUsing
    {
        class SingleFileManager
        {
            public string name;
            public SingleFileManager(string fileName) => this.name = fileName;

            public delegate void FileHandler(SingleFileManagerEventArgs e);
            public event FileHandler? OnFileCreated;
            public event FileHandler? OnFileDeleted;
            public event FileHandler? OnFileModified;


            public void Create()
            {
                using (var fstream = new FileStream(name, FileMode.OpenOrCreate))
                {
                    OnFileCreated?.Invoke(new SingleFileManagerEventArgs($"{name} has been created", name, null));
                }
            }
            public void AppendData(string data)
            {

                if (File.Exists(name))
                {
                    using (var writer = new StreamWriter(name, true))
                    {
                        writer.WriteLine(data);
                        OnFileModified?.Invoke(new SingleFileManagerEventArgs($"{name} has been changed", name, data));
                    }
                }
                else
                {
                    Console.WriteLine($"There's no file named {name} to add new information");
                }
            }
            public void Delete()
            {
                if (File.Exists(name))
                {
                    File.Delete(name);
                    OnFileDeleted?.Invoke(new SingleFileManagerEventArgs($"{name} has been deleted", name, null));
                }
                else
                {
                    Console.WriteLine("Sorry! There's no such file");
                }
            }

        }

        class SingleFileManagerEventArgs
        {
            public string Message { get; }
            public string FileName { get; }
            public string AppendData { get; }
            public SingleFileManagerEventArgs(string message, string fileName, string appendData)
            {
                Message = message;
                FileName = fileName;
                AppendData = appendData;
            }
        }

        public static void Main()
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
