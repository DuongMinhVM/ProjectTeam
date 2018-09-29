using EntityService.ViewModels;

namespace Project.APi.Models
{
    public class CategoryAddOutput
    {
        public bool Success { get; set; }
        public CategoryViewModel Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}