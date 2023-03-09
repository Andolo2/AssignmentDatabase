using AssignmentDatabase.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Services
{
    public class MenuService
    {
        public static async Task CreateNewTicket()
        {
            var user = new UserModel();

            Console.Write("Firstname: ");
            user.FirstName = Console.ReadLine() ?? "";

            Console.Write("Lastname: ");
            user.LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            user.Email = Console.ReadLine() ?? "";

            Console.Write("Phonenumber: ");
            user.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Förnamn: ");
            user.FirstName = Console.ReadLine() ?? "";

            Console.Write("Department: ");
            user.DepartmentName = Console.ReadLine() ?? "";

            Console.Write("Streetname: ");
            user.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postalcode: ");
            user.PostalCode = Console.ReadLine() ?? "";

            Console.Write("City: ");
            user.City = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            user.Description = Console.ReadLine() ?? "";


            Console.Write("Text: ");
            user.TicketText = Console.ReadLine() ?? "";

            //Console.Write("Status: ");
            //user.Status = Console.ReadLine() ?? "";

            Console.Write("Comment: ");
            user.Comment = Console.ReadLine() ?? "";


            await UserService.SaveToDatabaseAsync(user);
        }

        public async Task ListAllTicketsAsync()
        {
            var users = await UserService.GetAllTicketsAsync();


            if (users.Any())
            {
                foreach (UserModel user in users)
                {
                    Console.WriteLine($"TicketID: {user.Id}");
                    Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                    Console.WriteLine($"E-postadress: {user.Email}");
                    Console.WriteLine($"Telefonnummer: {user.PhoneNumber}");
                    Console.WriteLine($"Address: {user.DepartmentName}, {user.StreetName}, {user.PostalCode}, {user.City}");
                    Console.WriteLine($"Description: {user.Description}");
                    Console.WriteLine($"Text: {user.TicketText}");
                    Console.WriteLine($"Status: {user.Status}");
                    Console.WriteLine($"Created at: : {user.CreationTime}".ToString());
                    Console.WriteLine($"Comment: {user.Comment}");


                    Console.ReadKey();

                }




            }
        }

        public async Task ListSpecificTicketAsync()
        {
            Console.Write("Write Email of ticket user: ");
            var email = Console.ReadLine();

            if (!String.IsNullOrEmpty(email))
            {
                var _user = await UserService.GetSpecificTicketAsync(email);

                if (_user != null)
                {
                    Console.WriteLine($"TicketID: {_user.Id}");
                    Console.WriteLine($"Name: {_user.FirstName} {_user.LastName}");
                    Console.WriteLine($"E-postadress: {_user.Email}");
                    Console.WriteLine($"Telefonnummer: {_user.PhoneNumber}");
                    Console.WriteLine($"Address: {_user.DepartmentName}, {_user.StreetName}, {_user.PostalCode}, {_user.City}");
                    Console.WriteLine($"Description: {_user.Description}");
                    Console.WriteLine($"Text: {_user.TicketText}");
                    Console.WriteLine($"Status: {_user.Status}");
                    Console.WriteLine($"Created at: {_user.CreationTime}".ToString());
                    Console.WriteLine($"Comment: {_user.Comment}");


                    Console.ReadKey();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Could not find user with email:  {email} ");
                    Console.WriteLine("");
                }
            }
        }

        public async Task ChangeStyatusAsync()
        {
            Console.Write("Write Email of ticket user: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var _user = await UserService.GetSpecificTicketAsync(email);

                if (_user != null)
                {
                    Console.WriteLine($"TicketID: {_user.Id}");
                    Console.WriteLine($"Name: {_user.FirstName} {_user.LastName}");
                    Console.WriteLine($"E-postadress: {_user.Email}");
                    Console.WriteLine($"Telefonnummer: {_user.PhoneNumber}");
                    Console.WriteLine($"Address: {_user.DepartmentName}, {_user.StreetName}, {_user.PostalCode}, {_user.City}");
                    Console.WriteLine($"Description: {_user.Description}");
                    Console.WriteLine($"Text: {_user.TicketText}");
                    Console.WriteLine($"Status: {_user.Status}\r\n");

                    Console.WriteLine("\r\n Add new status on Ticket - New, Ongoing or Closed");


                    var OptionList = new string[] { "New", "Ongoing", "Closed" };

                    if (!OptionList.Contains(_user.Status = Console.ReadLine() ?? null!))
                    {
                        Console.WriteLine("Wrong input, try again. Press a button to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        await UserService.UpdateStatusAsync(_user);

                        Console.WriteLine("Status has been updated");
                        Console.WriteLine($"Modified at: {_user.ModifiedDate}".ToString());
                        Console.ReadKey();
                    }

                   



                }


            }




        }

        public async Task AddNewCommentAsync()
        {
            Console.Write("Write Email of ticket user: ");
            
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var _user = await UserService.GetSpecificTicketAsync(email);

                if (_user != null)
                {
                    Console.WriteLine($"TicketID: {_user.Id}");
                    Console.WriteLine($"Name: {_user.FirstName} {_user.LastName}");
                    Console.WriteLine($"E-postadress: {_user.Email}");
                    Console.WriteLine($"Telefonnummer: {_user.PhoneNumber}");
                    Console.WriteLine($"Address: {_user.DepartmentName}, {_user.StreetName}, {_user.PostalCode}, {_user.City}");
                    Console.WriteLine($"Description: {_user.Description}");
                    Console.WriteLine($"Text: {_user.TicketText}");
                    Console.WriteLine($"Status: {_user.Status}\r\n");


                    Console.WriteLine("\r\n Add new Comment on Ticket");



                    _user.Comment = Console.ReadLine() ?? null!;

                    await UserService.AddCommentAsync(_user);

                    Console.WriteLine($"Modified at: {_user.ModifiedDate}".ToString());
                    Console.WriteLine($" Comment  '{_user.Comment}' Has been added to the ticket. Press a button to continue ");
                    Console.ReadKey();


                   
                }


            }
        }

        public async Task DeleteATicketAsync()
        {
            Console.WriteLine("Enter the emial of the user");

            var _user = Console.ReadLine();

            if (!string.IsNullOrEmpty(_user))
            {
                await UserService.DeleteTicketAsync(_user);
            }
        }
    }
}
