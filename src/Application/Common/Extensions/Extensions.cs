using System.Reflection;
using ArchitectureSolutions.Application.Common.Models;

namespace ArchitectureSolutions.Application.Common.Extensions;
static public class Extensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="patchDto"></param>
    /// <param name="obj"></param>
    public static void ApplyTo(this PatchDtoBase @this, Object obj)
    {
        Type type = @this.GetType();
        foreach (var prop in type.GetProperties(BindingFlags.Public))
        {
            if(@this.IsFieldPresent(prop.Name))
            {
                prop.SetValue(obj, @this.GetPropertyValue(prop.Name));
            }
        }
    }

    /// <summary>
    /// A extension method that gets public property value.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns>The property value.</returns>
    public static object GetPropertyValue(this object @this, string propertyName)
    {
        Type type = @this.GetType();
        PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public);
        return property.GetValue(@this, null);
    }


}
