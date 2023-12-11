using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ClientData client = new ClientData ("Иван", "Иванов", "Иванович", "79995283416", 1234, 123456);

			IWorker consultant = new Consultant();

			ClientData viewedClient = consultant.ViewClientData(client);

            consultant.DisplayClient(viewedClient);
            Console.WriteLine("Обновление номера");
            consultant.UpdatePhoneNumber(client, Console.ReadLine());
            Console.WriteLine("Актуальная информация");
			consultant.DisplayClient(viewedClient);
			Console.ReadLine();
        }
	}
}
