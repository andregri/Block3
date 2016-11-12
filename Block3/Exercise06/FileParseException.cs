using System;

namespace Exercise06
{
    public class FileParseException : ApplicationException
    {
        private string message;
        public override string Message
        {
            get
            {
                return message;
            }
        }

        private string filename;
        public string Filename
        {
            get
            {
                return filename;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("[filename] could not be set to null.");
                }
                filename = value;
            }
        }

        private int line;
        public int Line
        {
            get
            {
                return line;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("You input" + value + ".[line] should be a positive integer.");
                }
                line = value;
            }
        }

        public FileParseException(string message, string filename, int line, Exception inner)
            : base(null, inner)
        {
            this.message = message;
            Filename = filename;
            Line = line;
        }

        public FileParseException(string message, string filename, int line)
            : this(message, filename, line, null)
        {
        }

        public FileParseException(string filename, int line, Exception inner)
            : this(null, filename, line, inner)
        {
            this.message = String.Format("Error file: \"{0}\". Expected integer at line {1}.", Filename, Line);
        }

        public FileParseException(string filename, int line)
            : this(filename, line, null)
        {
        }
    }
}
