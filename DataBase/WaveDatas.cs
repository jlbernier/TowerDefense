using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense.Animation;

namespace tower_Defense.DataBase
{
    public class WaveDatas
    {
        public string ID;
        public string Name;
        public int Level;
        public int Wave;
        public int NbWaves;
        public int[] NumberEnnemies;
        public float TimeBetweenEnnemies;
        public List<TDWave.eEnnemyID> ListEnnemies;
        public TDWave.eEnnemyID EnnemyID1;
        public TDWave.eEnnemyID EnnemyID2;
        public TDWave.eEnnemyID EnnemyID3;
        public TDWave.eEnnemyID EnnemyID4;
        public TDWave.eEnnemyID EnnemyID5;
        public TDWave.eEnnemyID EnnemyID6;
        public TDWave.eEnnemyID EnnemyID7;
        public TDWave.eEnnemyID EnnemyID8;
        public WaveDatas() { }

        public WaveDatas(WaveDatas pCopy)
        {
            ID = pCopy.ID;
            Name = pCopy.Name;
        }
    }

    public static class TDWave
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
        public static Dictionary<string, WaveDatas> DataWave = new Dictionary<string, WaveDatas>();

        public static void PopulateData()
        {
            DataWave.Add("LEVEL1WAVE1", new WaveDatas
            {
                ID = "LEVEL1WAVE1",
                Name = "Level1Wave1",
                Level = 1,
                Wave = 1,
                TimeBetweenEnnemies = 5f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.SCORPION,                      
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            }) ;
            DataWave.Add("LEVEL1WAVE2", new WaveDatas
            {
                ID = "LEVEL1WAVE2",
                Name = "Level1Wave2",
                Level = 1,
                Wave = 2,
                TimeBetweenEnnemies = 2f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            });
            DataWave.Add("LEVEL1WAVE3", new WaveDatas
            {
                ID = "LEVEL1WAVE",
                Name = "Level1Wave",
                Level = 1,
                Wave = 3,
                TimeBetweenEnnemies = 2f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            });
            DataWave.Add("LEVEL1WAVE4", new WaveDatas
            {
                ID = "LEVEL1WAVE4",
                Name = "Level1Wave4",
                Level = 1,
                Wave = 4,
                TimeBetweenEnnemies = 2f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            });
            DataWave.Add("LEVEL1WAVE5", new WaveDatas
            {
                ID = "LEVEL1WAVE5",
                Name = "Level1Wave",
                Level = 1,
                Wave = 5,
                TimeBetweenEnnemies = 2f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            });
            DataWave.Add("LEVEL1WAVE6", new WaveDatas
            {
                ID = "LEVEL1WAVE6",
                Name = "Level1Wave",
                Level = 1,
                Wave = 6,
                TimeBetweenEnnemies = 2f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
                NumberEnnemies = new int[] { 10 }
            });
            DataWave.Add("LEVEL1WAVE7", new WaveDatas
            {
                ID = "LEVEL1WAVE7",
                Name = "Level1Wave",
                Level = 1,
                Wave = 7,
                TimeBetweenEnnemies = 5f,
                NbWaves = 7,
                ListEnnemies = new List<TDWave.eEnnemyID> {
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB ,
                        eEnnemyID.LEAFBUG,
                        eEnnemyID.MAGMA_CRAB,
                        eEnnemyID.SCORPION,
                        eEnnemyID.FIREBUG,
                        eEnnemyID.VOIDBUTTERFLY,
                        eEnnemyID.FLYING_LOCUST,
                        eEnnemyID.CLAMPBEETLE,
                        eEnnemyID.FIREWASP},
            });
        }
    }

}
