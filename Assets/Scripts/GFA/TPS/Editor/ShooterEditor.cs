using GFA.TPS.WeaponSystem;
using UnityEditor;
using UnityEngine;

namespace GFA.TPS.Editor
{
    [CustomEditor(typeof(Shooter))]
    public class ShooterEditor : UnityEditor.Editor
    {
        private Weapon _weapon;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _weapon = EditorGUILayout.ObjectField(_weapon, typeof(Weapon)) as Weapon;
            
            if (GUILayout.Button("Switch Weapon"))
            {
                var shooter = target as Shooter;
                shooter.EquipWeapon(_weapon);
            }
        }
    }
}
