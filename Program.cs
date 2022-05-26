﻿
/*
 
 using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

static class Program
{
    public static void Main()
    {
        using (var responder = new ResponseSocket())
        {
            responder.Bind("tcp://*:5555");

            while (true)
            {
                string str = responder.ReceiveFrameString();
                Console.WriteLine($"Received: {str}");
                Thread.Sleep(1000);  //  Do some 'work'
                responder.SendFrame("World");
            }
        }
    }
}
 */



using System;
using NetMQ;
using NetMQ.Sockets;

static class Program
{
    public static void Main()
    {
        Console.WriteLine("Connecting to hello world server…");
        using (var requester = new RequestSocket())
        {
            requester.Connect("tcp://localhost:5555");

            int requestNumber;
            for (requestNumber = 0; requestNumber != 10; requestNumber++)
            {
                Console.WriteLine("Sending Hello {0}...", requestNumber);
                requester.SendFrame("Hello");
                string str = requester.ReceiveFrameString();
                Console.WriteLine("Received World {0}", requestNumber);
            }
        }
    }
}


