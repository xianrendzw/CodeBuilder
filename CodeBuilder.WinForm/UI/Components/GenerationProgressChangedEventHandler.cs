using System.ComponentModel;

namespace CodeBuilder.WinForm.UI
{
    public delegate void GenerationProgressChangedEventHandler(GenerationProgressChangedEventArgs args);

    public class GenerationProgressChangedEventArgs : ProgressChangedEventArgs
    {
        private int _generatedCount;
        private int _errorCount;
        private string _currentFileName;

        public GenerationProgressChangedEventArgs(int generatedCount, int errorCount, string currentFileName,
            int progressPercentage, object userToken)
            : base(progressPercentage, userToken)
        {
            this._generatedCount = generatedCount;
            this._errorCount = errorCount;
            this._currentFileName = currentFileName;
        }

        public int GeneratedCount
        {
            get { return this._generatedCount; }
        }

        public int ErrorCount
        {
            get { return this._errorCount; }
        }

        public string CurrentFileName
        {
            get { return this._currentFileName; }
        }
    }
}
