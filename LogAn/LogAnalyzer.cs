
namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer()
        {
            manager = new FileExtensionManager();
        }

        public bool IsValidLogFileName(string fileName)
        {
            return this.IsValid(fileName);
        }

        protected virtual bool IsValid(string fileName)
        {
            FileExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName);

        }
    }

    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }

    class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            // Здаесь читается файл.
        }
    }

    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return this.IsValid(fileName);
        }

        protected virtual bool IsValid(string fileName)
        {
            FileExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName);
        }
    }
}
