﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result(bool success) : IResult
    {//get = readonly  readonly contructors da set edilebilir

        public Result(bool success, string message):this (success)
        {
            Message = message; 
        }

        public bool Success { get; } = success;

        public string Message { get; } = string.Empty;
    }
}
