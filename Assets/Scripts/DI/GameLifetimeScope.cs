using Managers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private InputHandler inputHandler;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(gameManager);
            builder.RegisterComponent(soundManager);
            builder.RegisterComponent(inputHandler);
        }
    }
}
