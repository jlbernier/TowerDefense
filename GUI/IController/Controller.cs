using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using tower_Defense;

namespace TowerDefence
{
    public abstract class Controller : IController
    {
        public Controller() 
        {
        
        }
        public abstract void Update();
        public abstract void CheckClic(MainGame mainGame);
        public abstract void DrawGUI();

        
    }
}
