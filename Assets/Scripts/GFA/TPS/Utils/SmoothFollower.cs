using System;
using DG.Tweening;
using UnityEngine;

namespace GFA.TPS.Utils
{
	public class SmoothFollower: MonoBehaviour
	{
		public Transform Target { get; set; }
		private const float FOLLOW_SPEED = 5;
		private const float ACCEPTANCE_RADIUS = 1;
		
		private bool _reachedDestination;

		public event Action ReachedDestination;

		private Vector3 _smoothMovementVelocity;
		
		

		private void Update()
		{
			if (Target)
			{
				transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _smoothMovementVelocity,FOLLOW_SPEED * Time.deltaTime);

				if (Vector3.Distance(Target.position, transform.position) < ACCEPTANCE_RADIUS)
				{
					if (!_reachedDestination)
					{
						ReachedDestination?.Invoke();
						_reachedDestination = true;
					}
				}
				else
				{
					_reachedDestination = false;
				}
			}
		}
	}
}