using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelInitializer levelInitializer;

        [Space]
        [SerializeField] private UnityEvent beforePlayerRespawned;

        private GameObject _platform;


        public void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            _platform = levelInitializer.SpawnPlayer();
        }

        public void RespawnPlayer()
        {
            DestroyPreviousPlayer();

            beforePlayerRespawned.Invoke();

            SpawnPlayer();
        }

        private void DestroyPreviousPlayer()
        {
            Destroy(_platform);
        }


        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}
