using System;
using System.ComponentModel.DataAnnotations;

namespace Delux.Aids
{
    public class MyDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) >= DateTime.Now)
            {
                if (Convert.ToDateTime(value).DayOfWeek == DayOfWeek.Sunday)
                {
                    return new ValidationResult("Oleme pühapäeviti suletud!");
                }
                else if (Convert.ToDateTime(value).DayOfWeek == DayOfWeek.Saturday)
                {
                    if (Convert.ToDateTime(value).TimeOfDay >= TimeSpan.Parse("11:00") && Convert.ToDateTime(value).TimeOfDay <= TimeSpan.Parse("16:30"))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Oleme laupäeviti avatud 11-17. Viimaseid broneeringuid võtame vastu kell 16:30");
                    }
                }
                else
                {
                    if (Convert.ToDateTime(value).TimeOfDay >= TimeSpan.Parse("09:00") && Convert.ToDateTime(value).TimeOfDay <= TimeSpan.Parse("18:30"))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Oleme argipäeviti avatud 9-19. Viimaseid broneeringuid võtame vastu kell 18:30");
                    }
                }
            }

            return new ValidationResult("Sisestage õige kuupäev!");
        }
    }
}