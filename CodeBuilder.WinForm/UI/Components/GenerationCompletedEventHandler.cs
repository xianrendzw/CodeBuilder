using System.ComponentModel;
using System;

namespace CodeBuilder.WinForm.UI
{
    public delegate void GenerationCompletedEventHandler(object sender,GenerationCompletedEventArgs args);

    public class GenerationCompletedEventArgs : AsyncCompletedEventArgs
    {
        public GenerationCompletedEventArgs(Exception ex,bool canceled,object state)
            : base(ex, canceled, state)
        {
        }
    }
}
