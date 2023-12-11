using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._8._1
{	
	public class ClientData
	{
		public string ClientFirstName { get; private set; }
		public string ClientFamilyName { get; private set; }
		public string ClientLastName { get; private set; }
		private string clientNumberPhone;
		public string ClientNumberPhone
		{
			get { return clientNumberPhone; }
			set
			{
				if (string.IsNullOrEmpty(value))
				throw new ArgumentException("Номер телефона не может быть пустым");
				clientNumberPhone = value;
			}
		}
		private ushort ClientSerialDoc;
		private uint ClientNumberDoc;

		public string ViewSerialDoc => ClientSerialDoc !=0 ? "****" : null;
		public string ViewNumberDoc => ClientNumberDoc !=0 ? "******" : null;

		public ClientData(string clientFirstName, string clientFamilyName, string clientLastName, string clientNumberPhone, ushort clientSerialDoc, uint clientNumberDoc)
		{
			ClientFirstName = clientFirstName;
			ClientFamilyName = clientFamilyName;
			ClientLastName = clientLastName;
			ClientNumberPhone = clientNumberPhone;
			ClientSerialDoc = clientSerialDoc;
			ClientNumberDoc = clientNumberDoc;
		}

	}
}
