﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10._8._3;

namespace _10._8._3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string filePath = "Clients.txt";
			using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
			{ fs.Close(); }

			var clients = Client.GetClients(filePath);

			Console.WriteLine("Выберите кто будет работать в системе\n1 Консультант\n2 Менеджер");
			switch (Console.ReadKey().Key)
			{

				case ConsoleKey.D1:
					{
						Console.Clear();
						Consultant consultant = new Consultant();
						while (true)
						{
							string worker = "Консультант";
							consultant.ViewClients(clients, worker);
							consultant.ChangePhoneNumber(clients, filePath, worker);
							Console.Clear();
						}
						break;
					}
				case ConsoleKey.D2:
					{
						Console.Clear();
						Manager manager = new Manager();
						while (true)
						{
							string worker = "Менеджер";
							manager.ViewClients(clients, worker);
							Console.WriteLine("\nНажмите 1 для смены номера телефона\nНажмите 2 для добавления нового клиента");
							switch (Console.ReadKey().Key)
							{
								case ConsoleKey.D1:
									Console.Clear();
									manager.ChangePhoneNumber(clients, filePath, worker);
									Console.Clear();
									break;
								case ConsoleKey.D2:
									Console.Clear();
									manager.AddClient(clients, filePath, worker);
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
