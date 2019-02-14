using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Schuhladen_WW.Mapping
{
    public class PropertyMapper<BaseClass> where BaseClass : class, new()
    {
        public BaseClass Map(DataRow dr_Row)
        {
            BaseClass _BaseClass = new BaseClass();
            return Map(dr_Row, _BaseClass);
        }

        public BaseClass Map(DataRow dr_Row, BaseClass _BaseClass)
        {
            var var_ColumnNames = dr_Row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            var var_PropertyBridgeAttributes = (typeof(BaseClass)).GetProperties().Where(x => x.GetCustomAttributes(typeof(PropertyBridge), true).Any());

            foreach (var Property in var_PropertyBridgeAttributes)
            {
                PropertyToObject.MapPropertyToObject(typeof(BaseClass), dr_Row, Property, _BaseClass);
            }
            return _BaseClass;
        }

        public IEnumerable<BaseClass> Map(DataTable dt_DataTable)
        {
            List<BaseClass> __InstancesOfBaseClass = new List<BaseClass>();
            var var_ColumnNames = dt_DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            var var_PropertyBridgeAttributes = (typeof(BaseClass)).GetProperties().Where(x => x.GetCustomAttributes(typeof(PropertyBridge), true).Any());

            foreach (DataRow dr_Row in dt_DataTable.Rows)
            {
                BaseClass _BaseClass = new BaseClass();
                foreach (var var_Property in var_PropertyBridgeAttributes)
                {
                    PropertyToObject.MapPropertyToObject(typeof(BaseClass), dr_Row, var_Property, _BaseClass);
                }
                __InstancesOfBaseClass.Add(_BaseClass);
            }

            return __InstancesOfBaseClass;
        }
    }
}
