
namespace Kaizen.Models.Theme
{
    public class ThemeModel
    {
        public int ThemeId { get; set; } 
        public string Theme { get; set; }

        public DateTime? StartDate { get; set; } // New property for start date
        public DateTime? EndDate { get; set; }   // New property for end date
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool isActive
        {
            get
            {
                // Active if the current date is between StartDate and EndDate
                return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
            }
        } // Add this line
    }
}
