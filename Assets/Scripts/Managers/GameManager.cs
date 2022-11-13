using System;
using Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VContainer;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;

        [Space]
        [SerializeField] private UnityEvent beforePlayerRespawned;

        [NonSerialized] public GameObject Platform;

        private ISubscribable _deinitializeEvent;


        [Inject]
        private void Construct(IEventSubscribableProvider eventsProvider)
        {
            _deinitializeEvent = eventsProvider.GetSubscribable(EventKeys.Deinitialize);
        }

        private void OnEnable()
        {
            _deinitializeEvent.Subscribe(Deinitialize);
        }

        private void OnDisable()
        {
            _deinitializeEvent.Unsubscribe(Deinitialize);
        }

        private void Deinitialize()
        {
            DestroyPreviousPlayer();
        }


        public void RespawnPlayer()
        {
            DestroyPreviousPlayer();

            beforePlayerRespawned.Invoke();

            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Platform = playerSpawner.SpawnPlayer();
        }

        private void DestroyPreviousPlayer()
        {
            Destroy(Platform);
        }


        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}
