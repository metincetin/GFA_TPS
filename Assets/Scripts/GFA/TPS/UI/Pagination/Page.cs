using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TPS.UI.Pagination
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public abstract class Page : MonoBehaviour
    {

        private Canvas _canvas;
        private GraphicRaycaster _raycaster;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent <GraphicRaycaster>();
            OnAwake();
        }
        
        protected virtual void OnAwake(){}
        
        public void Open()
        {
            _canvas.enabled = true;
            _raycaster.enabled = true;
            OnOpened();
        }
        
        public void Close()
        {
            _canvas.enabled = false;
            _raycaster.enabled = false;
            OnClosed();
        }

        protected abstract void OnOpened();
        protected abstract void OnClosed();
    }
}