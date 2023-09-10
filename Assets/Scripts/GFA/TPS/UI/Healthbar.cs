using GFA.TPS.Mediators;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TPS.UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField]
        private PlayerMediator _playerMediator;

        [SerializeField]
        private Image _fillImage;

        private void Update()
        {
            var health = _playerMediator.Health / _playerMediator.Attributes.MaxHealth;
            _fillImage.fillAmount = health;
        }
    }
}
