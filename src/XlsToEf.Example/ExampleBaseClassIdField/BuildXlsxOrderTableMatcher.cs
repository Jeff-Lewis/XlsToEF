using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using XlsToEf.Example.Domain;
using XlsToEf.Import;

namespace XlsToEf.Example.ExampleBaseClassIdField
{
    public class BuildXlsxOrderTableMatcher : IRequestHandler<XlsxOrderColumnMatcherQuery, DataForMatcherUi>
    {
        private readonly IExcelIoWrapper _excelIoWrapper;

        public BuildXlsxOrderTableMatcher(IExcelIoWrapper excelIoWrapper)
        {
            _excelIoWrapper = excelIoWrapper;
        }

        public async Task<DataForMatcherUi> Handle(XlsxOrderColumnMatcherQuery message, CancellationToken cancellationToken)
        {
            message.FilePath = Path.GetTempPath() + message.FileName;
            var order = new Order();

            var columnData = new DataForMatcherUi
            {
                XlsxColumns = (await _excelIoWrapper.GetImportColumnData(message)).ToArray(),
                FileName = message.FileName,
                TableColumns = new List<TableColumnConfiguration>
                {
                    TableColumnConfiguration.Create(() => order.Id, new SingleColumnData("Order ID")),
                    TableColumnConfiguration.Create(() => order.OrderDate, new SingleColumnData("Order Date", required: false)),
                }
            };

            return columnData;
        }
    }
}