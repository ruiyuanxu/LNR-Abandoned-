using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// data structure, contains a wwhole line of the Raw file.
    /// </summary>
    public class Line : ILine
    {
        protected string raw_str;

        public string Content
        {
            get { return Wrap(); }
        }

        public string Wrap() { return Wrap(raw_str); }

        public static string Wrap(string istr) { throw new NotImplementedException(); }

    }

    public interface ILine
    {
        string Wrap();
    }


}
