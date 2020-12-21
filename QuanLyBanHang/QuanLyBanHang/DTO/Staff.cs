using System;
using System.Collections.Generic;
using System.Data;
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

        public Staff(int staffId, string staffName, DateTime dateOfBirth, string address, string phoneNumber, bool gender)
        {
            this.StaffId = staffId;
            this.StaffName = staffName;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Gender = gender;
        }

        public Staff(DataRow row)
        {
            this.StaffId = (int)row["staffId"];
            this.StaffName = row["staffName"].ToString();
            this.DateOfBirth = (DateTime)row["dateOfBirth"];
            this.Address = row["address"].ToString();
            this.PhoneNumber = row["phoneNumber"].ToString();
            this.Gender = (bool)row["gender"];
        }
    }
}
