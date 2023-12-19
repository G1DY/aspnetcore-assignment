namespace Queue_Management_System.Controllers
{
    public class ServicePointController
    {
        private Services services;

        public ServicePointController(Services services)
        {
            this.services = services;
        }

        public Tickets ProcessNextTicket()
        {
            var nextTicket = services.Dequeue();
            //logic to handle the next ticket
            return nextTicket;
        }
    }
}
