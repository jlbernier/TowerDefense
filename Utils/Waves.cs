using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;

namespace tower_Defense.Utils
{
    public class WaveDatas
    {        
        public string ID;
        public String Name;
        public int Level;
        public int Wave;
        public int NbWaves;
        public int[] NumberEnnemies;
        public Wave.eEnnemyID EnnemyID1;
        public Wave.eEnnemyID EnnemyID2;
        public Wave.eEnnemyID EnnemyID3;
        public Wave.eEnnemyID EnnemyID4;
        public Wave.eEnnemyID EnnemyID5;
        public Wave.eEnnemyID EnnemyID6;
        public Wave.eEnnemyID EnnemyID7;
        public Wave.eEnnemyID EnnemyID8;
        public WaveDatas() { }

        public WaveDatas(WaveDatas pCopy)
        {
            ID = pCopy.ID;
            Name = pCopy.Name;            
        }
    }

    public static class Wave
    {
        public enum eEnnemyID
        {
            LEAFBUG,
            MAGMA_CRAB,
            SCORPION,
            FIREBUG,
            VOIDBUTTERFLY,
            FLYING_LOCUST,
            CLAMPBEETLE,
            FIREWASP,
        }
        public static Dictionary<string, WaveDatas> Data = new Dictionary<string, WaveDatas>();

        public static void PopulateData()
        {
            Data.Add("LEVEL1WAVE1", new WaveDatas
            {
                ID = "LEVEL1WAVE1",
                Name = "Level1Wave1",
                Level = 1,
                Wave = 1,
                NbWaves = 5,
                EnnemyID1 = eEnnemyID.LEAFBUG,
                EnnemyID2 = eEnnemyID.MAGMA_CRAB,
                EnnemyID3 = eEnnemyID.SCORPION,
                EnnemyID4 = eEnnemyID.FIREBUG,
                EnnemyID5 = eEnnemyID.FLYING_LOCUST,
                EnnemyID6 = eEnnemyID.VOIDBUTTERFLY,
                EnnemyID7 = eEnnemyID.CLAMPBEETLE,
                EnnemyID8 = eEnnemyID.FIREWASP,
                NumberEnnemies = new int[] {1, 1, 1 , 1, 1, 1, 1, 1}
            });
            Data.Add("LEVEL1WAVE2", new WaveDatas
            {
                ID = "LEVEL1WAVE2",
                Name = "Level1Wave2",
                Level = 1,
                Wave = 2,
                NbWaves = 5,
                EnnemyID1 = eEnnemyID.LEAFBUG,
                EnnemyID2 = eEnnemyID.MAGMA_CRAB,
                EnnemyID3 = eEnnemyID.SCORPION,
                NumberEnnemies = new int[] { 2, 1, 2  }
            });
            Data.Add("LEVEL1WAVE3", new WaveDatas
            {
                ID = "LEVEL1WAVE",
                Name = "Level1Wave",
                Level = 1,
                Wave = 3,
                NbWaves = 5,
                EnnemyID1 = eEnnemyID.LEAFBUG,
              
                NumberEnnemies = new int[] { 3 }
            }); 
            Data.Add("LEVEL1WAVE4", new WaveDatas
            {
                ID = "LEVEL1WAVE4",
                Name = "Level1Wave4",
                Level = 1,
                Wave = 4,
                NbWaves = 5,
                EnnemyID1 = eEnnemyID.SCORPION,
                EnnemyID2 = eEnnemyID.MAGMA_CRAB,
                EnnemyID3 = eEnnemyID.SCORPION,
                NumberEnnemies = new int[] { 3, 1, 4 }
            }); 
            Data.Add("LEVEL1WAVE5", new WaveDatas
            {
                ID = "LEVEL1WAVE5",
                Name = "Level1Wave",
                Level = 1,
                Wave = 5,
                NbWaves = 5,
                EnnemyID1 = eEnnemyID.FIREBUG,              
                NumberEnnemies = new int[] { 10 }
            });
        }
    }
    
}
