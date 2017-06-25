using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;

            currentDayLabel.Text = DateTime.Now.ToString("dddd");
            currentDateLabel.Text = DateTime.Now.ToString("M");
            currentOutput.Text = tempConversion(Form1.days[0].currentTemp);
            minOutputToday.Text = Form1.days[0].tempLow + "°C";
            maxOutputToday.Text = Form1.days[0].tempHigh + "°C";

            tomorrowDate.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            minOutputTomorrow.Text = tempConversion(Form1.days[1].tempLow);
            maxOutputTomorrow.Text = tempConversion(Form1.days[1].tempHigh);
            tomorrowPrec.Text = Form1.days[1].condition;

            thirdDayDate.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
            minOutputThird.Text = tempConversion(Form1.days[2].tempLow);
            maxOutputThird.Text = tempConversion(Form1.days[2].tempHigh);
            thirdDayPrec.Text = Form1.days[2].condition;

            fourthDayDate.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            minOutputForth.Text = tempConversion(Form1.days[3].tempLow);
            maxOutputForth.Text = tempConversion(Form1.days[3].tempHigh);
            fourthDayPrec.Text = Form1.days[3].condition;

            weatherPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            string group = Form1.days[0].condition;
            int firstNum = Int16.Parse(group.Substring(0, 1));
            int lastNum = Int16.Parse(Form1.days[0].condition.Substring(2,1));

            switch (firstNum)
            {
                case 2:
                    weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.thunderstorm;
                    break;
                case 3:
                    weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.rain;
                    break;
                case 5:
                    weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.shower_rain;
                    break;
                case 6:
                    weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.snow;
                    break;
                case 7:
                    weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.mist;
                    break;
                case 8:
                    if (lastNum > 0)
                        weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.broken_clouds;
                    else
                        weatherPictureBox.BackgroundImage = XMLWeather.Properties.Resources.clear_sky;
                    break;
                default:
                    MessageBox.Show("Could not find weather icon");
                    break;

            }  
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private string tempConversion(string s)
        {
            return Math.Round(Double.Parse(s)).ToString() + "°C";
        }
    }
}