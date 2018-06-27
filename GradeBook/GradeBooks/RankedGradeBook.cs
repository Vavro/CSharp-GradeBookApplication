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

            var studentsToDropGrade = Math.Floor(this.Students.Count / 5.0);

            var countOfStudentsWithHigherGrade = this.Students.Count(s => s.AverageGrade > averageGrade);

            var howManyGradesToDrop = Math.Floor(countOfStudentsWithHigherGrade / (double)studentsToDropGrade);

            var resultingGrade = (char)((int)'A' + howManyGradesToDrop);
            if (resultingGrade == 'E') resultingGrade++;

            return resultingGrade;
        }
    }
}
