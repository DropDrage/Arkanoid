using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent startGame;
        [SerializeField] private UnityEvent restartGame;

        public float MoveDirection
        {
            get;
            private set;
        }


        private void OnMove(InputValue value)
        {
            MoveDirection = value.Get<float>();
        }

        private void OnStartGame()
        {
            startGame.Invoke();
            startGame.RemoveAllListeners();
        }

        private void OnRestart()
        {
            restartGame?.Invoke();
        }
    }
}
