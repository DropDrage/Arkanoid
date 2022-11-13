using System;
using UnityEngine;

namespace Managers.Level
{
    public class LevelProvider : MonoBehaviour
    {
        public Level Level { get; set; }

        public bool HasNextLevel => Level.NextLevel != null;


        public void NextLevel()
        {
            Level = Level.NextLevel ?? throw new ArgumentNullException("No next level");
        }
    }
}
