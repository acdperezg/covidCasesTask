using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CovidCases.BusinessRepository.ExportData.Csv
{
    /// <summary>
    /// Implementation of the interface
    /// </summary>
    /// <remarks>Author: Dariel Pérez</remarks>
    public class CsvExport : ICsvExport
    {
        /// <summary>
        /// Transforms a json object to a byte array
        /// </summary>
        /// <param name="jsonList">Json list object</param>
        /// <returns>Byte array of the Json object provided by parameters</returns>
        public byte[] ExportReport(string jsonList)
        {
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(jsonList);
            StringBuilder sb = new StringBuilder();
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            var valueLines = dataTable.AsEnumerable()
                              .Select(row => string.Join(",", row.ItemArray));
            foreach (var line in valueLines)
            {
                sb.AppendLine(line);
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
