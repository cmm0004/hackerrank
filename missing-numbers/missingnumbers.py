#!/bin/python

import math
import os
import random
import re
import sys

# Complete the missingNumbers function below.
def missingNumbers(arr, brr):
  counter = {}
  for index, value in enumerate(brr):
    if brr[index] in counter:
      counter[brr[index]]+= 1
    else:
      counter[brr[index]] = 1    
    if index < len(arr):
      if arr[index] in counter:
        counter[arr[index]]-= 1
      else:
        counter[arr[index]]= -1
  result = []
  for k,v in counter.iteritems():
    if (v != 0):
      result.append(k)
  return sorted(result);


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(raw_input())

    arr = map(int, raw_input().rstrip().split())

    m = int(raw_input())

    brr = map(int, raw_input().rstrip().split())

    result = missingNumbers(arr, brr)

    fptr.write(' '.join(map(str, result)))
    fptr.write('\n')

    fptr.close()
