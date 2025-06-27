using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Clicker
{
    public class EnergyRecharger
    {
        private CancellationTokenSource _cts;
        
        private readonly ClickerModel _clickerModel;
        private readonly ClickerData _clickerData;
        private readonly ClickerPresenter _clickerPresenter;

        public EnergyRecharger(ClickerModel clickerModel,
            ClickerData clickerData,
            ClickerPresenter clickerPresenter)
        {
            _clickerModel = clickerModel;
            _clickerData = clickerData;
            _clickerPresenter = clickerPresenter;
        }

        public void StopRecharging()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }

        public async void StartRecharge()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
                StopRecharging();
            
            _cts = new CancellationTokenSource();
            await RechargeTask();
        }
        
        private async UniTask RechargeTask()
        {
            try
            {
                while (_cts != null && !_cts.IsCancellationRequested)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(_clickerData.TimeRechargeEnergy), cancellationToken: _cts.Token);
                    
                    if (_clickerModel.CountEnergy < _clickerData.MaxCountEnergy)
                    {
                        _clickerModel.SetCountEnergy(_clickerModel.CountEnergy + _clickerData.SizeRechargeEnergy);
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