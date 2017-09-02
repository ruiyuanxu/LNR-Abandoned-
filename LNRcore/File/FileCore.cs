using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core
{
	/// <summary>
	/// use a enum to figure the types of the files
	/// </summary>
	public enum fileType { unknown=-1,txt=0, epub=1, mobi=2}

	/// <summary>
	/// base class of the books.
	/// </summary>
	public abstract class bfile : IBook
	{
		/// <summary>
		/// file absolute path
		/// </summary>
		public string path { get; set; }

		/// <summary>
		/// file size
		/// </summary>
		public Int64 size { get; set; }

		/// <summary>
		/// bookname
		/// </summary>
		public string bname { get; set; }

		/// <summary>
		/// unique sequence to mark different books which may have same names.
		/// </summary>
		public string hash { get; set; }

		/// <summary>
		/// tells the document type
		/// </summary>
		public fileType type { get; set; }

		/// <summary>
		/// path of the config file
		/// </summary>
		public string cfgpath { get; set; }

		/// <summary>
		/// update book info
		/// </summary>
		public abstract void update();

		/// <summary>
		/// sets the hash value
		/// </summary>
		/// <returns>a hashed value</returns>
		public abstract string hashname();

		/// <summary>
		/// method to create/recreate a cfg file.
		/// </summary>
		public abstract void createcfg();

		public abstract string fetchLine(FileStream fs, int tag, out int length);

		public bfile()
		{
			path = "null";
			size = 0;
			bname = "null";
			type = fileType.unknown;
		}

		public bfile(string path, Int64 size, string bname, fileType type)
		{
			this.path = path;
			this.size = size;
			this.bname = bname;
			this.type = type;
			cfgpath = Global.global_cfg_folder() + hash + ".cfg"; // global variables needed;
		}

	}

	public interface IBook
	{
		/// <summary>
		/// sets the hash value
		/// </summary>
		/// <returns>a hashed value</returns>
		string hashname();
		/// <summary>
		/// update book info
		/// </summary>
		void update();
		/// <summary>
		/// fetch seperate lines from file. May have to re-wrap through a line-wrapper to fit into the Line DataType
		/// </summary>
		/// <param name="fs">filestream</param>
		/// <param name="tag">unkonwn parameter</param>
		/// <param name="length">length of the line read by readline</param>
		/// <returns>a string of a whole line (unwrapped)</returns>
		string fetchLine(FileStream fs, int tag, out int length); // tag may be used, dunno now
	}



}