using UnityEngine;

namespace GFA.TPS.WeaponSystem.FX
{
	public class WeaponParticleFX : WeaponFX
	{
		[SerializeField]
		private ParticleSystem[] _particleSystems;
		
		protected override void OnShot()
		{
			foreach (var p in _particleSystems)
			{
				p.Play();
			}
		}
	}
}