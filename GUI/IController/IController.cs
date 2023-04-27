using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_Defense;

namespace TowerDefence
{
    public interface IController
    {
        public void DrawGUI();
        public void CheckClic(MainGame mainGame);
        public void Update();

    }
}
