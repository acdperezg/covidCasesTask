namespace CovidCases.Models.Helper
{
    /// <summary>
    /// Contains the constants and global messages in the application
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public static class MessagesConstants
    {
        //Global messages
        public const string SUCCESS_MESSAGE = "Success";
        public const string ERROR_MESSAGE_REGION = "Sorry, there was an error retrieving the Regions list. We are already taking care of it.";
        public const string ERROR_MESSAGE_DATA = "Sorry, there was an error retrieving the Covid data. We are already taking care of it.";
        public const int RESULT_COUNT = 10;
        public const string SUCCESS_CODE = "SUCCESS";
        public const string ERROR_CODE = "ERROR";
        public const string NO_PROVINCE_NAME = "Non Provided";

        //Export types
        public const string EXPORT_FORMAT_JSON = "JSON";
        public const string EXPORT_FORMAT_XML = "XML";
        public const string EXPORT_FORMAT_CSV = "CSV";
    }
}
