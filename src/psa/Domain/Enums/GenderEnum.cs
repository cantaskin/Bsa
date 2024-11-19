using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;
public enum GenderEnum
{
    [Description("Female")]
    Female = 1,
    [Description("Male")]
    Male = 2,
}
