using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGOProComboCalculator.Model;

namespace YGOProComboCalculator.Services
{
    public class CardsManager
    {
        public static IDictionary<int, Card> Cards = new Dictionary<int, Card>();

        public static string nullName = "";

        public static string nullString = "";

        internal static Card GetCard(int id)
        {

            if (Cards.ContainsKey(id))
            {
                return Cards[id];
            }

            return null;
        }

        public static void initialize(string databaseFullPath)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFullPath))
            {
                connection.Open();

                using (IDbCommand command = new SQLiteCommand("SELECT datas.id, datas.ot, datas.alias, datas.setcode, datas.type, datas.atk, datas.def, datas.level, datas.race,datas.attribute, datas.category, texts.* FROM datas,texts WHERE datas.id=texts.id;", connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoadCard(reader);
                        }
                    }
                }
            }
        }

        private static void LoadCard(IDataRecord reader)
        {
            Card card = new Card(reader);
            if (!Cards.ContainsKey(card.Id))
            {
                Cards.Add(card.Id, card);
            }
        }

        internal static Card Get(int id)
        {
            Card returnValue = new Card();
            if (id > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    returnValue = GetCard(id - i);
                    if (returnValue != null)
                    {
                        break;
                    }
                }
                if (returnValue == null)
                {
                    returnValue = new Card();
                }
            }
            return returnValue;
        }

        public static bool IfSetCard(int setCodeToAnalyse, long setCodeFromCard)
        {
            bool res = false;
            int settype = setCodeToAnalyse & 0xfff;
            int setsubtype = setCodeToAnalyse & 0xf000;
            long sc = setCodeFromCard;
            while (sc != 0 && sc != -1)
            {
                if ((sc & 0xfff) == settype && (sc & 0xf000 & setsubtype) == setsubtype)
                    res = true;
                sc = sc >> 16;
            }

            return res;
        }
    }
}
