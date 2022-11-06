using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Managers
{
    public enum InputMoveDirection
    {
        Left = -1,
        Idle = 0,
        Right = 1,
    }

    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent startGame;
        [SerializeField] private UnityEvent restartGame;

        public InputMoveDirection MoveDirection
        {
            get;
            private set;
        }

        private UnityEvent<InputMoveDirection> _moveDirectionChanged = new UnityEvent<InputMoveDirection>();


        public void AddMoveDirectionChangedListener(UnityAction<InputMoveDirection> listener)
        {
            _moveDirectionChanged.AddListener(listener);
        }


        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private void OnMove(InputValue value)
        {
            var numericDirection = value.Get<float>();
            var moveDirection = numericDirection switch
            {
                -1f => InputMoveDirection.Left,
                0f => InputMoveDirection.Idle,
                1f => InputMoveDirection.Right,
                _ => throw new ArgumentOutOfRangeException(nameof(numericDirection), numericDirection, null),
            };

            _moveDirectionChanged.Invoke(moveDirection);
            MoveDirection = moveDirection;
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private void OnStartGame()
        {
            startGame.Invoke();
            startGame.RemoveAllListeners();
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private void OnRestart()
        {
            restartGame?.Invoke();
        }
    }
}
