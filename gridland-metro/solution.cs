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

    // Complete the gridlandMetro function below.
    static int gridlandMetro(int rows, int columns, int k, int[][] track) {
      var grid = makeGrid(rows, columns);
      var trackDict = reduceTracks(track);
      var lampPosts = 0;
      foreach(var entry in trackDict)
      {
        foreach(var trackSet in entry.Value)
        {
          // 1 here is end of tracks
          // 0 is start, plus one cause counting whole, not diff
          var lenOfTracks = trackSet[1] - trackSet[0] + 1;
          for (var i = 0; i<lenOfTracks; i++)
          {
            //entry.key is the row number, -1 cause not 0-based
            //every coord there is a track, set to 0
            grid[entry.Key-1,trackSet[0]-1+i] = 0;
          }
        }
      }
      for (var j = 0; j <rows;j++)
      {
        for (var l = 0; l<columns;l++)
        {
          lampPosts += grid[j,l];
        }
      }
      return lampPosts;
    }
    static Dictionary<int, List<List<int>>> reduceTracks(int[][] tracks)
    {
      var result = new Dictionary<int, List<List<int>>>();
      foreach(var track in tracks)
      {
        //track[0] is the row the track is in
        // track[1] is the starting col
        // track[2] is the ending col
        if (result.ContainsKey(track[0]))
        {
          result[track[0]].Add(new List<int>(){track[1], track[2]});
        } else
        {
          result.Add(track[0], 
          new List<List<int>>()
          {
            new List<int>()
            {
              track[1], track[2]
              }
            }
          );
        }
      }
      return result;
    }
    static int[,] makeGrid(int rows, int cols)
    {
      var result = new int[rows,cols];
      for (var i = 0; i <rows;i++)
      {
        for (var j = 0; j<cols;j++)
        {
          result[i,j] = 1;
        }
      }
      return result;
    } 
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nmk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nmk[0]);

        int m = Convert.ToInt32(nmk[1]);

        int k = Convert.ToInt32(nmk[2]);

        int[][] track = new int[k][];

        for (int i = 0; i < k; i++) {
            track[i] = Array.ConvertAll(Console.ReadLine().Split(' '), trackTemp => Convert.ToInt32(trackTemp));
        }

        int result = gridlandMetro(n, m, k, track);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
