using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent gameStart;
    
        public float MoveDirection
        {
            get;
            private set;
        }


        private void OnMove(InputValue value)
        {
            MoveDirection = value.Get<float>();
        }

        private void OnStartGame(InputValue value)
        {
            print("Game start");
            gameStart.Invoke();
            gameStart.RemoveAllListeners();
        }
    }
}