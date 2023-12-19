namespace Queue_Management_System.Models
{
    public class Services
    {
        public string Name { get; set; }
        public Queue<Tickets> Queue { get; set; }

        public Services(string name)
        {
            Name = name;
            Queue = new Queue<Tickets>();
        }

        public void Enqueue(Tickets ticket)
        {
            Queue.Enqueue(ticket);
        }

        public Tickets Dequeue()
        {
            return Queue.Dequeue();
        }

        public int GetQueueLength()
        {
            return Queue.Count;
        }
    }
}
