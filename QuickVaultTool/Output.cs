using System;
using System.Text;

namespace QuickVaultTool
{
    public static class Output
    {
        private static readonly StringBuilder Header = new StringBuilder();
        private static readonly StringBuilder Status = new StringBuilder();
        private static readonly StringBuilder Question = new StringBuilder();
        private static readonly StringBuilder Content = new StringBuilder();

        private static bool _flushHeader = true;
        private static bool _flushStatus = true;
        private static bool _flushContent = true;
        private static bool _flushQuestion = true;

        public static void WriteLine(string line = "", OutputType outputType = OutputType.Header)
        {
            WriteLine(line, outputType, true);
        }

        public static void Write(string line = "", OutputType outputType = OutputType.Header)
        {
            WriteLine(line, outputType, false);
        }

        private static void WriteLine(string line, OutputType outputType, bool writeLine)
        {
            switch (outputType)
            {
                case OutputType.Header:
                    WriteLine(line, Header, ref _flushHeader, writeLine);
                    break;
                case OutputType.Status:
                    WriteLine(line, Status, ref _flushStatus, writeLine);
                    break;
                case OutputType.Content:
                    WriteLine(line, Content, ref _flushContent, writeLine);
                    break;
                case OutputType.Question:
                    WriteLine(line, Question, ref _flushQuestion, writeLine);
                    break;
                default:
                    throw new ArgumentException("The OutputType does not exists");
            }
        }

        private static void WriteLine(string line, StringBuilder sb, ref bool flush, bool writeLine)
        {
            if (flush)
                sb.Clear();
            flush = false;
            if(writeLine)
                sb.AppendLine(line);
            else
                sb.Append(line);
        }

        public static void Flush()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Header);

            if (Question.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Question);

                Question.Clear();
                Status.Clear();
                Content.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Status);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Content);
            }


            _flushHeader = true;
            _flushStatus = true;
            _flushContent = true;
            _flushQuestion = true;
        }

    }

    public enum OutputType
    {
        Header,
        Status,
        Question,
        Content
    }
}
