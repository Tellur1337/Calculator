using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        List<string> example = new List<string>();
        //List<string> single_example = new List<string>();
        string act, result = "";
        string single_act = "";

        public void Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string classId = btn.ClassId;


            if (result != "")
            {
                if (!"plsmnsdvdmltplpwql".Contains(classId))
                {
                    if (!(example.Contains("*") || example.Contains("/") || example.Contains("^") || example.Contains("-") || example.Contains("+")))
                    {
                        example.Remove(result);
                        result = "";
                        Result.Text = "";
                    }
                }
                else
                {
                    if (!"ql".Contains(classId))
                        Result.Text = result;
                }
            }

            switch (classId)
            {
                case "zero":
                    Result.Text += 0;
                    example.Add("0");
                    break;
                case "one":
                    Result.Text += 1;
                    example.Add("1");
                    break;
                case "two":
                    Result.Text += 2;
                    example.Add("2");
                    break;
                case "three":
                    Result.Text += 3;
                    example.Add("3");
                    break;
                case "four":
                    Result.Text += 4;
                    example.Add("4");
                    break;
                case "five":
                    Result.Text += 5;
                    example.Add("5");
                    break;
                case "six":
                    Result.Text += 6;
                    example.Add("6");
                    break;
                case "seven":
                    Result.Text += 7;
                    example.Add("7");
                    break;
                case "eight":
                    Result.Text += 8;
                    example.Add("8");
                    break;
                case "nine":
                    Result.Text += 9;
                    example.Add("9");
                    break;
                case "pls":
                    Result.Text += " + ";
                    act = "+";
                    example.Add("+");
                    break;
                case "mns":
                    Result.Text += " - ";
                    act = "-";
                    example.Add("-");
                    break;
                case "dvd":
                    Result.Text += " / ";
                    act = "/";
                    example.Add("/");
                    break;
                case "mltpl":
                    Result.Text += " * ";
                    act = "*";
                    example.Add("*");
                    break;
                case "pw":
                    Result.Text += " ^ ";
                    act = "^";
                    example.Add("^");
                    break;
                case "ql":
                    example.Add(" = ");
                    if (example.Contains("P") || example.Contains("C") || example.Contains("S"))
                        result = Counter();
                    else
                    {
                        result = Calculate();
                    }
                    Result.Text += " = " + result;
                    example = new List<string>() { result };
                    act = "";
                    break;
                case "clear":
                    Result.Text = "";
                    example = new List<string>();
                    act = "";
                    break;
                default:
                    Result.Text = "";
                    break;
            }
        }

        private string Counter()
        {
            List<double> digits = new List<double>();
            string variable = "";

            foreach (string sym in example)
            {
                try
                {
                    Convert.ToInt32(sym);
                    variable += sym;
                }
                catch (Exception)
                {

                }
            }
            digits.Add(Convert.ToDouble(variable));

            switch (act)
            {
                case "cos":
                    return Math.Round(Math.Cos(digits[0] / 57.3248), 2).ToString();
                case "sin":
                    return Math.Round(Math.Sin(digits[0] / 57.3248), 2).ToString();
                case "-/":
                    return Math.Sqrt(digits[0]).ToString();
                default:
                    return "";
            }
        }

        private string Calculate()
        {
            List<double> digits = new List<double>();
            string variable = "";

            foreach (string sym in example)
            {
                try
                {
                    Convert.ToInt32(sym);
                    variable += sym;
                }
                catch (Exception)
                {
                    digits.Add(Convert.ToInt32(variable));
                    variable = "";
                }
            }

            switch (act)
            {
                case "+":
                    return (digits[0] + digits[1]).ToString();
                case "-":
                    return (digits[0] - digits[1]).ToString();
                case "/":
                    if (digits[1] == 0)
                        return "unlucko, try again";
                    return (digits[0] / digits[1]).ToString();
                case "*":
                    return (digits[0] * digits[1]).ToString();
                case "^":
                    return Math.Pow(digits[0], digits[1]).ToString();
                default:
                    return "";
            }
        }

        public void Single_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string classId = btn.ClassId;

            example.Clear();
            act = "";
            result = "";
            Result.Text = "";

            switch (classId)
            {
                case "cos":
                    example.Add("C");
                    Result.Text += "Cos ";
                    act = "cos";
                    break;
                case "sin":
                    example.Add("S");
                    Result.Text += "Sin ";
                    act = "sin";
                    break;
                case "sqrt":
                    example.Add("P");
                    Result.Text += "Sin ";
                    act = "-/";
                    break;
            }
        }
    }
}
