using _Project.Scripts.Common.MusicService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RequestQueueService>().AsSingle();
            Container.Bind<MusicService>().AsSingle().WithArguments(_audioSource);
        }
    }
}