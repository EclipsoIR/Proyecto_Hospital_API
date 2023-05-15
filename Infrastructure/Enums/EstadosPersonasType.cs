using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    public enum EstadosPersonasType
    {
        [Description("Trabajando")]
        Trabajando,

        [Description("Estudiando")]
        Estudiando,

        [Description("Parado")]
        Parado,

        [Description("Jubilado")]
        Jubilado,

        [Description("Baja Medica")]
        Baja_Medica
    }
}
