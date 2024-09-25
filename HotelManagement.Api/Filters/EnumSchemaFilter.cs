using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.OpenApi.Any;

    /// <summary>
    /// Выводим имя,а не значение енамки для отображения в swagger
    /// </summary>
public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
            return;

        schema.Enum.Clear();

        foreach (var name in Enum.GetNames(context.Type))
        {
            var memberInfo = context.Type.GetMember(name);
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            var displayName = displayAttribute?.Name ?? name; 

            schema.Enum.Add(new OpenApiString(displayName));
        }
    }
}