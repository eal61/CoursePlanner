using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Services
{
    public class SemesterService
    {
        public int getTotalCredits(int semester, int student_id)
        {
            int totalCredits = 0;

            plan.Semesters.ForEach(s => s.Courses.ForEach(c => totalCredits += c.Credits));

            return totalCredits;
        }
    }
}