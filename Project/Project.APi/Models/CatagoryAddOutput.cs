using EntityService.ViewModels;

namespace Project.APi.Models
{
    public class CatagoryAddOutput
    {
        public bool Success { get; set; }
        public CatagoryViewModel Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}