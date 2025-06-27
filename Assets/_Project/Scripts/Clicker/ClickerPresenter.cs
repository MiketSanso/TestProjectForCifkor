using System;
using _Project.Scripts.Clicker.ObjectsPool;
using _Project.Scripts.Common.DOTweenServices;
using _Project.Scripts.Common.MusicService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Clicker
{
    public class ClickerPresenter : IInitializable, IDisposable
    {
        private readonly ClickerView _view;
        private readonly ClickerModel _clickerModel;
        private readonly ClickerData _clickerData;
        private readonly PunchScale _punchScale = new PunchScale();
        private readonly VFXData _vfxData;
        private readonly MusicService _musicService;

        private ImageFactory _imageFactory;
        private ParticleFactory _particleFactory;

        public ClickerPresenter(ClickerView view,
            ClickerModel clickerModel,
            ClickerData clickerData,
            VFXData vfxData,
            MusicService musicService)
        {
            _view = view;
            _clickerModel = clickerModel;
            _clickerData = clickerData;
            _vfxData = vfxData;
            _musicService = musicService;
            
            _imageFactory = new ImageFactory(_vfxData, _view.TransformButton);
            _particleFactory = new ParticleFactory(_vfxData, _view.TransformButton);
        }

        public void Initialize()
        {
            _view.OnButtonClick += TryAddMoney;
            _view.OnClickAnimation += CreateVFXButton;
        }

        public void Dispose()
        {
            _view.OnButtonClick -= TryAddMoney;
            _view.OnClickAnimation -= CreateVFXButton;

        }

        public void UpdateUI()
        {
            _view.ChangeEnergy((float)_clickerModel.CountEnergy / _clickerData.MaxCountEnergy, $"{_clickerModel.CountEnergy}/{_clickerData.MaxCountEnergy}");
            _view.ChangeMoney(_clickerModel.CountMoney.ToString());
        }

        private void TryAddMoney()
        {
            if (_clickerModel.CountEnergy >= _clickerData.PriceOneClick)
            {
                _clickerModel.SetCountEnergy(_clickerModel.CountEnergy - _clickerData.PriceOneClick);
                _clickerModel.SetCountMoney(_clickerModel.CountMoney + _clickerData.PriceOneClick);
                UpdateUI();
            }
        }

        private void CreateVFXButton()
        {
            _punchScale.Punch(_view.TransformButton, Vector3.one, _vfxData.DurationPunch);
            _musicService.PlaySound(_vfxData.AudioClip);
            _particleFactory.ObjectsPool.Get();
            _imageFactory.ObjectsPool.Get();
        }
    }
}