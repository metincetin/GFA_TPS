using System;
using GFA.TPS.MatchSystem;
using TMPro;
using UnityEngine;

namespace GFA.TPS.UI
{
    public class GameTimeView : MonoBehaviour
    {
        [SerializeField]
        private MatchInstance _matchInstance;

        [SerializeField]
        private TMP_Text _text;

        private void Update()
        {
            var timeSpan = TimeSpan.FromSeconds(_matchInstance.Time);
            
            _text.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
