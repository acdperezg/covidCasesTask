namespace CovidCases.Models
{
    /// <summary>
    /// Contains the common response for all the request made to the application
    /// </summary>
    /// <remarks>Autor: Dariel Pérez</remarks>
    public class BaseResponse
    {
        /// <summary>
        /// The message of the request. For more information check <code>MessagesConstants</code> class
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Code of the request. Can be either SUCCESS or ERROR
        /// </summary>
        public string Code { get; set; }
    }
}
