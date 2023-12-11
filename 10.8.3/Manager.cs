using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._3
{ 
	interface IManager : IConsultant
	{
		void AddClient(List<Client> clients, string filePath, string worker);
	}
	internal class Manager : Consultant, IManager
	{
		public void AddClient(List<Client> clients, string filePath, string worker)
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
			string lastModified = DateTime.Now.ToString();
			string modifiedData = "Все данные";
			string changeType = "Добавлено";
			string modifiedBy = worker;

			var newClient = new Client(id, familyName, firstName, lastName, phoneNumber, serialNumberDoc, lastModified, modifiedData, changeType, modifiedBy);
			
			clients.Add(newClient);
			SaveClients(clients, filePath);
		}
	}
}
