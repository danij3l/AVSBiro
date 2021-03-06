using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSBiro.Shared
{
    public class Employee
    {
        int _id;
        string _firstName;
        string _lastName;
        decimal _brutto2;
        bool _paidOvertime;
        bool _employmentEnded;
        Position _position;
        string _contract;
        string _IBAN;
        bool _obsolete;

        public int Id { get { return _id; } set { _id = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public decimal Brutto2 { get { return _brutto2; } set { _brutto2 = value; } }
        public bool PaidOvertime { get { return _paidOvertime; } set { _paidOvertime = value; } }
        public bool EmploymentEnded { get { return _employmentEnded; } set { _employmentEnded = value; } }
        public Position? Position { get; set; }
        public string Contract { get { return _contract; } set { _contract = value; } }
        public string IBAN { get { return _IBAN; } set { _IBAN = value; } }
        public bool Obsolete { get { return _obsolete; } set { _obsolete = value; } }

        public int PositionId { get; set; }
    }
}
