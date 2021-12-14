using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Threading;

namespace Aoe4RankChecker
{
    /// <summary>
    /// ShowPage.xaml 的交互逻辑
    /// </summary>
    public partial class ShowPage : Window
    {
        //定时器
        private System.Windows.Threading.DispatcherTimer dt = new DispatcherTimer();
        //存储当前比赛和上次比赛，检查玩家对局信息是否更新
        private string lastMatch;
        private string currentMatch;
        //根据玩家输入的昵称检索到的profile_id，int和字符串
        private string u1id;
        private int intu1id;
        //插入的label初始化
        private Label label1 = new Label();
        //private Label label2 = new Label();
        //private int t=0;
        public ShowPage()
        {
            InitializeComponent();
            //设置窗口置顶
            this.Topmost = true;
            if (MainWindow.PlayerName != null)
            {
                //根据用户输入的昵称获取profile_id
                String Uurl = "https://aoeiv.net/api/leaderboard?game=aoe4&leaderboard_id=17&start=1&count=1&search=" + MainWindow.PlayerName;
                String result = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(Uurl));
                Root rt = JsonConvert.DeserializeObject<Root>(result);
                int userProfile_id = rt.leaderboard[0].profile_id;
                u1id = userProfile_id.ToString();
                intu1id = userProfile_id;
            }else if (MainWindow .PlayerProId != null)
            {
                u1id = MainWindow.PlayerProId;

            }


            //初始化显示
            //根据用户profile_id生成展示字符串
            String iniString=GenerateOverlayString(u1id);
            //将label的内容更新为生成的字符串
            label1.Content = iniString;
            label1.Name = "labelMain";
            
            //将label添加到窗口
            sp.Children.Add(label1);


            /////////////////////////////////
            ///
            //label2.Content = "start";
            //sp.Children.Add(label2);
            //Window_Loaded();

            ///////////////////

