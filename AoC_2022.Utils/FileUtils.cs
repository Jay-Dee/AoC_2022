using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC_2022.Utils {
    public class FileUtils {
        public static IEnumerable<string> GetContent(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
