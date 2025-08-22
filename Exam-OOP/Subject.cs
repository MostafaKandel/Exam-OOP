using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class Subject
    {
        #region Attributes
        private int subjectId;
        private string subjectName;
        private Exam exam;
        #endregion
        #region Properties
        public int SubjectId { get { return subjectId; } 
            set {
                // without nameof -> when i change the name of property the wrong parameter name. but with nameof compiler updates it automatically
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value,nameof(subjectId));
                subjectId = value;
            } }
        public string SubjectName { get { return subjectName; } set {
                /*
                 - ArgumentNullException.ThrowIfNullOrEmpty(value): throws exception if value is null or empty string.
                - ArgumentNullException.ThrowIfNullOrWhiteSpace: throws exception if value is null or empty string or strings with only spaces.
                 */

                ArgumentNullException.ThrowIfNullOrWhiteSpace(value,nameof(subjectName));
                subjectName = value;
            } }
        public Exam Exam { get { return exam; } set { 
            
               ArgumentNullException.ThrowIfNull(value,nameof(exam));
                exam = value;

            } }
        #endregion

        #region Method

        public void CreateExam()
        {
            int examType;
            int examTime;
            int numOfQuestions;
            
            do
            {
                Console.WriteLine("Please Enterthe Type of Exam (1 for Practical | 2 for Final):");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));


            do
            {
                Console.WriteLine("Enter Exam Time  from (30 minutes to 180 minutes):");
            } while (!int.TryParse(Console.ReadLine(), out examTime)|| examTime < 30 || examTime > 180 );


            do
            {
                Console.WriteLine("Enter Number of Questions(between 1 to 5):");
            } while (!int.TryParse(Console.ReadLine(), out numOfQuestions) || numOfQuestions <= 0 || numOfQuestions > 5);


            


            if (examType == 1)
            {
                exam = new PracticalExam(examTime, numOfQuestions);
            }
            else 
            {
                exam = new FinalExam(examTime, numOfQuestions);
            }
            

            exam.CreateExamQuestions();
            string? input;
            Console.Clear();
            do
            {
                
                Console.WriteLine("Do you want to start the exam now? (Y/N): ");
                input = Console.ReadLine()?.Trim().ToLower();
            } while (input != "y" && input != "n");
            if (input == "y")
            {
                exam.ShowExam();
                Console.WriteLine("Exam finished!");
            }
            else
            {
                Console.WriteLine("Exam cancelled");
            }

            



        }
        #endregion
    }
}
