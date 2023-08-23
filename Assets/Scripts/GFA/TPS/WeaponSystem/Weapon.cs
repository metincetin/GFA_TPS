using UnityEngine;

namespace GFA.TPS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField, Min(0)]
        private float _fireRate = 0.5f;
        public float FireRate => _fireRate;
        
        [SerializeField, Range(0, 1f)]
        private float _accuracy = 1f;
        public float Accuracy => _accuracy;

        [SerializeField]
        private float _recoil;
        public float Recoil => _recoil;

        [SerializeField]
        private float _recoilFade;
        public float RecoilFade => _recoilFade;
        
        [SerializeField]
        private GameObject _projectilePrefab;
        public GameObject ProjectilePrefab => _projectilePrefab;

        [SerializeField]
        private WeaponGraphics _weaponGraphics;
        public WeaponGraphics WeaponGraphics => _weaponGraphics;
    }
}
