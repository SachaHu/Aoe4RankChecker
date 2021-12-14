using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aoe4RankChecker
{
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    //Aoe4RankChecker v1.0
    //作者 Sachaaaaaaa
    //////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ///////////////////////////////////////////////////////////
            ///
           // String url = "https://aoeiv.net/api/player/matches?game=aoe4&count=1&profile_id=2988238";
            //String result0 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url));


            //string[] sArray = result0.Split('"');
            //Label label1 = new Label();
            //label1.Content = sArray[64].Remove (0)+sArray [60].Remove(0) + sArray [86].Remove(0);

            //sp.Children.Add(label1);


            /////////
            ///////////////////////////////////////////////////////////

        }
        public static string PlayerName;
        public static string PlayerProId;

        private void BtnConf_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text.Length > 0)
            {
                PlayerName = TbName.Text;
                ShowPage showPage = new ShowPage();
                showPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Id不能为空", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPro_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text.Length > 0)
            {
                PlayerProId = TbName.Text;
                ShowPage showPage = new ShowPage();
                showPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Id不能为空", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
