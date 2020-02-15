using EpsilonEnterprise.Data;
using EpsilonEnterprise.Models;
using EpsilonEnterprise.Models.EnterpriseViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;


namespace EpsilonEnterprise.Pages.Bosss
{
    public class BossAssignmentsPageModel : PageModel
    {

        public List<AssignedAssignmentData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(BusinessContext context,
                                               Boss instructor)
        {
            var allCourses = context.Assignments;
            var instructorCourses = new HashSet<int>(
                instructor.AssignmentAssignments.Select(c => c.AssignmentID));
            AssignedCourseDataList = new List<AssignedAssignmentData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedAssignmentData
                {
                    AssignmentID = course.AssignmentID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.AssignmentID)
                });
            }
        }

        public void UpdateBossAssignments(BusinessContext context,
            string[] selectedCourses, Boss instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.AssignmentAssignments = new List<AssignmentAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.AssignmentAssignments.Select(c => c.Assignment.AssignmentID));
            foreach (var course in context.Assignments)
            {
                if (selectedCoursesHS.Contains(course.AssignmentID.ToString()))
                {
                    if (!instructorCourses.Contains(course.AssignmentID))
                    {
                        instructorToUpdate.AssignmentAssignments.Add(
                            new AssignmentAssignment
                            {
                                BossID = instructorToUpdate.ID,
                                AssignmentID = course.AssignmentID
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.AssignmentID))
                    {
                        AssignmentAssignment courseToRemove
                            = instructorToUpdate
                                .AssignmentAssignments
                                .SingleOrDefault(i => i.AssignmentID == course.AssignmentID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
