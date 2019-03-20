using System;
using System.Collections.Generic;
using System.IO;
using YGOProComboCalculator.Services;

namespace YGOProComboCalculator.Model
{
    public class Decklist
    {
        public string Name { get; private set; }
        public IList<int> Main { get; private set; }
        public IList<int> Extra { get; private set; }
        public IList<int> Side { get; private set; }

        public IList<Card>CardMain { get; private set; }
        public D Deck_O { get; private set; }
        //public IList<MonoCardInDeckManager> IMain { get; private set; }
        //public IList<MonoCardInDeckManager> IExtra { get; private set; }
        //public IList<MonoCardInDeckManager> ISide { get; private set; }
        //public IList<MonoCardInDeckManager> IRemoved { get; private set; }
        public Decklist(string path)
        {
            Main = new List<int>();
            Extra = new List<int>();
            Side = new List<int>();
            Deck_O = new D();
            CardMain = new List<Card>();
            //IMain = new List<MonoCardInDeckManager>();
            //IExtra = new List<MonoCardInDeckManager>();
            //IRemoved = new List<MonoCardInDeckManager>();
            //ISide = new List<MonoCardInDeckManager>();
            try
            {
                Name = Path.GetFileNameWithoutExtension(path);
                string text = System.IO.File.ReadAllText(path);
                string st = text.Replace("\r", "");
                string[] lines = st.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int flag = -1;
                foreach (string line in lines)
                {
                    if (line == "#main")
                    {
                        flag = 1;
                    }
                    else if (line == "#extra")
                    {
                        flag = 2;
                    }
                    else if (line == "!side")
                    {
                        flag = 3;
                    }
                    else
                    {
                        int code = 0;
                        try
                        {
                            code = Int32.Parse(line);
                        }
                        catch (Exception)
                        {

                        }
                        if (code > 100)
                        {
                            switch (flag)
                            {
                                case 1:
                                    {
                                        if (!Main.Contains(code))
                                        {
                                            var card = CardsManager.GetCard(code);
                                            this.CardMain.Add(card);
                                        }
                                        this.Main.Add(code);
                                        this.Deck_O.Main.Add(code);

                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
            }
        }
        public static List<int> rand(List<int> cards)
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int random_index = rand.Next() % cards.Count;
                var t = cards[i];
                cards[i] = cards[random_index];
                cards[random_index] = t;
            }
            return cards;
        }
    }
    public class D
    {
        public IList<int> Main = new List<int>();
        public IList<int> Extra = new List<int>();
        public IList<int> Side = new List<int>();
    }

}
