using System;
using GFA.TPS.BoosterSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GFA.TPS.UI
{
    public class BoosterCard : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private TMP_Text _title;
        
        [SerializeField]
        private TMP_Text _description;
        
        private Booster _booster;
        public Booster Booster
        {
            get => _booster;
            set
            {
                _booster = value;
                UpdateUI();
            }
        }

        public event Action Clicked;

        private void UpdateUI()
        {
            _title.text = _booster.BoosterName;
            _description.text = _booster.Description;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}