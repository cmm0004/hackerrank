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

    // Complete the extraLongFactorials function below.
    static void extraLongFactorials(int n) {
      BigInteger fact = n;
      for (var i = n-2; i>=1; i--)
      {
        fact += fact*i;
      }
      Console.WriteLine(fact);
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        extraLongFactorials(n);
    }
}
