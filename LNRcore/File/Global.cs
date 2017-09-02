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
			
			return "";
		}

        // Todo: after getting my new laptop back, 
        // I'll check it out if it's my computer problem that I cannot use 
        // "System_Environment_GetFolderPath_System_Environment_SpecialFolder"

        /// <summary>
        /// gets the location of "Adddata"
        /// </summary>
        /// <returns></returns>
		public static string global_appdata()
        {
            return Environment.GetEnvironmentVariable("APPDATA").Replace(@"\",@"\\");
        }

		public static FileInfo global_core_cfg()
		{
			throw new NotImplementedException();
		}

		private static FileInfo find_cfg()
		{
            string p = "core.cnf";
			if (File.Exists(p))
				return new FileInfo("core.cnf");
            if (File.Exists(p = global_appdata() + @"\core.cnf"))
                return new FileInfo(p);
            var nfs = File.Create(p);
            var ifs = new StreamWriter(nfs);
            FileInfo newCfg = new FileInfo(p);
            ifs.WriteLine("cfg_path={0}", newCfg.FullName);
            // ... here should be more user preferences
            return newCfg;
		}
	}

    public class Runtime
    {
        private static Runtime _instance = null;
        private Runtime() { }
        public static Runtime GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Runtime();
            }
            return _instance;
        }
    }

}
