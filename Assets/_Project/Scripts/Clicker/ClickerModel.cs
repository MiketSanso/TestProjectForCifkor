using UnityEngine;

namespace _Project.Scripts.Clicker
{
    public class ClickerModel
    {
        private readonly ClickerData _clickerData;
        
        public int CountEnergy { get; private set; }
        public int CountMoney { get; private set; }

        public ClickerModel(ClickerData clickerData)
        {
            CountEnergy = clickerData.MaxCountEnergy;
            _clickerData = clickerData;
        }

        public void SetCountEnergy(int energy)
        {
            CountEnergy = Mathf.Clamp(energy, 0, _clickerData.MaxCountEnergy);
        }
        
        public void SetCountMoney(int money)
        {
            CountMoney = Mathf.Clamp(money, 0, _clickerData.MaxCountMoney);
        }
    }
}