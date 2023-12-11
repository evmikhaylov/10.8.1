using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._2
{
	internal class Manager : Consultant
	{
		public override void ViewClients(List<Client> clients)
		{
			foreach (Client client in clients)
			{
				Console.WriteLine($"{client.Id} {client.FamilyName} {client.FirstName} {client.LastName} {client.PhoneNumber} {client.SerialNumberDoc}");
			}
		}
		public void AddClient(List<Client> clients, string filePath)
		{
			int id = clients.Count + 1;
            Console.WriteLine("Введите фамилию");
            string familyName=Console.ReadLine();
            Console.WriteLine("Введите имя");
			string firstName = Console.ReadLine();
            Console.WriteLine("Введите отчество");
			string lastName = Console.ReadLine();
            Console.WriteLine("Введит номер телефона");
			string phoneNumber = Console.ReadLine();
            Console.WriteLine("Введите серию паспорта");
			string serialDoc = Console.ReadLine();
            Console.WriteLine("Введите номер паспорта");
			string numberDoc = Console.ReadLine();
			string serialNumberDoc = $"{serialDoc} {numberDoc}";

			var newClient = new Client(id, familyName, firstName, lastName, phoneNumber, serialNumberDoc);
			clients.Add(newClient);
			SaveClients(clients, filePath);
		}
	}
}
