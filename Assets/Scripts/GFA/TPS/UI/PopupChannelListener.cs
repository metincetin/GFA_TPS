using System;
using UnityEngine;

namespace GFA.TPS.UI
{
    public class PopupChannelListener : MonoBehaviour
    {
        private Popup _popup;

        private void Awake()
        {
            _popup = GetComponent<Popup>();
        }

        private void OnEnable()
        {
            PopupChannel.RegisterPopup(_popup);
        }
        private void OnDisable()
        {
            PopupChannel.UnregisterPopup(_popup);
        }
    }
}
