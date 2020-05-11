using WebSchedule.BusinessLayer.Models;

namespace WebSchedule.BusinessLayer.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static RightsDto ToRightsDto(this string str)
        {
            return new RightsDto { Name = str };
        }
    }
}
