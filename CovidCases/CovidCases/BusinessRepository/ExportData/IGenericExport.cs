namespace CovidCases.BusinessRepository.ExportData
{
    public interface IGenericExport
    {
        byte[] ExportReport(string jsonList);
    }
}
