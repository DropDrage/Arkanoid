using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public void OnBallFellOut()
        {
            SceneManager.LoadScene(0);
        }
    }
}
