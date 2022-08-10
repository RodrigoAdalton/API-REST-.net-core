using System;

namespace Api.Domain.Models
{
    public class CityModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _codIBGE;
        public int CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }

        private Guid _stateId;
        public Guid StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }
    }
}
