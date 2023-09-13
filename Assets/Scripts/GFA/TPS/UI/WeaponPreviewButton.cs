using System;
using GFA.TPS.WeaponSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GFA.TPS.UI
{
    public class WeaponPreviewButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _weaponIcon;
        
        private Weapon _weapon;
        public Weapon Weapon
        {
            get => _weapon;
            set
            {
                _weapon = value;
                if (_weapon)
                {
                    _weaponIcon.sprite = _weapon.Icon;
                }
            }
        }

        public event Action Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}
