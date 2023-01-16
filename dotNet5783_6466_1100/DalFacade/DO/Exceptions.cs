using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DO;
[Serializable]
public class InvalidItemException : Exception
{
    public InvalidItemException()
    {
    }

    public InvalidItemException(string? message) : base(message)
    {
    }

    public InvalidItemException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidItemException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class DoesntExistException: Exception,ISerializable
{
    public DoesntExistException() : base() { }
    public DoesntExistException(string message) : base(message) { }
    public DoesntExistException(string message, Exception inner) : base(message, inner) { }
    protected DoesntExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
[Serializable]  
public class AlreadyExistExeption : Exception, ISerializable
{
    public AlreadyExistExeption() : base() { }
    public AlreadyExistExeption(string message) : base(message) { }
    public AlreadyExistExeption(string message, Exception inner) : base(message, inner) { }
    protected AlreadyExistExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class InvalidInputExeption : Exception, ISerializable
{
    public InvalidInputExeption() : base() { }
    public InvalidInputExeption(string message) : base(message) { }
    public InvalidInputExeption(string message, Exception inner) : base(message, inner) { }
    protected InvalidInputExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class LoadingException : Exception
{
    string filePath;
    public LoadingException() : base() { filePath = ""; }
    public LoadingException(string message) : base(message) { filePath = ""; }
    public LoadingException(string message, Exception inner) : base(message, inner) { filePath = ""; }

    public LoadingException(string path, string messege, Exception inner) => filePath = path;
    protected LoadingException(SerializationInfo info, StreamingContext context) : base(info, context) { filePath = ""; }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
