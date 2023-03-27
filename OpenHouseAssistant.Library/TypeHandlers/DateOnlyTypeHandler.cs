using System.Data;
using Dapper;

namespace OpenHouseAssistant.Library.TypeHandlers;

public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value)
    {
        return DateOnly.FromDateTime((DateTime)value);
    }

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.Value = value;
    }
}

