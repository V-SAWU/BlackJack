using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Hand      //表示手中的牌
    {
        public int numCard;                 //持有牌的数量
        public Card[] cards;                //4副牌
        public int maxCards = 10;           //最多只能发10张牌，否则会超过21点
        public int count = 0;               //表示持有牌的点数

        public Hand()
        {
            numCard = 0;
            cards = new Card[maxCards];
        }
        public void addCard(Card c)         //表示新加的牌，读取它的点数，加到count中
        {
            cards[numCard ]= c;
            count += c.value;
            numCard++;
        }
 
        public bool checkBlackJack()        //检查发完两张牌之后是否有黑杰克
        {
            if (numCard == 2)
            {
                if ((cards[0].value == 1) && (cards[1].value == 10)) return true;
                else if ((cards[0].value == 10) && (cards[1].value == 1)) return true;
                else return false;
            }
            else return false;
        }

        public bool checkCount()                    //在每轮发牌时均要检测庄家的牌点数，若大于18则不再加牌
        {
            if (count > 18) return false;
            else return true;
        }
        public bool checkOut()
        {

             if (count > 21) return true;
             else return false;
        }
    }
}
