using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._1
{
	public interface IWorker
	{
		ClientData ViewClientData(ClientData client);
		void UpdatePhoneNumber (ClientData client, string phoneNumber);
		void DisplayClient (ClientData client);
	}

	public class Consultant : IWorker
	{
		public ClientData ViewClientData(ClientData client)
		{
			return client;
		}

		public void UpdatePhoneNumber (ClientData client, string phoneNumber)
		{
			client.ClientNumberPhone = phoneNumber;
		}
		public void DisplayClient (ClientData client)
		{
            Console.WriteLine($"Имя: {client.ClientFirstName}, фамилия: {client.ClientFamilyName}, отчество: {client.ClientLastName}, \nНомер телефона: {client.ClientNumberPhone}" +
				$" Серия и номер паспорта {client.ViewSerialDoc} {client.ViewNumberDoc}");
        }
	}
}
