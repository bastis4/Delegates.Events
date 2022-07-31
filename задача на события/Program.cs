namespace eventTask
{
    class Program
    {
        public static void Main()
        {
            var fileManager = new SingleFileManager("newfile.txt");

            var eventOnCreated = new EventHandler<SingleFileManagerEventArgs>(FileCreated);
            var eventOnDeleted = new EventHandler<SingleFileManagerEventArgs>(FileDeleted);
            var eventOnModified = new EventHandler<SingleFileManagerEventArgs>(FileModified);

            fileManager.OnFileCreated += eventOnCreated;
            fileManager.OnFileDeleted += eventOnDeleted;
            fileManager.OnFileModified += eventOnModified;

            fileManager.Create();
            fileManager.AppendData("Новая инфа");
            fileManager.Delete();



        }
        public static void FileCreated(object sender, SingleFileManagerEventArgs e)
        {
            Console.WriteLine($"Файл {e.FileName} создан");
        }
        public static void FileDeleted(object sender, SingleFileManagerEventArgs e)
        {
            Console.WriteLine($"Файл {e.FileName} удален");
        }
        public static void FileModified(object sender, SingleFileManagerEventArgs e)
        {
            Console.WriteLine($"В файл {e.FileName} была добавлено {e.AppendData}");
        }
    }
}
