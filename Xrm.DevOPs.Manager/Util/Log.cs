using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Util
{
    class Log
    {

        static Types _last = Types.Text;

        public static void Title(string msg)
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine(msg);
            Console.WriteLine("==============================================================================");
            _last = Types.Title;
        }
        public static void STitle(string msg)
        {
            if(_last != Types.Title)
                Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("------------------------------------------------------------------------------");
            _last = Types.SubTitle;
        }
        public static void Text(string msg)
        {
            Console.WriteLine(msg);
            _last = Types.SubTitle;
        }
        public static void Error(string msg)
        {
            Console.WriteLine($"######## {msg}");
            _last = Types.Error;
        }

        enum Types
        {
            Title,
            SubTitle,
            Text,
            Error
        }

    }
}
