using System;

namespace CustomExceptions
{
    // Juniper has great Custom Exceptions in 
    // 02IntermediateCSharp/PokemonStorageSystem/Models/Pokemon.cs
    // 02IntermediateCSharp/PokemonStorageSystem/Models/PokeTrainer.cs

    public class ResourceNotFound : System.Exception
    {
        public ResourceNotFound() { }
        public ResourceNotFound(string message) : base(message) { }
        public ResourceNotFound(string message, System.Exception inner) : base(message, inner) { }
        protected ResourceNotFound(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class UsernameNotAvailable : System.Exception
    {
        public UsernameNotAvailable() { }
        public UsernameNotAvailable(string message) : base(message) { }
        public UsernameNotAvailable(string message, System.Exception inner) : base(message, inner) { }
        protected UsernameNotAvailable(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
    public class InvalidCredentials : System.Exception
    {
        public InvalidCredentials() { }
        public InvalidCredentials(string message) : base(message) { }
        public InvalidCredentials(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidCredentials(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class InputInvalidException : Exception
    {
        public InputInvalidException() { }
        public InputInvalidException(string message) : base(message) { }
        public InputInvalidException(string message, System.Exception inner) : base(message, inner) { }
        protected InputInvalidException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }    
}

