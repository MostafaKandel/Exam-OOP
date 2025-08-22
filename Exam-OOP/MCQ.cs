using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class MCQ : Question
    {

        #region constractor
        public MCQ( string body, float mark): base("MCQ", body, mark) {

        }
        #endregion

        public override void ShowQuestion()
        {
            Console.WriteLine($"{HeaderOfQuestion} - {BodyOfQuestion} (Mark: {Mark})");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }
    }
}
