using System;
using GFA.TPS.AI.States;
using UnityEngine;
using UnityEngine.Profiling;

namespace GFA.TPS.AI
{
	public abstract class AIBehaviour : ScriptableObject
	{
		public abstract void Begin(AIController controller);

		public void OnUpdate(AIController controller)
		{
			Profiler.BeginSample($"AIBehaviour({name}).Execute" );
			Execute(controller);
			Profiler.EndSample();
		}
		public abstract void End(AIController controller);
		protected abstract void Execute(AIController controller);

		public virtual AIState CreateState()
		{
			return new NullAIState();
		}
	}
}
