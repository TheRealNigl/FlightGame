using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Strings
{
    internal class SceneHierarchy
    {
        private static SceneHierarchy sceneHierarchy { get; set; }

        #region strings

        private static string[] sceneNames = { "Assets/Scenes/Flight.unity" };
        private static string[] SceneNames { get { return sceneNames; } set { } }

        #endregion


        public void SetSceneHierarchy()
        {

        }
    }
}
