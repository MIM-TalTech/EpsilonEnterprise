using EpsilonEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EpsilonEnterprise.Data
{
    public class DbInitializer
    {
        public static void Initialize(BusinessContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Employee{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Employee{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Employee{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };
            foreach (Employee s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();
            var boss = new Boss[]
            {
                new Boss { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Boss { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Boss { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Boss { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Boss { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Boss i in boss)
            {
                context.Boss.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    BossID  = boss.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    BossID  = boss.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    BossID  = boss.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    BossID  = boss.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var assignments = new Assignment[]
            {
                new Assignment{AssignmentID=1050,Title="Chemistry",Credits=3},
                new Assignment{AssignmentID=4022,Title="Microeconomics",Credits=3},
                new Assignment{AssignmentID=4041,Title="Macroeconomics",Credits=3},
                new Assignment{AssignmentID=1045,Title="Calculus",Credits=4},
                new Assignment{AssignmentID=3141,Title="Trigonometry",Credits=4},
                new Assignment{AssignmentID=2021,Title="Composition",Credits=3},
                new Assignment{AssignmentID=2042,Title="Literature",Credits=4}
            };
            foreach (Assignment c in assignments)
            {
                context.Assignments.Add(c);
            }
            context.SaveChanges();
            var officeAssignments = new OfficeAssignment[]
          {
                new OfficeAssignment {
                    BossID = boss.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    BossID = boss.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    BossID = boss.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
          };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();
            var assignmentboss = new AssignmentAssignment[]
          {
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Chemistry" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Kapoor").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Chemistry" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Harui").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Microeconomics" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Zheng").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Macroeconomics" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Zheng").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Calculus" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Fakhouri").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Trigonometry" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Harui").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Composition" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Abercrombie").ID
                    },
                new AssignmentAssignment {
                    AssignmentID = assignments.Single(c => c.Title == "Literature" ).AssignmentID,
                    BossID = boss.Single(i => i.LastName == "Abercrombie").ID
                    },
          };

            foreach (AssignmentAssignment ci in assignmentboss)
            {
                context.AssignmentAssignment.Add(ci);
            }
            context.SaveChanges();



            var enrollments = new Enrollment[]
            {
                new Enrollment{EmployeeID=1,AssignmentID=1050,Pay=Pay.A},
                new Enrollment{EmployeeID=1,AssignmentID=4022,Pay=Pay.C},
                new Enrollment{EmployeeID=1,AssignmentID=4041,Pay=Pay.B},
                new Enrollment{EmployeeID=2,AssignmentID=1045,Pay=Pay.B},
                new Enrollment{EmployeeID=2,AssignmentID=3141,Pay=Pay.F},
                new Enrollment{EmployeeID=2,AssignmentID=2021,Pay=Pay.F},
                new Enrollment{EmployeeID=3,AssignmentID=1050},
                new Enrollment{EmployeeID=4,AssignmentID=1050},
                new Enrollment{EmployeeID=4,AssignmentID=4022,Pay=Pay.F},
                new Enrollment{EmployeeID=5,AssignmentID=4041,Pay=Pay.C},
                new Enrollment{EmployeeID=6,AssignmentID=1045},
                new Enrollment{EmployeeID=7,AssignmentID=3141,Pay=Pay.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
