using CommunityToolkit.Mvvm;
using QuizApp.Commands;
using QuizApp.Messages;
using QuizApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Windows.Controls;

namespace QuizApp.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string FilePath;
        List<string> Questions;
        List<string> Answers;
        List<string> Options;
        int QuestionNumber;
        string odpoved = "";
        
        

        private string _Question;

        public string Question
        {
            get { return _Question; }
            set { _Question = value; OnPropertyChanged(nameof(Question));  }
        }

        private string _Option1;

        public string Option1
        {
            get { return _Option1; }
            set { _Option1 = value; OnPropertyChanged(nameof(Option1)); }
        }

        private string _Option2;

        public string Option2
        {
            get { return _Option2; }
            set { _Option2 = value; OnPropertyChanged(nameof(Option2)); }
        }

        private string _Option3;

        public string Option3
        {
            get { return _Option3; }
            set { _Option3 = value; OnPropertyChanged(nameof(Option3)); }
        }

        private string _Option4;

        public string Option4
        {
            get { return _Option4; }
            set { _Option4 = value; OnPropertyChanged(nameof(Option4)); }
        }

        private bool _AnswerButtonEnabled;

        public bool AnswerButtonEnabled
        {
            get { return _AnswerButtonEnabled; }
            set { _AnswerButtonEnabled = value; OnPropertyChanged(nameof(AnswerButtonEnabled)); }
        }

        private bool _NextButtonEnabled;

        public bool NextButtonEnabled
        {
            get { return _NextButtonEnabled; }
            set { _NextButtonEnabled = value; OnPropertyChanged(nameof(NextButtonEnabled)); }
        }

        private string _Button1Selected;

        public string Button1Selected
        {
            get { return _Button1Selected; }
            set { _Button1Selected = value; OnPropertyChanged(nameof(Button1Selected)); }
        }

        private string _PressedButton;

        public string PressedButton
        {
            get { return _PressedButton; }
            set { _PressedButton = value; OnPropertyChanged(nameof(PressedButton)); }
        }

        private string _Button2Selected;

        public string Button2Selected
        {
            get { return _Button2Selected; }
            set { _Button2Selected = value; OnPropertyChanged(nameof(Button2Selected)); }
        }

        private string _Button3Selected;

        public string Button3Selected
        {
            get { return _Button3Selected; }
            set { _Button3Selected = value; OnPropertyChanged(nameof(Button3Selected)); }
        }

        private string _Button4Selected;

        public string Button4Selected
        {
            get { return _Button4Selected; }
            set { _Button4Selected = value; OnPropertyChanged(nameof(Button4Selected)); }
        }

        private string _QuestionNumberString;

        public string QuestionNumberString
        {
            get { return _QuestionNumberString; }
            set { _QuestionNumberString = value; OnPropertyChanged(nameof(QuestionNumberString)); }
        }

        private ButtonPressed _buttonPressed;

        public ButtonPressed buttonPressed
        {
            get { return _buttonPressed; }
            set { _buttonPressed = value; }
        }

        public MainViewModel()
        {
            
            QuestionNumber = 0;
            AnswerButtonEnabled = false;
            NextButtonEnabled = false;
            QuestionNumberString = "Číslo otázky: " + (QuestionNumber + 1).ToString();
            
            Button1Selected = "#5bc3ff";
            Button2Selected = "#5bc3ff";
            Button3Selected = "#5bc3ff";
            Button4Selected = "#5bc3ff";

            FilePath = Directory.GetCurrentDirectory() + @"\Questions.txt";
            Questions = new List<string>();
            Questions = File.ReadAllLines(FilePath).ToList();

            FilePath = Directory.GetCurrentDirectory() + @"\Answers.txt";
            Answers = new List<string>();
            Answers = File.ReadAllLines(FilePath).ToList();

            FilePath = Directory.GetCurrentDirectory() + @"\Options.txt";
            Options = new List<string>();
            Options = File.ReadAllLines(FilePath).ToList();

            buttonPressed = new ButtonPressed(this);
            

            GetNextQuestion();
            GetNextOptions();
        }

        public bool IsAnswerCorrect()
        {
            if (Button1Selected == "Cyan")
                if (Option1 != Answers[QuestionNumber])
                {
                    Button1Selected = "Red";
                    getGoodAnswer();
                    return false;
                }
                else
                {
                    Button1Selected = "Green";
                    NextButtonEnabled = true;
                }
                    
            if (Button2Selected == "Cyan")
                if (Option2 != Answers[QuestionNumber])
                {
                    Button2Selected = "Red";
                    getGoodAnswer();
                    return false;
                }
                else
                {
                    Button2Selected = "Green";
                    NextButtonEnabled = true;
                }

            if (Button3Selected == "Cyan")
                if (Option3 != Answers[QuestionNumber])
                {
                    Button3Selected = "Red";
                    getGoodAnswer();
                    return false;
                }
                else
                {
                    Button3Selected = "Green";
                    NextButtonEnabled = true;
                }

            if (Button4Selected == "Cyan")
                if (Option4 != Answers[QuestionNumber])
                {
                    Button4Selected = "Red";
                    getGoodAnswer();
                    return false;
                }
                else
                {
                    Button4Selected = "Green";
                    NextButtonEnabled = true;
                }

            return true;
        }

        void GameWon()
        {
            MessageBox.Show("Konec Hry!");
            
        }


        void GetNextQuestion()
        {
            Question = Questions[QuestionNumber];
        }

        void GetNextOptions()
        {
            string[] options = Options[QuestionNumber].Split(',');

            Option1 = options[0];
            Option2 = options[1];
            Option3 = options[2];
            Option4 = options[3];
            
        }

        void getGoodAnswer()
        {
            this.odpoved = Answers[QuestionNumber];

            if (Option1 == odpoved)
            {
                Button1Selected = "Green";
            }

            if (Option2 == odpoved)
            {
                Button2Selected = "Green";
            }

            if (Option3 == odpoved)
            {
                Button3Selected = "Green";
            }

            if (Option4 == odpoved)
            {
                Button4Selected = "Green";
            }
        }

        public void CheckPressedButton(string pressedButton)
        {
            switch(pressedButton)
            {
                case "Button1":
                    Button1Selected = "Cyan";
                    Button2Selected = "#5bc3ff";
                    Button3Selected = "#5bc3ff";
                    Button4Selected = "#5bc3ff";
                    AnswerButtonEnabled = true;
                    break;

                case "Button2":
                    Button1Selected = "#5bc3ff";
                    Button2Selected = "Cyan";
                    Button3Selected = "#5bc3ff";
                    Button4Selected = "#5bc3ff";
                    AnswerButtonEnabled = true;
                    break;

                case "Button3":
                    Button1Selected = "#5bc3ff";
                    Button2Selected = "#5bc3ff";
                    Button3Selected = "Cyan";
                    Button4Selected = "#5bc3ff";
                    AnswerButtonEnabled = true;
                    break;

                case "Button4":
                    Button1Selected = "#5bc3ff";
                    Button2Selected = "#5bc3ff";
                    Button3Selected = "#5bc3ff";
                    Button4Selected = "Cyan";
                    AnswerButtonEnabled = true;
                    break;

                case "AnswerButton":

                    if (!IsAnswerCorrect())
                    {
                        NextButtonEnabled = true;
                    }
                    else
                    {

                    }
                    

                    if (QuestionNumber >= Questions.Count)
                        GameWon();

                    QuestionNumberString = "Číslo otázky: " + (QuestionNumber + 1).ToString();
                    
                    AnswerButtonEnabled = false;

                    break;

                case "NextButton":
                    QuestionNumber++;
                    GetNextQuestion();
                    GetNextOptions();

                    Button1Selected = "#5bc3ff";
                    Button2Selected = "#5bc3ff";
                    Button3Selected = "#5bc3ff";
                    Button4Selected = "#5bc3ff";
                    NextButtonEnabled = false;
                    break;
            }    
        }
    }
}
