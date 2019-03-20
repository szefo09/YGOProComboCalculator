using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProComboCalculator.Services
{
    public class GameStringHelper
    {

        public static string getSetName(long Setcode)
        {
            string returnValue = "";
            for (int i = 0; i < GameStringManager.xilies.Count; i++)
            {
                if (CardsManager.IfSetCard(GameStringManager.xilies[i].hashCode, Setcode))
                {
                    if (!returnValue.Contains(GameStringManager.xilies[i].content))
                    {
                        returnValue += GameStringManager.xilies[i].content + ", ";
                    }
                }
            }
            if (returnValue.Length > 2)
            {
                returnValue = returnValue.Substring(0, returnValue.Length - 2);
            }

            return returnValue;
        }
    }
}
