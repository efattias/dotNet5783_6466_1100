using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO;
[Serializable]
public class DoesntExistException : Exception, ISerializable
{
    public DoesntExistException() : base() { }
    public DoesntExistException(string message) : base(message) { }
    public DoesntExistException(string message, Exception inner) : base(message, inner) { }
    protected DoesntExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
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
public class AlreadyExistExeption : Exception, ISerializable
{
    public AlreadyExistExeption() : base() { }
    public AlreadyExistExeption(string message) : base(message) { }
    public AlreadyExistExeption(string message, Exception inner) : base(message, inner) { }
    protected AlreadyExistExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
[Serializable]
public class CantDeleteItemException : Exception, ISerializable
{
    public CantDeleteItemException() : base() { }
    public CantDeleteItemException(string message) : base(message) { }
    public CantDeleteItemException(string message, Exception inner) : base(message, inner) { }
    protected CantDeleteItemException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
[Serializable]

public class ProductRequestFailedException : Exception, ISerializable
{
    public ProductRequestFailedException() : base() { }
    public ProductRequestFailedException(string message) : base(message) { }
    public ProductRequestFailedException(string message, Exception inner) : base(message, inner) { }
    protected ProductRequestFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}



