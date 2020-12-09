using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Staff
    {
        private int staffId;
        private String staffName;
        private DateTime dateOfBirth;
        private string address;
        private string phoneNumber;
        private bool gender;

        public int StaffId { get => staffId; set => staffId = value; }
        public String StaffName { get => staffName; set => staffName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool Gender { get => gender; set => gender = value; }

        public Staff()
        {

        }

        public Staff(int _staffId, string _staffName, DateTime _dateOfBirth, string _address, string _phoneNumber, bool _gender)
        {
            this.staffId = _staffId;
            this.staffName = _staffName;
            this.dateOfBirth = _dateOfBirth;
            this.address = _address;
            this.phoneNumber = _phoneNumber;
            this.gender = _gender;
        }
    }
}
