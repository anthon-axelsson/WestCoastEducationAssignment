using System;

namespace WestCoastEducationAssignment.Interfaces;

public interface ICourse
{
    string CourseNumber { get; set; }
    string Title { get; set; }
    int DurationInWeeks { get; set; }
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    string GetCourseDetails();
}
