using Managers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private OneShotSoundsPlayer oneShotSoundsPlayer;
        [SerializeField] private InputHandler inputHandler;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(gameManager);
            builder.RegisterComponent(oneShotSoundsPlayer);
            builder.RegisterComponent(inputHandler);
        }
    }
}
