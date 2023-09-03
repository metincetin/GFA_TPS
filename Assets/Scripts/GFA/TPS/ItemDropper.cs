using UnityEngine;

namespace GFA.TPS
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField]
        private float _xp;

        [SerializeField, Range(0,1)]
        private float _xpDropChange;

        [SerializeField]
        private XPCollectable _xpCollectablePrefab;

        public void OnDied()
        {
            if (_xpCollectablePrefab && Random.value < _xpDropChange)
            {
                var inst = Instantiate(_xpCollectablePrefab, transform.position, Quaternion.identity);
                inst.XP = _xp;
            }
        }
    }
}
