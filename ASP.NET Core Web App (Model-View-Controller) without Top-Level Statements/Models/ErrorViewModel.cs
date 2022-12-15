namespace ASP.NET_Core_Web_App__Model_View_Controller__without_Top_Level_Statements.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}