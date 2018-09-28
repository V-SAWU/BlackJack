using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static Game game = new Game();
        static int score_player = 200;
        static void Main(string[] args)
        {
            string wish = "";
            string lab_score = "";

            Console.WriteLine("Click any key to start the game.");
            Console.ReadKey();
            while (true)
            {
                string message = "";
                
                initial();
                bool result = game.firstCicle(out message);
                if (result)
                {
                    score_player = score_player + game.score;
                    lab_score = score_player.ToString();
                    if (restart())
                    {
                        Console.WriteLine("No menoy, come again (Y/N) ");
                        wish = Console.ReadLine();
                        if (wish.ToLower() == "y")
                        {
                            initial();
                            score_player = 200;
                            lab_score = score_player.ToString();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else initial();
                }

                if (score_player <= 0)
                {
                    Console.WriteLine("No menoy, come again (Y/N)");
                    wish = Console.ReadLine();
                    if (wish.ToLower() == "y")
                    {
                        initial();
                        score_player = 200;
                        lab_score = score_player.ToString();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                if (game.i > 104)
                {
                    initial();
                }

                Console.WriteLine("Please choose the amount of the bet (default 10). ");
                wish = Console.ReadLine();
                try
                {
                    int b = Convert.ToInt32(wish);
                    if (b > 10 && b<200 && b % 10 == 0)
                    {
                        game.k = b;
                    }
                    else
                    {
                        Console.WriteLine("input flase,please again input");
                        wish = Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("input flase,please again input");
                }

                if (!display())
                {
                    continue;
                }

                Console.ReadKey();
            }
            Console.WriteLine("Enter anything to comtinue or enter No to stop! ");
        }

        static bool display()
        {
            string a = "";
            string b = "";
            string message = "";
            if (game.hand_banker.cards[0] != null)
            {
                a += game.hand_banker.cards[0].value + " *";
            }

            foreach (Card k in game.hand_player.cards)
            {
                if (k != null)
                {
                    b += k.value + " ";
                }
            }

            
            Console.WriteLine("current menoy" + score_player + "\r\n");
            Console.WriteLine("banker：" + a + "\r\n");
            Console.WriteLine("player：" + b);
            Console.WriteLine("Whether or not to add cards (Y/N) add menoy(J)");
            string wish = Console.ReadLine();
            if (wish.ToLower() == "y")
            {
                game.hitEvent(out message);
            }
            else if (wish.ToLower() == "n")
            {
                game.standEvent(out message);
            }
            else if (wish.ToLower() == "j")
            {
                Console.WriteLine("Please choose the amount of the bet (default 10). ");
                wish = Console.ReadLine();
                try
                {
                    int bo = Convert.ToInt32(wish);
                    if (bo > 10 && bo % 10 == 0)
                    {
                        if (game.k + bo < score_player) game.k += bo;
                    }
                    else
                    {
                        if (game.k + 10 < score_player) game.k += 10;
                    }
                }
                catch
                {
                    if (game.k + 10 < score_player) game.k += 10;
                }
            }

            if (message == "")
            {
                display();
            }
            else
            {
                string ko = display1();
                ko += message;
                Console.WriteLine(message);
                Console.WriteLine("Click any key to start the game.");
                Console.ReadKey();
                Write(ko, string.Format("result\\{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }

            return false;
        }
        static string display1()
        {
            string ko = "";
            score_player += game.score;
           
            Console.WriteLine("current menoy" + score_player + "\r\n");
            ko += "current menoy" + score_player + "\r\n";
            string a = "";
            string b = "";
            foreach (Card k in game.hand_banker.cards)
            {
                if (k != null)
                {
                    a += k.value + " ";
                }
            }

            foreach (Card k in game.hand_player.cards)
            {
                if (k != null)
                {
                    b += k.value + " ";
                }
            }

            Console.WriteLine("banker：" + a + "\r\n");
            Console.WriteLine("player：" + b);
            ko += "banker：" + a + "\r\n";
            ko += "player：" + b + "\r\n";
            return ko;
        }

        public static void Write(string neirong, string path = "")
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(neirong);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
        static void initial()
        {
            game.hand_player = new Hand();
            game.hand_banker = new Hand();
            game.deck = new Deck();
            game.i = 0;
        }

        static bool restart()
        {
            if (score_player <= 0)
            {
                return true;
            }
            else return false;
        }

    }
}
