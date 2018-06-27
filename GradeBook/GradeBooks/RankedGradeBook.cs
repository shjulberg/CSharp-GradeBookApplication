using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int NumberOfStudents = Students.Count;
            int NumberOfStudentsPerGrade = (int)Math.Round((double)(NumberOfStudents * .2));
            List<double> GradeList = new List<double>();
            foreach (Student student in Students)
            {
                GradeList.Add(student.AverageGrade);
            }
            GradeList.Sort((a, b) => -1 * a.CompareTo(b));
            double LowestA = GradeList[NumberOfStudentsPerGrade - 1];
            double LowestB = GradeList[(NumberOfStudentsPerGrade * 2) - 1];
            double LowestC = GradeList[(NumberOfStudentsPerGrade * 3) - 1];
            double LowestD = GradeList[(NumberOfStudentsPerGrade * 4) - 1];
            if (averageGrade >= LowestA)
            {
                return 'A';
            }
            else if (averageGrade >= LowestB)
            {
                return 'B';
            }
            else if (averageGrade >= LowestC)
            {
                return 'C';
            }
            else if (averageGrade >= LowestD)
            {
                return 'D';
            }
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Rankded grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
