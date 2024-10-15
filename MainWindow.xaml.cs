using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CombineCodePractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Why is it called questionair?
        //I don't CARE!!!
        //It rhymed so live with it.
        internal Questionaire Questionaire = new Questionaire();

        internal AnswerSheet AnswerSheet = new AnswerSheet();

        internal static readonly List<Question> BasicCodes = new()
        {
            new("code 2", "Proceed immediately with lights/without sirens", true),
            new("code 3", "Proceed immediately with lights and sirens", true ),
            new("code 4", "No further assistance required", true ),
            new("code 7", "Out of service to eat", true ),
            new("code 12", "Patrol your district and report extent of damage", true ),
            new("code 30", "Officer needs assistance — emergency", false ),
            new("code 100", "In position to intercept suspect", true )
        };

        internal static readonly List<Question> Abbreviations = new()
        {
            new( "ADW", "Assault with deadly weapon", true),
            new( "APB", "All points Bulletin", true ),
            new( "BOL", "Be on the lookout", true ),
            new( "DB", "Dead body", true ),
            new( "GOA", "Gone on arrival", true ),
            new( "OC", "Off course", true ),
            new( "UPI", "Unidentified person of intented", true ),
            new( "UTL", "Unable to locate", true )
        };

        internal static readonly List<Question> TenCodes = new()
        {
            new( "10-0", "Use caution", true ),
            new( "10-2", "You are being received clearly", true ),
            new( "10-3", "Stop transmitting", false ),
            new( "10-4", "OK", true ),
            new( "10-8", "In service", true ),
            new( "10-14", "Convoy or escort detail", true ),
            new( "10-15", "Prisoner in custody", true ),
            new( "10-20", "Your location", true ),
            new( "10-22", "Disregard / Cancel last transmition", true ),
            new( "10-25", "Do you have contact with [person]", true ),
            new( "10-27", "Check for wants or warrants", false ),
            new( "10-30", "Does not conform to rules or regulations", true ),
            new( "10-33", "Alarm (Audible or Silent)", false ),
            new( "10-38", "Your destination", false ),
            new( "10-54d", "Possible dead body", false ),
            new( "10-55d", "Send coroner", false ),
            new( "10-65", "Clear for assignment", true ),
            new( "10-78", "Send ambulance", true ),
            new( "10-91d", "Dead animal", true ),
            new( "10-97", "Arrived at scene", true ),
            new( "10-99", "Unable to receive your last message / In trouble", true ),
            new( "10-103f", "Disturbance by fight", false ),
            new( "10-103m", "Disturbance by mentally unfit", true ),
            new( "10-107", "Suspicious person", true ),
            new( "10-108", "Officer down or in need of assistance.", true ),
        };

        internal static readonly List<Question> PenalCodes = new()
        {
            new( "17f", "Fugitive detachment", true ),
            new( "24", "Medical emergency" ),
            new( "27", "Attempted crime", true ),
            new( "34s", "Shooting", true ),
            new( "51", "Non-sanctioned arson", true ),
            new( "51b", "Threat to property (Bomb threat)", true ),
            new( "52", "Simple arson" ),
            new( "56", "Criminal damage" ),
            new( "62", "alarms", true ),
            new( "63", "Criminal trespass", true ),
            new( "63s", "Illegal in operation (Sit-in)", true ),
            new( "69", "Posession of resources (stolen goods)", true ),
            new( "94", "weapon (illegal use of firearm)", true ),
            new( "95", "Illegal carrying (ex. of gun)", true ),
            new( "99", "Reckless operation", true ),
            new( "148", "Resisting arrest", true ),
            new( "211", "Armed robbery" ),
            new( "243", "Assault on Protection Team", true ),
            new( "245", "Assault with deadly weapon" ),
            new( "404", "Riot", true ),
            new( "415", "Civic Disunity (Disturbing the peace)", true ),
            new( "415b", "Investigate the trouble", true ),
            new( "447", "Arson" ),
            new( "459", "Burglary" ),
            new( "505", "Reckless driving", true ),
            new( "507", "Public non-compliance", true ),
            new( "603", "Unlawful entry", true ),
            new( "647e", "Disengaged from workforce (loitering place to place)", true )
        };

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BasicCodesBtn_Click(object sender, RoutedEventArgs e)
        {
            Questionaire.Show();
            Questionaire.SetupQuestions(QuestionType.BasicCode);
            this.Hide();
        }

        internal static MainWindow Instance { get; private set; }

        private void AbbreviationsBtn_Click(object sender, RoutedEventArgs e)
        {
            Questionaire.SetupQuestions(QuestionType.Abbreviation);
            Questionaire.Show();
            this.Hide();
        }

        private void tenCodesBtn_Click(object sender, RoutedEventArgs e)
        {
            Questionaire.SetupQuestions(QuestionType.TenCode);
            Questionaire.Show();
            this.Hide();
        }

        private void PenalCodesBtn_Click(object sender, RoutedEventArgs e)
        {
            Questionaire.Show();
            Questionaire.SetupQuestions(QuestionType.PenalCode);
            this.Hide();
        }

        private void FullTestBtn_Click(object sender, RoutedEventArgs e)
        {
            Questionaire.Show();
            Questionaire.SetupQuestions(QuestionType.All);
            this.Hide();
        }

        private void OverwikiLinkLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://combineoverwiki.net/wiki/List_of_Combine_terminology", UseShellExecute = true });
        }

        private void CombineCodePractice_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    internal enum QuestionType
    {
        All,
        BasicCode,
        Abbreviation,
        TenCode,
        PenalCode
    }
}