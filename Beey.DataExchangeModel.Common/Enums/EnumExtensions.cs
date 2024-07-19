using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Common.Enums;
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        // Get the type of the enum
        Type type = value.GetType();

        // Get the field information for the enum value
        FieldInfo fieldInfo = type.GetField(value.ToString());

        // Get the DescriptionAttribute on the enum value, if it exists
        DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        // Return the description if the attribute exists; otherwise, return the enum value's name
        return attribute?.Description ?? value.ToString();
    }
}
