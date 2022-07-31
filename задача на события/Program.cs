namespace eventTask
{
    class Program
    {
        public static void Main()
        {
            var fileManager = new SingleFileManager("newfile.txt");

            fileManager.OnFileCreated += (sender, e) => Console.WriteLine($"Файл {e.FileName} создан");
            fileManager.OnFileDeleted += (sender, e) => Console.WriteLine($"Файл {e.FileName} удален");
            fileManager.OnFileModified += (sender, e) => Console.WriteLine($"В файл {e.FileName} была добавлено {e.AppendData}");
            fileManager.Create();
            fileManager.AppendData("Новая инфа");
            fileManager.Delete();

        }

    }
}
