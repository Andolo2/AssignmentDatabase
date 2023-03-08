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
                Console.WriteLine("1. Add new ticket");
                Console.WriteLine("2. ListAll ");
                Console.WriteLine("3. List Specefic");
                Console.WriteLine("4. Update Status");
                Console.WriteLine("5. ");
                Console.Write("Välj ett av följande alternativ (1-4): ");

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
                       await menu.ChangeStyatusAsync();
                        break;

                    case "5":
                        Console.Clear();
                         await menu.AddNewCommentAsync();
                        break;
                }
            }
        }
    }
}