            //记住上次
            //获得最近一次比赛的match_id，赋给lastmatch变量
            String url000 = "https://aoeiv.net/api/player/matches?game=aoe4&count=1&profile_id=" + u1id;
            String result00 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url000));
            string[] sArray0 = result00.Split('"');
            lastMatch = sArray0[3];


            //////////////////////////
            ///
            
            //设置计时器
            //设置每次查询间隔，单位毫秒
            dt.Interval = TimeSpan.FromMilliseconds(5000);
            dt.Tick +=new EventHandler(dt_Tick);
            //计时器开始工作
            dt.Start();

        }


        //DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //允许用户拖拽移动窗口
            this.MouseDown += delegate { DragMove(); };
            
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            
            //定时执行的内容
            //获取用户最新的比赛信息，赋给currentmatch
            String url0001111 = "https://aoeiv.net/api/player/matches?game=aoe4&count=1&profile_id=" + u1id;
            String result0011 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url0001111));
            string[] sArray01 = result0011.Split('"');
            currentMatch = sArray01[3];

    
            /////////////////////////////////////////////////////////
            ///比较上次比赛的id和这次比赛的id，如不同则更新字符串
            if (!string.Equals(currentMatch, lastMatch))
            {
                String newString = GenerateOverlayString(u1id);
                label1.Content = newString;
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        ///定时器的废案
        //private void timer1_Tick(object sender, EventArgs e)
        //{
            //定时执行的内容
            //String url0001111 = "https://aoeiv.net/api/player/matches?game=aoe4&count=1&profile_id=" + u1id ;
            //String result0011 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url0001111));
            //string[] sArray01 = result0011.Split('"');
            //currentMatch = sArray01[3];

            ///////////////////////////////////////////////////////
            ///
            
            /////////////////////////////////////////////////////////
            //if (!string.Equals (currentMatch ,lastMatch))
            //{
                //String newString = GenerateOverlayString(intu1id );
                //label1.Content = newString;
            //}


        //}

        private string GenerateOverlayString(String id)
        {
            //抓取用户最近的一场比赛
            String url = "https://aoeiv.net/api/player/matches?game=aoe4&count=1&profile_id="+ id;
            String result0 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url));
            //这玩意儿不是json，所以手动切割字符串
            string[] sArray = result0.Split('"');
            //用双引号切完后删掉开头的冒号
            String player2idm = sArray[64].Remove (0,1);
            //int idmlen = player2idm.Length;
            //判断用户在这局中是p1还是p2
            String player1idm = sArray[38].Remove(0, 1);
            String pos1id=player1idm.Remove(player1idm.Length - 1, 1);
            String pos2id = player2idm.Remove(player2idm.Length - 1, 1);
            String player2id;
            String player1civ;
            String player2civ;



            if (string.Equals (pos1id,u1id))
            {
                player2id = pos2id ;
                player1civ = sArray[60].Remove(0, 1).Remove(1, 1);
                player2civ = sArray[86].Remove(0, 1).Remove(1, 1);
            }else if(string.Equals(pos2id, u1id))
            {
                player2id = pos1id;
                player2civ = sArray[60].Remove(0, 1).Remove(1, 1);
                player1civ = sArray[86].Remove(0, 1).Remove(1, 1);
            }
            else
            {
                MessageBox.Show("Id不能为空", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return "error";
            }

            player1civ = TransCiv(player1civ);
            player2civ = TransCiv(player2civ);

            



            

            /////////////////////////////////////////////////////////////////////////////////
            ///废案
            //String player2rate = matches.matche.players[1].rating.ToString();
            //String player2name = matches.matche.players[1].name ;
            //String player2civ = matches.matche.players[1].civ.ToString ();
            ////////////////////////////////////////////////////////////////////////////////
            
            //String url2 = "https://aoeiv.net/api/player/ratinghistory?game=aoe4&leaderboard_id=17&count=1&profile_id=" + player2id;
            //String result2= HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url2));
            //GameHistories gameHistories2= JsonConvert.DeserializeObject<GameHistories >(result2);

            //int player2wins = gameHistories2.gameHistories[0].num_wins;
            //int player2losses = gameHistories2.gameHistories[0].num_losses ;
            //int intplayer2total = player2wins + player2losses;
            //int intplayer2winrate = player2wins * 100 / intplayer2total;
            //String player2total = intplayer2total.ToString();
            //String player2winrate = intplayer2winrate.ToString();

        

            String url22 = "https://aoeiv.net/api/leaderboard?game=aoe4&leaderboard_id=17&start=1&count=1&profile_id=" + player2id;
            String result22 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url22));
            Root rt2 = JsonConvert.DeserializeObject<Root>(result22);
            String player2rank = rt2.leaderboard[0].rank.ToString();
            int player2wins = rt2.leaderboard[0].wins;
            int intplayer2total = rt2.leaderboard[0].games;
            String player2winrate;
            if (intplayer2total == 0)
            {
                player2winrate = "0";
            }
            else
            {
                player2winrate = (player2wins * 100 / intplayer2total).ToString();
            }
            
            String player2total = intplayer2total.ToString();
            String player2name = rt2.leaderboard[0].name;
            String player2rate = rt2.leaderboard[0].rating.ToString(); 


            //String player1rate = matches.matche.players[0].rating.ToString();
            //String player1name = matches.matche.players[0].name;
            //String player1civ = matches.matche.players[0].civ.ToString();

            //String url1 = "https://aoeiv.net/api/player/ratinghistory?game=aoe4&leaderboard_id=17&count=1&profile_id=" + player2id;
            //String result1 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url2));
            //GameHistories gameHistories1 = JsonConvert.DeserializeObject<GameHistories>(result1);

            //int player1wins = gameHistories2.gameHistories[0].num_wins;
            //int player1losses = gameHistories2.gameHistories[0].num_losses;
            //int intplayer1total = player2wins + player2losses;
            //int intplayer1winrate = player2wins * 100 / intplayer2total;
            //String player1total = intplayer2total.ToString();
            //String player1winrate = intplayer2winrate.ToString();

            String url11 = "https://aoeiv.net/api/leaderboard?game=aoe4&leaderboard_id=17&start=1&count=1&profile_id=" + id;
            String result11 = HttpRequestHelper.GetResponseString(HttpRequestHelper.CreateGetHttpResponse(url11));
            Root rt1 = JsonConvert.DeserializeObject<Root>(result11);
            String player1rank = rt1.leaderboard[0].rank.ToString();
            String player1name = MainWindow.PlayerName;
            int player1wins = rt1.leaderboard[0].wins;
            int intplayer1total = rt1.leaderboard[0].games;
            String player1winrate = (player1wins * 100 / intplayer1total).ToString();
            String player1total = intplayer1total.ToString();
            String player1rate = rt1.leaderboard[0].rating.ToString();


            String resultString = player1civ + " " + player1name + " #" + player1rank + " " + player1rate + " 总场数" + player1total + " 胜率" + player1winrate + " vs " + player2winrate + "胜率 " + player2total + "总场数 " + player2rate + " #" + player2rank + " " + player2name +  " " + player2civ;
            //String resultString = player2id;
            return resultString;


        }
        private string TransCiv(String civ)
        {
            if (civ == "0")
            {
                return "大食";
            }else if (civ == "1")
            {
                return "中国";
            }else if (civ == "2")
            {
                return "德里";
            }else if (civ == "3")
            {
                return "英格兰";
            }else if (civ == "4")
            {
                return "法兰西";
            }else if (civ == "5")
            {
                return "神罗";
            }else if (civ == "6")
            {
                return "蒙古";
            }else if (civ == "7")
            {
                return "罗斯";
            }
            else
            {
                return "error";
            }
        }




    }
}
