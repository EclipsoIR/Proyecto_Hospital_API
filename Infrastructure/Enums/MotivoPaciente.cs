using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    public enum MotivoPaciente
    {
        [Description("Malestar")]
        Malestar,

        [Description("Fiebre")]
        Fiebre,

        [Description("Resfriado")]
        Resfriado,

        [Description("Rotura de Hueso")]
        RoturaHueso,

        [Description("Accidente")]
        Accidente,

        [Description("Operacion")]
        Operacion
    }
}
