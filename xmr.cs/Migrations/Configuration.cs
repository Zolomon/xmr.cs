using System.IO;

namespace xmr.cs.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using xmr.cs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<xmr.cs.Models.XmrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(xmr.cs.Models.XmrContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            
            var courses = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "Content", "images", "courses"));
            int courseId = 0;
            int examId = 0;
            int problemId = 0;
            int answerId = 0;
            int questionId = 0;
            int problemIndex = 0;
            foreach (var course in courses)
            {
                var courseCode = Path.GetFileName(course);
                context.Courses.Add(new Course
                {
                    ID = courseId,
                    Code = courseCode
                });

                foreach (var examPath in Directory.GetDirectories(Path.Combine(course, "exams")))
                {
                    var examName = Path.GetFileName(examPath);
                    context.Exams.Add(new Exam
                    {
                        ID = examId,
                        CourseID = courseId,
                        Code = examName
                    });

                    var solutionPath = Path.Combine(course, "solutions", examName);
                    var ifSolutionExists = Directory.Exists(solutionPath);
                    
                    foreach (var problem in Directory.GetFiles(examPath))
                    {
                        var questionFileName = Path.GetFileName(problem);
                        var p = new Problem()
                        {
                            ID = problemId,
                            ExamID = examId,
                            Index = problemIndex
                        };
                        context.Problems.Add(p);

                        context.Questions.Add(new Question
                        {
                            FileName = questionFileName,
                            ID = questionId,
                            ProblemID = problemId
                        });

                        var answerFileName = problem.Replace("exams", "solutions");
                        // Check if folder and file exists
                        if (ifSolutionExists && File.Exists(answerFileName))
                        {
                            context.Answers.Add(new Answer
                            {
                                ID = answerId,
                                ProblemID = problemId,
                                FileName = Path.GetFileName(answerFileName)
                            });
                            answerId++;
                        }

                        problemId++;
                        questionId++;
                        problemIndex++;
                    }

                    examId++;
                }
                courseId++;
            }
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
