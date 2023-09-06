using UnityEngine;

namespace GFA.TPS.Animating
{
	public class AnimationEventBinder : MonoBehaviour
	{
		public void ExecuteDamage()
		{
			var executor = GetComponentInParent<IDamageExecutor>();
			
			if (executor != null)
			{
				executor.ExecuteDamage();
			}
		}
	}
}