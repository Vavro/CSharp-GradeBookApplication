using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");
            }

            var studentsToDropGrade = this.Students.Count / 5;

            var countOfStudentsWithHigherGrade = this.Students.Count(s => s.AverageGrade > averageGrade);

            var howManyGradesToDrop = countOfStudentsWithHigherGrade / studentsToDropGrade;

            return (char)((int)'A' + howManyGradesToDrop);
        }
    }
}
