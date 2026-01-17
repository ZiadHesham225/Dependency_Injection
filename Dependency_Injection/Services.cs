using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency_Injection
{
    public class MessageService
    {
        int randomNum;
        public MessageService()
        {
            randomNum = new Random().Next();
        }
        public string Message()
        {
            return $"Hey there #{randomNum}#";
        }
    }
    public class HelloService
    {
        MessageService _message;
        int _random;
        public HelloService(MessageService message)
        {
            _message = message;
            _random = new Random().Next();
        }

        public string Print()
        {
           return $"Hello #{_random} World {_message.Message()}";
        }
    }
    public class ServiceConsumer
    {
        HelloService _hello;
        public ServiceConsumer(HelloService hello)
        {
            _hello = hello;
        }

        public string Print()
        {
            return _hello.Print();
        }
    }
}
