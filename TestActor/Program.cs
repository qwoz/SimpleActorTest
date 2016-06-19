using Akka.Actor;
using Akka.Routing;
using System;

namespace TestActor
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem sys = ActorSystem.Create("MySystem");

            IActorRef actor = sys.ActorOf(Props.Create(() => new MyActor()).WithRouter(FromConfig.Instance), "pool");
            var reply = actor.Ask<string>("ping").Result;

            Console.Out.WriteLine("Success: " + reply);
            Console.In.ReadLine();
        }
    }
}
