using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RequestQueueService>().AsSingle();
        }
    }
}