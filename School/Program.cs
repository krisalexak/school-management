using School.Models;
using System;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (MainView.login())
            {
            case (int)User.Exit:

                Environment.Exit(0);
                break;

            case (int)User.Student:

                string studentUserName = StudentManager.getUserName();
                
                Student student = StudentManager.getPassword(studentUserName);

                do
                {
                    switch (StudentView.menu())
                    {
                    case (int)StudentQuery.Exit:

                        Environment.Exit(0);
                        break;

                    case (int)StudentQuery.Enroll:

                        var newCourses = StudentManager.getNewCourses(student);
                        if (newCourses.Count != 0)
                        {
                            var enrollInput = StudentView.enrollMenu(newCourses);
                            var newCourseID = newCourses[enrollInput].Id;
                            StudentManager.enrollStudent(student, newCourseID);
                        }
                        else StudentView.enrollFail();
                        break;

                    case (int)StudentQuery.Submit:

                        var pendingAssignments = StudentManager.submitAssignment(student);
                        var submitInput = StudentView.submitAssignment(pendingAssignments);
                        StudentAssignmentManager.CreateStudentAssignment(student, pendingAssignments[submitInput]);
                        break;

                    case (int)StudentQuery.Schedule:

                        var currentCourses = StudentManager.getCurrentCourses(student);
                        StudentView.showSchedule(currentCourses);
                        break;

                    case (int)StudentQuery.SubmissionDates:

                        var currentAssignments = StudentManager.getCurrentAssignments(student);
                        StudentView.showSubmissionDates(currentAssignments);
                        break;
                    }
                } while (true);

            case (int)User.Trainer:

                string trainerUserName = TrainerManager.getUserName();
                Trainer trainer = TrainerManager.getPassword(trainerUserName);

                do
                {
                    switch (TrainerView.menu())
                    {
                    case (int)TrainerQuery.Exit:
                        break;

                    case (int)TrainerQuery.Courses:
                        var currentCourses = TrainerManager.getCourses(trainer);
                        if (currentCourses.Count != 0)
                        {
                            TrainerView.showCourses(currentCourses);
                        }
                        else TrainerView.showCoursesFail();
                        break;

                    case (int)TrainerQuery.Students:
                        TrainerView.showStudents(TrainerManager.getCourses());
                        break;

                    case (int)TrainerQuery.Assignments:

                        TrainerView.showAssignments(TrainerManager.getCourses());
                        break;

                    case (int)TrainerQuery.MarkAssignments:
                        var courses = TrainerManager.getCourses(trainer);
                        if (courses.Count != 0)
                        {
                            var courseInput = TrainerView.selectCourse(courses);
                            var markAssignments = TrainerManager.getAssignments(courses[courseInput]);
                            var assignmentInput = TrainerView.selectAssignment(markAssignments);
                            var markStudents = TrainerManager.getStudents(courses[courseInput]);
                            var studentInput = TrainerView.selectStudent(markStudents);
                            var finalMark = TrainerView.markAssignment();
                            TrainerManager.markAssignment(finalMark, markAssignments[assignmentInput], markStudents[studentInput]);
                        }
                        else TrainerView.showCoursesFail();

                        break;
                    }
                } while (true);

            case (int)User.HeadMaster:

                string hmUserName = HeadMasterManager.getUserName();
                HeadMasterManager.getPassword(hmUserName);

                do
                {
                    switch (HeadMasterView.menu())
                    {
                    case (int)MasterQuery.Exit:
                        break;

                    case (int)MasterQuery.Courses:

                        switch (HeadMasterView.entityMenu("courses"))
                        {
                        case (int)Action.Create:
                            CourseManager.createCourse(CourseView.createCourse());
                            break;

                        case (int)Action.Read:
                            CourseView.showCourses(CourseManager.getCourses());
                            break;

                        case (int)Action.Update:
                            {
                                var courses = CourseManager.getCourses();
                                var courseInput = CourseView.courseMenu(courses);
                                CourseManager.updateCourse(courses[courseInput]);
                                break;
                            }
                        case (int)Action.Delete:
                            {
                                var courses = CourseManager.getCourses();
                                var courseInput = CourseView.courseMenu(courses);
                                CourseManager.deleteCourse(courses[courseInput]);
                                break;
                            }
                        }
                        break;

                    case (int)MasterQuery.Students:
                        switch (HeadMasterView.entityMenu("students"))
                        {
                        case (int)Action.Create:

                            StudentManager.createStudent(StudentView.createStudent());
                            break;

                        case (int)Action.Read:

                            StudentView.showStudents(StudentManager.getStudents());
                            break;

                        case (int)Action.Update:
                            {
                                var students = StudentManager.getStudents();
                                var studentInput = StudentView.studentMenu(students);
                                StudentManager.updateStudent(students[studentInput]);
                            }

                            break;

                        case (int)Action.Delete:
                            {
                                var students = StudentManager.getStudents();
                                var studentInput = StudentView.studentMenu(students);
                                StudentManager.deleteStudent(students[studentInput]);
                            }
                            break;
                        }
                        break;

                    case (int)MasterQuery.Assignments:
                        switch (HeadMasterView.entityMenu("assignments"))
                        {
                        case (int)Action.Create:

                            AssignmentManager.createAssignment(AssignmentView.createAssignment());
                            break;

                        case (int)Action.Read:
                            AssignmentView.showAssignments(AssignmentManager.getAssignments());
                            break;

                        case (int)Action.Update:
                            {
                                var assignments = AssignmentManager.getAssignments();
                                var assignmentInput = AssignmentView.assignmentMenu(assignments);
                                AssignmentManager.updateAssignment(assignments[assignmentInput]);
                            }
                            break;

                        case (int)Action.Delete:
                            {
                                var assignments = AssignmentManager.getAssignments();
                                var assignmentInput = AssignmentView.assignmentMenu(assignments);
                                AssignmentManager.deleteAssignment(assignments[assignmentInput]);
                            }
                            break;
                        }
                        break;

                    case (int)MasterQuery.Trainers:
                        switch (HeadMasterView.entityMenu("trainers"))
                        {
                        case (int)Action.Create:

                            TrainerManager.createTrainer(TrainerView.createTrainer());
                            break;

                        case (int)Action.Read:

                            TrainerView.showTrainers(TrainerManager.getTrainers());
                            break;

                        case (int)Action.Update:
                            {
                                var trainers = TrainerManager.getTrainers();
                                var trainerInput = TrainerView.trainerMenu(trainers);
                                TrainerManager.updateTrainer(trainers[trainerInput]);
                            }
                            break;

                        case (int)Action.Delete:
                            {
                                var trainers = TrainerManager.getTrainers();
                                var trainerInput = TrainerView.trainerMenu(trainers);
                                TrainerManager.deleteTrainer(trainers[trainerInput]);
                            }
                            break;
                        }
                        break;

                    case (int)MasterQuery.StudentsCourses:
                        {
                            var cours = CourseManager.getCourses();
                            var courseIn = CourseView.courseMenu(cours);

                            switch (HeadMasterView.entityPerMenu("students for the selected course"))
                            {
                            case (int)PAction.Create:
                                {
                                    StudentManager.createStudent(StudentView.createStudent(cours[courseIn]));
                                }
                                break;

                            case (int)PAction.Update:
                                {
                                    var students = StudentManager.getStudents(cours[courseIn]);
                                    var studentInput = StudentView.studentMenu(students);
                                    StudentManager.updateStudent(students[studentInput]);
                                }
                                break;

                            case (int)PAction.Delete:
                                {
                                    var students = StudentManager.getStudents(cours[courseIn]);
                                    var studentInput = StudentView.studentMenu(students);
                                    StudentManager.deleteStudent(students[studentInput]);
                                }
                                break;
                            }
                        }

                        break;

                    case (int)MasterQuery.TrainersCourses:
                        {
                            var cours = CourseManager.getCourses();
                            var courseIn = CourseView.courseMenu(cours);
                            switch (HeadMasterView.entityPerMenu("trainers for the selected course"))
                            {
                            case (int)PAction.Create:
                                TrainerManager.createTrainer(TrainerView.createTrainer(cours[courseIn]));
                                break;

                            case (int)PAction.Update:
                                {
                                    var trainers = TrainerManager.getTrainers(cours[courseIn]);
                                    var trainerInput = TrainerView.trainerMenu(trainers);
                                    TrainerManager.updateTrainer(trainers[trainerInput]);
                                }
                                break;

                            case (int)PAction.Delete:
                                {
                                    var trainers = TrainerManager.getTrainers(cours[courseIn]);
                                    var trainerInput = TrainerView.trainerMenu(trainers);
                                    TrainerManager.deleteTrainer(trainers[trainerInput]);
                                }
                                break;
                            }
                        }
                        break;

                    case (int)MasterQuery.AssignmentsCourses:
                        {
                            var cours = CourseManager.getCourses();
                            var courseIn = CourseView.courseMenu(cours);
                            switch (HeadMasterView.entityPerMenu("assignments for the selected course"))
                            {
                            case (int)PAction.Create:
                                AssignmentManager.createAssignment(AssignmentView.createAssignment(cours[courseIn]));
                                break;

                            case (int)PAction.Update:
                                {
                                    var assignments = AssignmentManager.getAssignments(cours[courseIn]);
                                    var assignmentInput = AssignmentView.assignmentMenu(assignments);
                                    AssignmentManager.updateAssignment(assignments[assignmentInput]);
                                }
                                break;

                            case (int)PAction.Delete:
                                {
                                    var assignments = AssignmentManager.getAssignments(cours[courseIn]);
                                    var assignmentInput = AssignmentView.assignmentMenu(assignments);
                                    AssignmentManager.deleteAssignment(assignments[assignmentInput]);
                                }
                                break;
                            }
                        }

                        break;

                    case (int)MasterQuery.ScheduleCourses:
                        {
                            var cours = CourseManager.getCourses();
                            var courseIn = CourseView.courseMenu(cours);
                            switch (HeadMasterView.ScheduleMenu("schedules per course"))
                            {
                            case (int)PAction.Update:
                                CourseManager.updateSchedule(cours[courseIn]);
                                break;
                            }
                        }

                        break;
                    }
                } while (true);
            }
        }
        public static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }

    internal enum User
    { Exit, Student, Trainer, HeadMaster }

    internal enum StudentQuery
    { Exit, Enroll, Submit, Schedule, SubmissionDates }

    internal enum TrainerQuery
    { Exit, Courses, Students, Assignments, MarkAssignments }

    internal enum MasterQuery
    { Exit, Courses, Students, Assignments, Trainers, StudentsCourses, TrainersCourses, AssignmentsCourses, ScheduleCourses }

    internal enum Action
    { Create, Read, Update, Delete }

    internal enum PAction
    { Create, Update, Delete }
}