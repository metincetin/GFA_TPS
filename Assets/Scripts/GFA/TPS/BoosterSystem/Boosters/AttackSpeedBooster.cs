using GFA.TPS.Mediators;
using UnityEngine;

namespace GFA.TPS.BoosterSystem.Boosters
{
    
	[CreateAssetMenu(menuName = "Boosters/Attack Speed")]
    public class AttackSpeedBooster : Booster
    {
        [SerializeField]
        private float _value;

        public override void OnAdded(BoosterContainer container)
        {
            if (container.TryGetComponent(out PlayerMediator mediator))
            {
                mediator.Attributes.AttackSpeed += _value;
            }
        }
    }
}
