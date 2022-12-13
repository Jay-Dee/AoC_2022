using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2022.Utils {
    public class WebUtils {

        public static async Task<IEnumerable<string>> ReadContent(string url)
        {
            using (HttpClient client = new HttpClient()) {
                string s = await client.GetStringAsync(url);
                char[] whitespace = new char[] { ' ', '\t' };
                return s.Split(whitespace).AsEnumerable();
            }
        }
    }
}
