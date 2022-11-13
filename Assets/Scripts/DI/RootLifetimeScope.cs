using Managers.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private LevelProvider levelProvider;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(levelProvider);
        }
    }
}
