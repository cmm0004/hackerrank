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
using System.Numerics;
class Solution {

    // Complete the organizingContainers function below.
    static string organizingContainers(int[][] container) 
    {
      if (container == null || container.Length == 0) {
        return "Impossible";
      }
         var balls = new long[container[0].Length];
         var bucket = new long[container.Length];

         for (var i = 0; i< container.Length; i++)
         {
           var rowSum = 0;
            for (var j = 0; j < container[i].Length; j++)
            {
              rowSum += container[i][j];
              balls[j] += container[i][j];

            }
            bucket[i] = rowSum;
         }
        for (var k = 0; k <balls.Length; k++)
        {
          if (balls[k] != bucket[k])
          {
            return "Impossible";
          }
        }
        return "Possible";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++) {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
