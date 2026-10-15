using System;
using WestCoastEducationAssignment.Interfaces;

namespace WestCoastEducationAssignment.CourseModels;

public class Course : ICourse
{
    public string CourseNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int DurationInWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual string GetCourseDetails()
    {
        return $"CourseNo: {CourseNumber}, Title: {Title}, Length {DurationInWeeks} weeks, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
    }
}
