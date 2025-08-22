using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal abstract class Exam
    {
        #region Attributes
        private int examTime;
        private int numQuestions;

        #endregion


        #region properties
        public int ExamTime {
            get { return examTime; }
            set
            {
                if (value < 30 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(ExamTime),"Exam time should be between 30 and 180 minutes");
                examTime = value;
            }
        
        }
        public int NumQuestions
        {
            get { return numQuestions; }
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(NumQuestions),
                        "Number of questions must be between 1 and 5.");
                numQuestions = value;
            }
        }
        public List<Question> Questions { get; set; }


        #endregion

        #region constractor
        protected Exam(int examTime, int numQuestions)
        {
            ExamTime = examTime;
            NumQuestions = numQuestions;
            Questions = new List<Question>();
        }

        #endregion

        #region Methods
        public abstract void ShowExam();

        public abstract void CreateExamQuestions();
        #endregion
    }
}
