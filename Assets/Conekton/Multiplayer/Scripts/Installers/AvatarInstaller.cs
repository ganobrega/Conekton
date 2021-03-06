using UnityEngine;
using Zenject;

using Conekton.ARMultiplayer.Avatar.Domain;
using Conekton.ARMultiplayer.Avatar.Infrastructure;
using Conekton.ARMultiplayer.Avatar.Presentation;

namespace Conekton.ARMultiplayer.Avatar.Application
{
    public class AvatarInstaller : MonoInstaller
    {
        [SerializeField] private Presentation.Avatar _avatarPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IAvatarSystem>().To<AvatarSystem>().AsCached();
            Container.Bind<IAvatarRepository>().To<AvatarRepository>().AsCached();

            Container.BindInterfacesAndSelfTo<PlayerAvatarController>().AsCached();
            Container.Bind<IAvatarController>().WithId("Player").To<PlayerAvatarController>().FromResolve();

            Container.BindInterfacesAndSelfTo<AvatarService>().AsCached().NonLazy();

            Container.BindFactory<AvatarID, Presentation.Avatar, AvatarFactory>().FromComponentInNewPrefab(_avatarPrefab);
        }
    }
}

