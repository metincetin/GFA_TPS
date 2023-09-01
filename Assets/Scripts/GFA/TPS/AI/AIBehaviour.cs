using UnityEngine;
using UnityEngine.Profiling;

namespace GFA.TPS.AI
{
	public abstract class AIBehaviour : ScriptableObject
	{
		public abstract void Begin(AIController controller);

		public void Update(AIController controller)
		{
			Profiler.BeginSample("AI Behaviour: " + name);
			Execute(controller);
			Profiler.EndSample();
		}
		public abstract void End(AIController controller);
		protected abstract void Execute(AIController controller);
	}
}
