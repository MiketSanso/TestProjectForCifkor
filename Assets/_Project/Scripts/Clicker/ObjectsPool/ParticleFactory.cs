using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Clicker.ObjectsPool
{
    public class ParticleFactory
    {
        private readonly VFXData _vfxData;
        private readonly Transform _objectsParent;
        
        public AnimationObjectsPool<ParticleSystem> ObjectsPool { get; private set; }

        public ParticleFactory(VFXData vfxData,
            Transform transformParent)
        {
            _vfxData = vfxData;
            _objectsParent = transformParent;
            ObjectsPool = new AnimationObjectsPool<ParticleSystem>(Preload, Get, Return, _vfxData.CountParticles);
        }
        
        private ParticleSystem Preload()
        {
            ParticleSystem particle = Object.Instantiate(_vfxData.PrefabParticleSystem, 
                _objectsParent);
            
            particle.gameObject.SetActive(false);

            return particle;
        }

        private async void Get(ParticleSystem particleSystem)
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();

            await UniTask.Delay(TimeSpan.FromSeconds(_vfxData.TimeReturnParticles));

                ObjectsPool.Return(particleSystem);
        }

        private void Return(ParticleSystem particleSystem)
        {
            particleSystem.gameObject.SetActive(false);
        }
    }
}