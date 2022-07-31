
namespace eventTask
{
    class SingleFileManager
    {
        public string _fileName;
        public SingleFileManager(string fileName) => this._fileName = fileName;

        public event EventHandler<SingleFileManagerEventArgs> OnFileCreated;
        public event EventHandler<SingleFileManagerEventArgs> OnFileDeleted;
        public event EventHandler<SingleFileManagerEventArgs> OnFileModified;


        public void Create()
        {
            using (var fstream = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                OnFileCreated?.Invoke(this, new SingleFileManagerEventArgs { Message = $"{_fileName} has been created", FileName = _fileName });
            }
        }
        public void AppendData(string data)
        {
             
            if (File.Exists(_fileName))
            {
                using (var writer = new StreamWriter(_fileName, true))
                {
                    writer.WriteLine(data);
                    OnFileModified?.Invoke(this, new SingleFileManagerEventArgs { Message = $"{_fileName} has been changed", FileName = _fileName, AppendData = data });
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
                OnFileDeleted?.Invoke(this, new SingleFileManagerEventArgs { Message = $"{_fileName} has been deleted", FileName = _fileName });
            }
            else
            {
                Console.WriteLine("Sorry! There's no such file");
            }
        }

    }
}
