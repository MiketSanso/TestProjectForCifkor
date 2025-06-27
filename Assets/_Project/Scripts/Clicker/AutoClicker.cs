using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Clicker
{
    public class AutoClicker
    {
        private CancellationTokenSource _cts;
        
        private readonly ClickerModel _clickerModel;
        private readonly ClickerData _clickerData;
        private readonly ClickerPresenter _clickerPresenter;

        public AutoClicker(ClickerModel clickerModel,
            ClickerData clickerData,
            ClickerPresenter clickerPresenter)
        {
            _clickerModel = clickerModel;
            _clickerData = clickerData;
            _clickerPresenter = clickerPresenter;
        }
        
        public void StopClicks()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }

        public async void StartClicks()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
                StopClicks();
            
            _cts = new CancellationTokenSource();
            await ClicksTask();
        }
        
        private async UniTask ClicksTask()
        {
            try
            {
                while (_cts != null && !_cts.IsCancellationRequested)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(_clickerData.TimeAutoClick),
                        cancellationToken: _cts.Token);

                    if (_clickerModel.CountEnergy >= _clickerData.PriceOneAutoClick)
                    {
                        _clickerModel.SetCountEnergy(_clickerModel.CountEnergy - _clickerData.PriceOneAutoClick);
                        _clickerModel.SetCountMoney(_clickerModel.CountMoney + _clickerData.ProfitPerAutoClick);
                        _clickerPresenter.UpdateUI();
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Energy recharge was cancelled");
            }
        }
    }
}