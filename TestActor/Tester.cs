using Akka.Actor;
using Akka.Routing;
using Akka.TestKit.NUnit;
using NUnit.Framework;

namespace TestActor
{
    [TestFixture]
    public class Tester : TestKit
    {
        [Test]
        public void CreatePoolFromConfig()
        {
            IActorRef actor = Sys.ActorOf(Props.Create<MyActor>().WithRouter(FromConfig.Instance), "pool");
        }
    }

    public class MyActor : ReceiveActor
    {
        public MyActor()
        {
            ReceiveAny(ping =>
            {
                Sender.Tell("pong");
            });
        }
    }
}
