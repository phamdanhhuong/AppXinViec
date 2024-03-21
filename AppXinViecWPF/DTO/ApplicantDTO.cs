using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class ApplicantDTO
    {
        string name;
        string gender;
        string phone;
        DateTime birth;

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Birth { get => birth; set => birth = value; }

        public ApplicantDTO(string name, string gender, string phone, DateTime birth) 
        { 
            Name = name;
            Gender = gender;    
            Phone = phone;
            Birth = birth;
        }

    }
}
