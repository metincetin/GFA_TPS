using GFA.TPS.BoosterSystem;
using TMPro;
using UnityEngine;

namespace GFA.TPS.UI
{
    public class BoosterCard : MonoBehaviour
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

        private void UpdateUI()
        {
            _title.text = _booster.BoosterName;
            _description.text = _booster.Description;
        }
    }
}
