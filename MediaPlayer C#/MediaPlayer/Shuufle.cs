using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace MediaPlayer
{
    internal static class Shuffle
    {
 
        public static void Shuffle1<T>(this IList<T> data)
        {
            Random rd = new Random();
            for (int i = data.Count - 1; i >= 1; i--)
            {
                int j = rd.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
        }
        
    }
}
