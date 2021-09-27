using Microsoft.AspNetCore.Mvc;

namespace CovidCases.BusinessRepository.ExportData.ExportBusiness
{
    public interface IExportBusinessRepository
    {
        FileContentResult GetByteArray(string jsonList, string format);
    }
}
