using DG.Tweening;
using GFA.TPS.BoosterSystem;
using UnityEngine;

namespace GFA.TPS.UI.Popups
{
    public class BoosterSelectionPopup : Popup
    {
        [SerializeField]
        private BoosterList _boosterList;

        [SerializeField] 
        private BoosterCard _boosterCardPrefab;

        [SerializeField] 
        private Transform _container;
        
        public BoosterContainer TargetBoosterContainer { get; set; }

        protected override void OnOpened()
        {
            Time.timeScale = 0;
            foreach (Transform c in _container)
            {
                Destroy(c.gameObject);
            }

            for (int i = 0; i < 3; i++)
            {
                var randomBooster = _boosterList.Get(Random.Range(0, _boosterList.Length));
                var inst = Instantiate(_boosterCardPrefab, _container);
                inst.Booster = randomBooster;
                inst.Clicked += () =>
                {
                    TargetBoosterContainer.AddBooster(inst.Booster);
                    Close();
                };
            }
        }

        protected override void OnClosed()
        {
            Time.timeScale = 1;
        }
    }
}
