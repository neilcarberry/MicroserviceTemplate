using System;
using System.Linq;

public class BaseEventException : Exception
{
    protected BaseEventException(string[] errors) : base(errors.FirstOrDefault())
    {
        Type = "Exception";
        Errors = errors;
    }

    public string[] Errors { get; }

    public string Type { get; }
}