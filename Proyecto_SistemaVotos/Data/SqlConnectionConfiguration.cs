using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_TiendaOnline.Data
{
    public class SqlConnectionConfiguration
    {
        public string Value { get; }
        public SqlConnectionConfiguration(string value) => Value = value;
    }
}
