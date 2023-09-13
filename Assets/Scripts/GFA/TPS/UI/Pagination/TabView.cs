using System;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TPS.UI.Pagination
{
    public class TabView : MonoBehaviour
    {
        [SerializeField]
        private PageTabButtonPair[] _pairs;

        [SerializeField]
        private Router _router;
        
        [System.Serializable]
        public class PageTabButtonPair
        {
            public Page Page;
            public Button Button;
        }

        private void Awake()
        {
            foreach (var pair in _pairs)
            {
                pair.Button.onClick.AddListener(() =>
                {
                    // request router to open the page
                    _router.ActivePage = pair.Page;
                });
            }
        }
    }
}
