using System;

namespace Api.Domain.Models
{
    public class StateModel : BaseModel
    {
        private string _initial;
        public string Initial
        {
            get { return _initial; }
            set { _initial = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
