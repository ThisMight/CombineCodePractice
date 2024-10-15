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
    /// Interaction logic for AnswerSheet.xaml
    /// </summary>
    public partial class AnswerSheet : Window
    {
        private List<Answer>? _answerList;

        private QuestionType _type;

        internal AnswerSheet()
        {
            InitializeComponent();
        }

        internal void SetupSheet(List<Answer> answers, QuestionType type)
        {
            _answerList = answers;
            _type = type;
            FillAnswerSheet();
            ScoreLbl.Content = $"{_answerList.FindAll(answer => answer.Correct).Count}/{_answerList.Count}";
        }

        private void FillAnswerSheet()
        {
            foreach (Answer answer in _answerList)
            {
                AnswerLV.Items.Add(answer);
            }
        }

        private void TryAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Questionaire.Show();
            MainWindow.Instance.Questionaire.SetupQuestions(_type);
            Hide();
        }

        private void DifferentQuestionsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void AnswerSheetWindow_Closed(object sender, EventArgs e)
        {
            MainWindow.Instance.Close();
        }
    }
}
