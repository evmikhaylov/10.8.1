using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._3
{
	public interface IConsultant
	{
		void ChangePhoneNumber(List<Client> clients, string filePath, string worker);
		void ViewClients(List<Client> clients, string worker);
	}
	public class Consultant : IConsultant
	{
		public virtual void ViewClients (List<Client> clients, string worker)
		{
			foreach (Client client in clients)
			{
                Console.WriteLine(client.GetClientInfo(worker));
            }
		}
		
		public void SaveClients (List<Client> clients, string filePath)
		{
			var lines = new List<string>();
			foreach (var client in clients)
			{
				var line = $"{client.Id};{client.FamilyName};{client.FirstName};{client.LastName};{client.PhoneNumber};{client.SerialNumberDoc};{client.LastModified};" +
					$"{client.ModifiedData};{client.ChangeType};{client.ModifiedBy};";
				lines.Add(line);
			} 
			File.WriteAllLines(filePath, lines);
		}

		public void ChangePhoneNumber(List<Client> clients, string filePath, string worker)
		{
			Console.WriteLine("\nВведите ID для смены номера");
			int id = Int32.Parse(Console.ReadLine());
			var client = clients.FirstOrDefault(c => c.Id == id);
			
			if (client != null) 
			{
				Console.WriteLine("Введите новый номер телефона");
				string newPhoneNumber = Console.ReadLine();
				if (string.IsNullOrEmpty(newPhoneNumber))
				{
					throw new ArgumentNullException("Номер телефона не может быть пустым");
				}
				client.PhoneNumber = newPhoneNumber;
				client.LastModified = DateTime.Now.ToString();
				client.ModifiedData = "PhoneNumber";
				client.ChangeType = "Изменено";
				client.ModifiedBy = worker;
				SaveClients(clients, filePath);
			}
		}
	}
}
