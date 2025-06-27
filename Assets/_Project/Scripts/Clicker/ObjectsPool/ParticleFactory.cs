using UnityEngine;

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
            ObjectsPool = new AnimationObjectsPool<ParticleSystem>(Preload, Get, Return, _vfxData.CountAnimateObjects);
        }
        
        public void Dispose()
        {
            ObjectsPool.Pool.Clear();
        }
        
        private ParticleSystem Preload()
        {
            ParticleSystem particle = Object.Instantiate(_vfxData.ParticleSystem, 
                _objectsParent);
            
            particle.gameObject.SetActive(false);

            return particle;
        }

        private void Get(ParticleSystem particleSystem)
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
        }

        private void Return(ParticleSystem particleSystem)
        {
            particleSystem.gameObject.SetActive(false);
        }
    }
}