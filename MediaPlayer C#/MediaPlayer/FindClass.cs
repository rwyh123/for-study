using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    internal class FindClass
    {

        public static List<string> Find(string path, string match)
        {
            var result = new List<string>();
            var result1 = new List<string>();
            if (Directory.Exists(path))
            {
                result.AddRange(Directory.GetFiles(path, match));
                result1.AddRange(Directory.GetDirectories(path));

                foreach (var dir in result1)
                {
                    result.AddRange(Find(dir, match));
                }

            }
            return result;
        }

        public static List<FileInfo> Find1(string path, string match)
        {
            var directory = new DirectoryInfo(path);
            var result = new List<FileInfo>();
            var result1 = new List<DirectoryInfo>();
            if (Directory.Exists(path))
            {
                result.AddRange(directory.GetFiles(match));
                result1.AddRange(directory.GetDirectories());

                foreach (DirectoryInfo dir in result1)
                {
                    result.AddRange(Find1(dir.FullName, match));
                }

            }
            return result;
        }
    }
}
    
