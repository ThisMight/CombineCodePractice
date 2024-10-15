using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CombineCodePractice
{
    /// <summary>
    /// Interaction logic for Questionaire.xaml
    /// </summary>
    public partial class Questionaire : Window
    {
        private List<Question>? _questions;

        private readonly Random _random = new();

        private int _currentQuestion = -1;

        private int _questionIndex = 0;

        private int _questionCount = 0;

        private readonly List<Answer> _answers = new();

        List<string>? _possibleAnswers;

        private QuestionType _type;

        internal Questionaire()
        {
            InitializeComponent();
        }

        internal void SetupQuestions(QuestionType type)
        {
            _answers.Clear();
            _questions = new List<Question>();
            _possibleAnswers = new List<string>();
            _type = type;
            _currentQuestion = -1;
            _questionIndex = 0;
            switch (_type)
            {
                case QuestionType.BasicCode:
                    _questions = new List<Question>(MainWindow.BasicCodes);
                    break;

                case QuestionType.Abbreviation:
                    _questions = new List<Question>(MainWindow.Abbreviations);
                    break;

                case QuestionType.TenCode:
                    _questions = new List<Question>(MainWindow.TenCodes);
                    break;

                case QuestionType.PenalCode:
                    _questions = new List<Question>(MainWindow.PenalCodes);
                    break;

                case QuestionType.All:
                    _questions = new(MainWindow.BasicCodes);
                    _questions.AddRange(MainWindow.Abbreviations);
                    _questions.AddRange(MainWindow.TenCodes);
                    _questions.AddRange(MainWindow.PenalCodes);
                    break;
            }
            _questionCount = _questions.Count;
            _possibleAnswers = _questions.Select(x => x.Answer).ToList();
            SetNextQuestion();
        }

        private Question CurrentQuestion
        {
            get
            {
                return _questions[_currentQuestion];
            }
        }

        private void SetNextQuestion()
        {
            _questionIndex++;
            if (_questionIndex > _questionCount)
            {
                MainWindow.Instance.AnswerSheet.SetupSheet(_answers, _type);
                MainWindow.Instance.AnswerSheet.Show();
                Hide();
                return;
            }
            else
            {
                _currentQuestion = _random.Next(_questions.Count);
                QuestionLbl.Content = CurrentQuestion.Prompt;
                QuestionLbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                QuestionIndexLbl.Content = $"{_questionIndex}/{_questionCount}";
                SetAnswers();
            }
        }

        private void RemoveQuestionFromPool()
        {
            _questions.Remove(CurrentQuestion);
        }

        private void SetAnswers()
        {
            string answer = CurrentQuestion.Answer;
            List<string> MainAnswers = new List<string>(_possibleAnswers);
            MainAnswers.Remove(answer);
            List<string> answerList = new()
            {
                answer,
            };

            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                index = _random.Next(MainAnswers.Count);
                answerList.Add(MainAnswers[index]);
                MainAnswers.RemoveAt(index);
            }

            List<Button> buttons = new()
            {
                Answer1Btn,
                Answer2Btn,
                Answer3Btn,
                Answer4Btn,
            };

            for (int i = 0; i < buttons.Count; i++)
            {
                index = _random.Next(answerList.Count);
                buttons[i].Content = answerList[index];
                answerList.RemoveAt(index);
            }
        }

        private void Answer(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) {
                if (CurrentQuestion.Answer.Equals(button.Content.ToString())) _answers.Add(new Answer(CurrentQuestion.Prompt, button.Content.ToString(), true, string.Empty));
                else _answers.Add(new Answer(CurrentQuestion.Prompt, button.Content.ToString(), false, CurrentQuestion.Answer));
                RemoveQuestionFromPool();
                SetNextQuestion();
            }
        }

        private void Questionaire1_Closed(object sender, EventArgs e)
        {
            MainWindow.Instance.Close();
        }
    }
}
