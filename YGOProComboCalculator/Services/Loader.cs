using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGOProComboCalculator.Services
{
    class Loader
    {
        public static void LoadCDBs()
        {
            if (Directory.Exists("cdb"))
            {
                LoadCDBsFromFolder("cdb");
            }
            LoadCDBsFromFolder(Directory.GetCurrentDirectory());
            if (Directory.Exists("expansions"))
            {
                DirectoryInfo[] directoryInfos = new DirectoryInfo("expansions").GetDirectories();
                foreach (var dir in directoryInfos)
                {
                    LoadCDBsFromFolder(dir.FullName);
                }
            }
            if (Directory.Exists("Game") && Directory.Exists("Game/CDB"))
            {
                LoadCDBsFromFolder("Game/CDB");
            }
            if (Directory.Exists(@"locales/en-US"))
            {
                LoadCDBsFromFolder("locales/en-US");
            }
            if (CardsManager.Cards.Count == 0)
            {
                MessageBox.Show("Error importing cards, make sure this app is placed in YGOPro Client's main folder!", "Error while importing cards", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
        private static void LoadCDBsFromFolder(string folderName)
        {
            FileInfo[] fileInfos = (new DirectoryInfo(folderName)).GetFiles().Where(x=>x.Extension==".cdb").OrderByDescending(x => x.Name).ToArray(); //load cards.cdb last this way
            for (int i = 0; i < fileInfos.Length; i++)
            {
                if (fileInfos[i].Name.Length > 4)
                {
                    if (fileInfos[i].Name.Substring(fileInfos[i].Name.Length - 4, 4) == ".cdb")
                    {
                        CardsManager.initialize(Path.Combine(folderName , fileInfos[i].Name));
                    }
                }
            }
        }
    }
}
