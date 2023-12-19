namespace Queue_Management_System.Models
{
    public class ServicesModel
    {
        public string Name { get; set; }
        public Queue<TicketsModel> Queue { get; set; }

        public ServicesModel(string name)
        {
            Name = name;
            Queue = new Queue<TicketsModel>();
        }

        public void Enqueue(TicketsModel ticket)
        {
            Queue.Enqueue(ticket);
        }

        public TicketsModel Dequeue()
        {
            return Queue.Dequeue();
        }

        public int GetQueueLength()
        {
            return Queue.Count;
        }

        public void ConfigureService(string ServiceName)
        {
            // Logic to configure a service
            // For example:
            // SomeService.Configure(serviceName);
        }

        public void ConfigureProvider(string ProviderName)
        {
            // Logic to configure a service provider
            // For example:
            // SomeProvider.Configure(providerName);
        }

        internal IEnumerable<object> EnQueue()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> GetQueue()
        {
            throw new NotImplementedException();
        }
    }
}