using System;
using System.Collections.Generic;

namespace DigFiles_interpreter.Extensions
{
    public static class DictionaryExtension
    {
        public static int GetVariable(this Dictionary<int, int> dic, int key, Random random)
        {
            if(!dic.ContainsKey(key))
            {
                dic.Add(key, random.Next(0, 99));
            }

            return dic[key];
        }
    }
}
