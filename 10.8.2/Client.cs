using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._2
{
	public class Client
	{
		public Client(int Id, string FamilyName, string FirstName, string LastName, string PhoneNumber, string SerialNumberDoc)
		{
			this.Id = Id;
			this.FamilyName = FamilyName;
			this.FirstName = FirstName;
			this.LastName = LastName;
			this.PhoneNumber = PhoneNumber;
			this.SerialNumberDoc = SerialNumberDoc;
		}

		public int Id { get; private set; }
		public string FamilyName { get; private set;}
		public string FirstName { get; private set;}
		public string LastName { get; private set;}
		public string PhoneNumber { get; set;}
		public virtual string SerialNumberDoc { get; private set;}

		public static List<Client> GetClients(string filePath)
		{
			var clients = new List<Client>();
			var lines = File.ReadAllLines(filePath);
			foreach (var line in lines)
			{
				var parts = line.Split(';');
				if (parts.Length >= 6)
				{
					var client = new Client(int.Parse(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5]);
					clients.Add(client);
				}
			}
			return clients;
		}
	}
}
