using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class txtBook : bfile, IBook
    {
        public override string hashname()
        {
            throw new NotImplementedException();
        }

        public override void createcfg()
        {
            throw new NotImplementedException();
        }

        public override void update()
        {
            throw new NotImplementedException();
        }

        public override string fetchLine(FileStream fs, int tag, out int length)
        {
            throw new NotImplementedException();
        }

        public txtBook() : base() { }

        public txtBook(FileInfo fi)
        {
            path = fi.FullName;
            size = fi.Length;
            bname = fi.Name;
            hash = hashname();
            type = fileType.txt;
            cfgpath = Global.global_cfg_folder() + hash + ".cfg";
        }
    }
}
