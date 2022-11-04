using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}
