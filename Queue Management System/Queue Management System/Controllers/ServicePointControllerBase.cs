namespace Queue_Management_System.Controllers
{
    public class ServicePointControllerBase
    {

        public TicketsModel ProcessNextTicket()
        {
            var nextTicket = servicesModel.Dequeue();
            //logic to handle the next ticket
            return nextTicket;
        }
    }
}