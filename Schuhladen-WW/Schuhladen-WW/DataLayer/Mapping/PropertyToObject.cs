using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using Schuhladen_WW.Mapping.Generic;

namespace Schuhladen_WW.Mapping
{
    public static class PropertyToObject
    {
        public static void MapPropertyToObject (Type _Type, DataRow dt_Row, PropertyInfo _PropertyInfo, object obj_BaseClass)
        {
            string str_ColumnName = PropertyValues.GetPropertyValues(_Type, _PropertyInfo.Name);

            if (!String.IsNullOrWhiteSpace(str_ColumnName) && dt_Row.Table.Columns.Contains(str_ColumnName))
            {
                var var_PropertyValue = dt_Row[str_ColumnName];
                if (var_PropertyValue != DBNull.Value)
                {
                    switch(Type.GetTypeCode(var_PropertyValue.GetType()))
                    {
                        case TypeCode.String:
                            _PropertyInfo = CastPrimitives.CastToString (_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.Int32:
                            _PropertyInfo = CastPrimitives.CastToInt (_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.Boolean:
                            _PropertyInfo = CastPrimitives.CastToBool (_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.Decimal:
                            _PropertyInfo = CastPrimitives.CastToDecimal (_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.Double:
                            _PropertyInfo = CastPrimitives.CastToDouble (_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.DateTime:
                            _PropertyInfo = CastPrimitives.CastToDateTime(_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                        case TypeCode.Int64:
                            _PropertyInfo = CastPrimitives.CastToLong(_PropertyInfo, obj_BaseClass, dt_Row[str_ColumnName]);
                            break;
                    }
                }
            }
        }
    }
}
