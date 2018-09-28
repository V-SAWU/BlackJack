using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public int value;  //card的值

        public Card(int num)
        {
            this.value = CountCardValue(num);
        }
        public int CountCardValue(int num)          //计算卡牌的值
        {
            int value;
            if (num <= 40)
            {
                if (num % 4 == 0) { value = num / 4; }
                else { value = (num / 4) + 1; }
            }
            else
            {
                value = 10;
            }
            return value;
        }      
    }
}
