using UnityEngine;

namespace GFA.TPS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField, Min(0)]
        private float _fireRate = 0.5f;
        
        [SerializeField, Range(0, 1f)]
        private float _accuracy = 1f;

        [SerializeField]
        private float _recoil;

        [SerializeField]
        private float _recoilFade;
    }
}
