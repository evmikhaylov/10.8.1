using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string filePath = "Clients.txt";
			using(FileStream fs = new FileStream (filePath, FileMode.OpenOrCreate))
			{ fs.Close (); }

			var clients = Client.GetClients(filePath);

            Console.WriteLine("Выберите кто будет работать в системе\n1 Консультант\n2 Менеджер");
			switch (Console.ReadKey().Key)
			{
				
				case ConsoleKey.D1:
					{
						Console.Clear();
						Consultant consultant = new Consultant ();
						while (true)
						{
							consultant.ViewClients(clients);
							consultant.ChangePhoneNumber(clients, filePath);
							Console.Clear();
                        }
						break;
					}
				case ConsoleKey.D2:
					{
						Console.Clear();
						Manager manager = new Manager ();
						while (true)
						{
							manager.ViewClients(clients);
                            Console.WriteLine("\nНажмите 1 для смены номера телефона\nНажмите 2 для добавления нового клиента");
							switch(Console.ReadKey().Key)
							{
								case ConsoleKey.D1:
									Console.Clear();
									manager.ChangePhoneNumber(clients, filePath);
									Console.Clear();
									break;
								case ConsoleKey.D2:
									Console.Clear();
									manager.AddClient(clients, filePath);
									Console.Clear();
									break;
							}
                        }
						break;
					}
			}


        }
	}
}
