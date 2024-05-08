using System.Data;
using System.Reflection;

namespace Rfid.Class
{
    public class ListtoTable
    {
        public DataTable ToDataTablee<T>(List<T> items)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new Object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
