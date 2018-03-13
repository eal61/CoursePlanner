using CoursePlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Services
{
    public class CoursePlanService
    {
        public int getCreditsAttained(CoursePlan plan)
        {
            int totalCredits = 0;

            plan.Semesters.ForEach(s => s.Courses.ForEach(c => totalCredits += c.Credits));

            return totalCredits;
        }

    }
}