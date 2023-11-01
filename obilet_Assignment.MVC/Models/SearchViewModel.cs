using Microsoft.AspNetCore.Mvc.Rendering;

namespace obilet_Assignment.MVC.Models
{
    public class SearchViewModel
    {
        public string SelectedOption { get; set; }
        public List<SelectListItem> Options { get; set; }
    }
}
