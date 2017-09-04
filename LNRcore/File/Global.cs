using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core
{
	public static class Global
	{
		public static string global_cfg_folder()
		{
            var core_cfg = find_cfg();
            return core_cfg.DirectoryName;
		}

        // Todo: after getting my new laptop back, 
        // I'll check it out if it's my computer problem that I cannot use 
        // "System_Environment_GetFolderPath_System_Environment_SpecialFolder"

        ////////////*** !!!!!!!CHanges needed/////////////
        /// <summary>
        /// gets the location of "Adddata"
        /// </summary>
        /// <returns></returns>
		public static string global_appdata()
        {
            ///bullshit  I still have .Net Core1.0 on this computer
            ///fuck this shit!!!!!
        }

		public static FileInfo global_core_cfg()
		{
            return find_cfg();
		}

		private static FileInfo find_cfg()
		{
            string p = "core.cnf";
			if (File.Exists(p))
				return new FileInfo("core.cnf");
            if (File.Exists(p = global_appdata() + @"\LightNovelReader\core.cnf"))
                return new FileInfo(p);
            Directory.CreateDirectory(global_appdata() + @"\LightNovelReader");
            var nfs = File.Create(p);
            var ifs = new StreamWriter(nfs, Encoding.UTF8);
            Defaults.set_default_core_cnf(ifs);
            FileInfo newCfg = new FileInfo(p);
            //ifs.WriteLine("cfg_path ={0}", newCfg.FullName);
            //// ... here should be more user preferences
            return newCfg;
		}
	}

    public static class Runtime
    {
        public static int LineWidth;


        static Runtime()
        {
            var gcnf = Global.global_core_cfg();
        }
    }

    public static class Defaults
    {
        public static void set_default_core_cnf(StreamWriter fs)
        {
            fs.WriteLine("haha");
        }

        public static void set_default_book_cnf(StreamWriter fs)
        {

        }

    }


}
