using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalManagement.Extensions;

public static class EnumExtension
{
    public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var enumValues = Enum.GetValues(enumType);
        return enumValues.Cast<Enum>().Select(x => new SelectListItem()
        {
            Text = x.GetDescription(),
            Value = x.ToString()
        });
    }
    public static string GetDescription(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description ?? string.Empty;
    }
}