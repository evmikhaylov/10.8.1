using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._3
{
	public class Client
	{
		public string LastModified { get; set; }
		public string ModifiedData { get; set; }
		public string ChangeType { get; set; }
		public string ModifiedBy {  get; set; }
		public Client(int Id, string FamilyName, string FirstName, string LastName, string PhoneNumber, string SerialNumberDoc, string LastModified, string ModifiedData,
			string ChangeType, string ModifiedBy)
		{
			this.Id = Id;
			this.FamilyName = FamilyName;
			this.FirstName = FirstName;
			this.LastName = LastName;
			this.PhoneNumber = PhoneNumber;
			this.SerialNumberDoc = SerialNumberDoc;
			this.LastModified = LastModified;
			this.ModifiedData = ModifiedData;
			this.ChangeType = ChangeType;
			this.ModifiedBy = ModifiedBy;
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
				if (parts.Length >= 10)
				{
					var client = new Client(int.Parse(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5],
					parts[6], parts[7], parts[8], parts[9]);
					clients.Add(client);
				}
			}
			return clients;
		}

		public string GetClientInfo(string worker)
		{
			switch (worker)
			{
				case "Консультант":
					return $"{Id} {FamilyName} {FirstName} {LastName} {PhoneNumber} **** ******";
				case "Менеджер":
					return $"{Id} {FamilyName} {FirstName} {LastName} {PhoneNumber} {SerialNumberDoc}";
				default:
					throw new ArgumentException("Роль не распознана");

			}
		}
	}
}
