﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students.");
            }

            int betterStudents = 0;

            foreach (var student in Students)
            {
                if (averageGrade < student.AverageGrade)
                {
                    betterStudents++;
                }
            }

            int percent = (100 * betterStudents) / Students.Count;

            if (percent < 20)
            {
                return 'A';
            }
            if (percent >= 20 && percent < 40)
            {
                return 'B';
            }
            if (percent >= 40 && percent < 60)
            {
                return 'C';
            }
            if (percent >= 60 && percent < 80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }

        }

    }
}