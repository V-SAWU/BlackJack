using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        public int[] card;
        Random rd = new Random();
        public Deck()
        {
            card = new int[208];              //4副牌
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 52; i++)
                {
                    card[i + 52 * j] = i + 1;
                }
            }
            shuffle();

        }

        private void shuffle()               //洗牌 随意两张牌对换500次
        {
            for (int i = 0; i < 500; i++)
            {
                int j = rd.Next(0, 207);
                int k = rd.Next(0, 207);
                int temp = card[j];
                card[j] = card[k];
                card[k] = temp;
            }
        }
    }
}