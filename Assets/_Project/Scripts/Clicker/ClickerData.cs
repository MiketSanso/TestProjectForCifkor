using UnityEngine;

namespace _Project.Scripts.Clicker
{
    [CreateAssetMenu(fileName = "ClickerData", menuName = "ClickerData", order = 0)]
    public class ClickerData : ScriptableObject
    {
        [field: SerializeField] public int MaxCountEnergy { get; private set; }
        [field: SerializeField] public int MaxCountMoney { get; private set; }
        [field: SerializeField] public int PriceOneClick { get; private set; }
        [field: SerializeField] public int PriceOneAutoClick { get; private set; }
        [field: SerializeField] public int ProfitPerClick { get; private set; }
        [field: SerializeField] public int ProfitPerAutoClick { get; private set; }
        [field: SerializeField] public int SizeRechargeEnergy { get; private set; }
        [field: SerializeField] public float TimeRechargeEnergy { get; private set; }
        [field: SerializeField] public float TimeAutoClick { get; private set; }


    }
}