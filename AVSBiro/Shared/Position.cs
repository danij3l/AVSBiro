using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSBiro.Shared
{
    public class Position
    {
        private int _id;
        private string _name;
        private int _payRank;
        private bool _obsolete;


        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int PayRank { get { return _payRank; } set { _payRank = value; } }
        public bool Obsolete { get { return _obsolete; } set { _obsolete = value; } }
        public Position(int _id, string _name, int _payRank, bool _obsolete)
        {
            this.Id = _id;
            this.Name = _name;
            this._payRank = _payRank;
            this._obsolete = _obsolete;
        }
    }
}
