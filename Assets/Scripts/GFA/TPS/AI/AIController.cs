using GFA.TPS.AI.States;
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
                    BeginBehaviour();
                }
            }
        }

        private AIState _aiState;

        private void Awake()
        {
            if (_aiBehaviour)
            {
                BeginBehaviour();
            }
        }

        private void BeginBehaviour()
        {
            _aiState = _aiBehaviour.CreateState();
            _aiBehaviour.Begin(this);
        }

        private void Update()
        {
            if (AIBehaviour)
            {
                AIBehaviour.OnUpdate(this);
            }
        }

        public bool TryGetState<T>(out T state) where T : AIState
        {
            if (_aiState is T casted)
            {
                state = casted;
                return true;
            }
            else
            {
                state = null;
                return false;
            }
        }
    }
}
