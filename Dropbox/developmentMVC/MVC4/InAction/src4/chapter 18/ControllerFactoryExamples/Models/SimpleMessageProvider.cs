namespace ControllerFactoryExamples.Models
{
    public class SimpleMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "Hello Universe!";
        }
    }
}