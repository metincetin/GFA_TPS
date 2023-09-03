using UnityEngine;
using UnityEngine.UI;

namespace GFA.TPS.UI
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class Popup : MonoBehaviour
    {
        private Canvas _canvas;
        private GraphicRaycaster _raycaster;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent<GraphicRaycaster>();
        }

        public bool IsOpen => _canvas.enabled;
        
        public void Open()
        {
            if (IsOpen) return;
            _canvas.enabled = true;
            _raycaster.enabled = true;
            OnOpened();
        }

        public void Close()
        {
            if (!IsOpen) return;
            _canvas.enabled = false;
            _raycaster.enabled = false;
            OnClosed();
        }

        protected virtual void OnOpened()
        {
        }
        
        protected virtual void OnClosed()
        {
        }
    }
}
