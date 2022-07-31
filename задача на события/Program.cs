class Program
{

    public class EventUsing
    {
        class SingleFileManager
        {
            private string _fileName;
            public SingleFileManager(string fileName) => this._fileName = fileName;

            public delegate void FileHandler(SingleFileManagerEventArgs e);
            public event FileHandler? OnFileCreated;
            public event FileHandler? OnFileDeleted;
            public event FileHandler? OnFileModified;


            public void Create()
            {
                using (var fstream = new FileStream(_fileName, FileMode.OpenOrCreate))
                {
                    OnFileCreated?.Invoke(new SingleFileManagerEventArgs($"{_fileName} has been created", _fileName, null));
                }
            }
            public void AppendData(string data)
            {

                if (File.Exists(_fileName))
                {
                    using (var writer = new StreamWriter(_fileName, true))
                    {
                        writer.WriteLine(data);
                        OnFileModified?.Invoke(new SingleFileManagerEventArgs($"{_fileName} has been changed", _fileName, data));
                    }
                }
                else
                {
                    Console.WriteLine($"There's no file named {_fileName} to add new information");
                }
            }
            public void Delete()
            {
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                    OnFileDeleted?.Invoke(new SingleFileManagerEventArgs($"{_fileName} has been deleted", _fileName, null));
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
