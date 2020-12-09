using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Client
    {
        private int clientId;
        private string clientName;
        private string address;
        private string phoneNumber;

        public int ClientId { get => clientId; set => clientId = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Client()
        {

        }

        public Client(int _clientId, string _clientName, string _address, string _phoneNumber)
        {
            this.clientId = _clientId;
            this.clientName = _clientName;
            this.address = _address;
            this.phoneNumber = _phoneNumber;
        }
    }
}
