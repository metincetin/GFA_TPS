using UnityEngine;

namespace GFA.TPS.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private AIBehaviour _aiBehaviour;
        public AIBehaviour AIBehaviour
        {
            get => _aiBehaviour;
            set
            {
                if (_aiBehaviour)
                {
                    _aiBehaviour.End(this);
                }

                _aiBehaviour = value;

                if (_aiBehaviour)
                {
                    _aiBehaviour.Begin(this);
                }
            }
        }

        private void Awake()
        {
            if (_aiBehaviour) _aiBehaviour.Begin(this);
        }

        private void Update()
        {
            if (AIBehaviour)
            {
                AIBehaviour.Update(this);
            }
        }
    }
}
