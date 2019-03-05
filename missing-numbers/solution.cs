using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {
  
    // Complete the missingNumbers function below.
    static int[] missingNumbers(int[] arr, int[] brr) {
      var dict = new SortedDictionary<int, int>();
      for( var i = 0; i < brr.Count(); i++)
      {
        if (dict.ContainsKey(brr[i]))
        {
          dict[brr[i]]++;
        } else {
          dict.Add(brr[i], 1);
        }

        if (i < arr.Count())
        {
          if (dict.ContainsKey(arr[i]))
          {
            dict[arr[i]]--;
          }
          else
          {
            dict.Add(arr[i], -1);
          }
        }
      }

      return dict.Where(k => k.Value != 0).Select(k => k.Key).ToArray();
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        ;
        int[] result = missingNumbers(arr, brr);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
