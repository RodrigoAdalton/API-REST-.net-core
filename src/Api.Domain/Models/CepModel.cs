using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class CepModel : BaseModel
    {
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = string.IsNullOrEmpty(value) ? "S/N" : value;
            }
        }

        private Guid _cityId;
        public Guid CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
    }
}
