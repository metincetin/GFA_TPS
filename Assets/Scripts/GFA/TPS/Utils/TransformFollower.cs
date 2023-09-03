using UnityEngine;

namespace GFA.TPS.Utils
{
    public class TransformFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}