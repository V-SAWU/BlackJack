using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Game
    {
        public string Box1;
        public string Box2;
        public string Box3;
        public string Box4;
        public string Box5;
        public string Box6;
        public string Box7;
        public string Box8;
        public string Box9;
        public string Box10;                    //以上放置纸牌

        public string lab_banker;               //显示庄家目前的点数
        public string lab_player;               //显示玩家目前的点数

        public Hand hand_banker;                //保存庄家手中的牌
        public Hand hand_player;                //保存玩家手中的牌
        public Deck deck;                       //新创建一副牌
        public int i;                           //一副牌的第几张,用于记录发牌过程中发到一副牌的第几张
        public int score;                       //玩家在一轮游戏中赢得或输掉的金额
        public int k = 0;                       //当前

        bool result = false;

        public Game()
        {
            hand_player = new Hand();
            hand_banker = new Hand();
            deck = new Deck();
            i = 0;
            setnew();
        }

        public void setnew()
        {
            Box1 = "";
            Box2 = "";
            Box3 = "";
            Box4 = "";
            Box5 = "";
            Box6 = "";
            Box7 = "";
            Box8 = "";
            Box9 = "";
            Box10 = "";
        }
        /*
         * 第一轮发牌 庄家和玩家均发到两张牌-从庄家开始拿牌
         */
        public bool firstCicle(out string message)
        {
            message = "";
            deal(Box1, hand_banker, out message);
            deal(Box6, hand_player, out message);
            deal(Box2, hand_banker, out message);
            deal(Box7, hand_player, out message);

            //判断是否有黑杰克 
            if (hand_banker.checkBlackJack() && hand_player.checkBlackJack())
            { showCard(); result = true; message = "It ends in a draw "; score = 0; lab_player = "21"; lab_banker = "21"; }
            else if (hand_player.checkBlackJack())
            { showCard(); result = true; message = "21 points,you win!"; score = getScore(k) * 2; lab_player = "21"; }
            else if (hand_banker.checkBlackJack())
            { showCard(); result = true; message = "21 points banker win! "; score = 0 - getScore(k) * 2; lab_banker = "21"; }
            else
            {
                result = false;                                         //游戏时 庄家只显示一张手牌的点数
                lab_banker = hand_banker.cards[0].value.ToString();
                lab_player = hand_player.count.ToString();
            }
            return result;
        }

        public bool hitEvent(out string message)
        {
            message = "";
            deal(check_player(), hand_player, out message);
            lab_player = hand_player.count.ToString();
            if (hand_player.checkOut())                                                  //玩家爆牌
            {
                showCard();
                result = true;
                message = "player burst card,banker win!";
                score = 0 - getScore(k);
            }
            return result;
        }
        public bool standEvent(out string message)
        {
            while (hand_banker.checkCount()) { deal(check_banker(), hand_banker, out message); }
            if (hand_banker.count > 21)
            {
                showCard();
                result = true;
                message = "banker burst card ,player win!";
                score = getScore(k);
            }
            else
            {
                if (hand_player.count > hand_banker.count)
                {
                    showCard();
                    result = true;
                    if (hand_player.count == 21) { message = "21points,player win!"; }
                    else message = "player win";
                    score = getScore(k);
                }
                else if (hand_banker.count > hand_player.count)
                {
                    showCard();
                    result = true;
                    if (hand_banker.count == 21) { message = "banker 21points,banker win!"; }
                    else message = "player lose";
                    score = 0 - getScore(k);
                }
                else
                {
                    showCard();
                    result = true;
                    message = "It ends in a draw ";
                    score = 0;
                }
            }
            return result;
        }

        private void deal(string picture, Hand hand, out string message)     //发牌
        {
            message = "";
            int num = deck.card[i];
            i++;
            Card card = new Card(num);
            if (hand.numCard < hand.maxCards)
            {
                hand.addCard(card);
            }
            else
                message = "Hand cards have reached the upper limit";
        }
        private void showCard()
        {

        }
        private string check_player()
        {
            if (Box8 == "") { return Box8; }
            else if ((Box9 == "")) { return Box9; }
            else if ((Box10 == "")) { return Box10; }
            else return "";
        }
        private string check_banker()
        {
            if (Box3 == "") { return Box3; }
            else if ((Box4 == "")) { return Box4; }
            else if ((Box5 == "")) { return Box5; }
            else return "";
        }
        public int getScore(int a)
        {
            return Convert.ToInt32(a);
        }

    }
}
