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

    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr) {
      if (arr == null)
      {
        return;
      }
      long? min = null;
      long? max = null;
      long sum = 0;
      for (var i = 0; i < arr.Count(); i ++)
      {
        if(!min.HasValue)
        {
          min = arr[i];
        } else if (min > arr[i])
        {
          min = arr[i];
        }
        if(!max.HasValue)
        {
          max = arr[i];
        } else if (max < arr[i])
        {
          max = arr[i];
        }
        sum += arr[i];
      }
      Console.WriteLine($"{sum - max} {sum - min}");
    }

    static void Main(string[] args) {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        miniMaxSum(arr);
    }
}
