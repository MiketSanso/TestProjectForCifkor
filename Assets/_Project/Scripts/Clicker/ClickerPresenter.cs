using System;
using Zenject;

namespace _Project.Scripts.Clicker
{
    public class ClickerPresenter : IInitializable, IDisposable
    {
        private readonly ClickerView _view;
        private readonly ClickerModel _clickerModel;
        private readonly ClickerData _clickerData;

        public ClickerPresenter(ClickerView view,
            ClickerModel clickerModel,
            ClickerData clickerData)
        {
            _view = view;
            _clickerModel = clickerModel;
            _clickerData = clickerData;
        }

        public void Initialize()
        {
            _view.OnButtonClick += TryAddMoney;
        }

        public void Dispose()
        {
            _view.OnButtonClick -= TryAddMoney;
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
    }
}