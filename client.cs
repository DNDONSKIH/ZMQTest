


using System;
using NetMQ;
using NetMQ.Sockets;
using System.Text.Json;


namespace ConsoleApp1
{
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

                    int src1 = 2;
                    int src2 = 5;

                    string message = "{" + "\"instrument\"  :\"rto\", " +
                                                "\"meas\"   :\"phase\", " +
                                               $"\"src1\"        :\"{src1}\", " +
                                               $"\"src2\"        :\"{src2}\" " + "}";


                    requester.SendFrame(message);
                    string response = requester.ReceiveFrameString();
                    Console.WriteLine($"Received message {response}");

                    MeasData? restoredData = JsonSerializer.Deserialize<MeasData>(response);
                    Console.WriteLine(restoredData);
                }
            }
        }
    }
}





