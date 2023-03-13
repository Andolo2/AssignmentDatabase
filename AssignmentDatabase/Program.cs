using AssignmentDatabase.Services;

namespace AssignmentDatabase
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var menu = new MenuService();

            while (true)
            {

                Console.Clear();
                Console.WriteLine("[1] Add new ticket");
                Console.WriteLine("[2]  List All Tickets in database ");
                Console.WriteLine("[3]  List a specific Ticket in database");
                Console.WriteLine("[4]  Update Status on a Ticket");
                Console.WriteLine("[5]  Add A comment to ticket ");
                Console.WriteLine("[6]  Delete a Ticket");
                Console.WriteLine("[7]  View Ticket and comment");
                Console.Write("Choose an option:  ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        await MenuService.CreateNewTicket();
                        break;

                    case "2":
                        Console.Clear();
                        await menu.ListAllTicketsAsync();
                        break;

                    case "3":
                        Console.Clear();
                        await menu.ListSpecificTicketAsync();
                        break;

                    case "4":
                        Console.Clear();
                       await menu.ChangeStatusAsync();
                        break;

                    case "5":
                        Console.Clear();
                         await menu.AddNewCommentAsync();
                        break;

                    case "6":
                        Console.Clear();
                        await menu.DeleteATicketAsync();
                        break;

                    case "7":
                        Console.Clear();
                        await menu.ListTicketAndCommentAsync();
                        break;

                }
            }
        }
    }
}