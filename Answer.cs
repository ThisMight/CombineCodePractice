using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CombineCodePractice
{
    internal sealed class Answer
    {
        public string Question { get; set; }

        public string AnsweredText { get; set; }

        public bool Correct { get; set; }

        public string Correction { get; set; }

        public SolidColorBrush AnswerColor { get; set; }

        internal Answer(string question, string answer, bool correct, string correction)
        {
            Question = question;
            AnsweredText = answer;
            Correct = correct;
            Correction = correction;

            AnswerColor = correct ? Brushes.DarkGreen : Brushes.Red;
        }
    }
}
