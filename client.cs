

using System;
using NetMQ;
using NetMQ.Sockets;
using System.Text.Json;


namespace ConsoleApp1
{
    class MeasData
    {
        public string? instrument { get; set; }
        public string? meas { get; set; }
        public int src1 { get; set; }
        public int src2 { get; set; }
        public double result { get; set; }

        public MeasData(string? instrument, string? meas, int src1, int src2, double result)
        {
            this.instrument = instrument;
            this.meas = meas;
            this.src1 = src1;
            this.src2 = src2;
            this.result = result;
        }
    }

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
                    Console.WriteLine("Sending Msg {0}...", requestNumber);

                    //int src1 = 2;
                    //int src2 = 5;

                    //string message = "{" + "\"instrument\"  :\"rto\", " +
                    //                            "\"meas\"   :\"phase\", " +
                    //                           $"\"src1\"        :\"{src1}\", " +
                    //                           $"\"src2\"        :\"{src2}\" " + "}";


                    MeasData meas = new MeasData("rto", "phase", 9 , 8, 0.0);
                    string message = JsonSerializer.Serialize(meas);

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




