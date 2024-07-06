using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Activity> Activities; 
        public void OnGet()
        {
            ActivityService activityService = new ActivityService();
            Activities = activityService.GetActivities();

        }
    }
}