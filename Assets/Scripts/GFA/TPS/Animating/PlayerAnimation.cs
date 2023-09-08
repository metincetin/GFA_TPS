using System;
using UnityEngine;

namespace GFA.TPS.Animating
{
	public class PlayerAnimation : MonoBehaviour
	{
		
		[SerializeField] private Animator _animator;

		private static readonly int Horizontal = Animator.StringToHash("Horizontal");
		private static readonly int Vertical = Animator.StringToHash("Vertical");


		private Vector3 _appliedVelocity;
		private Vector3 _currentTransitionVelocity;
		private static readonly int Fire = Animator.StringToHash("Fire");

		public Vector3 Velocity { get; set; }

		private void Update()
		{
			var transformedVelocity = Quaternion.Euler(0, -transform.eulerAngles.y,0) * Velocity;
			_appliedVelocity = Vector3.SmoothDamp(_appliedVelocity,transformedVelocity, ref _currentTransitionVelocity, 
				(transformedVelocity.magnitude < 0.01f ? 3 : 8) * Time.deltaTime);
			
			_animator.SetFloat(Horizontal, _appliedVelocity.x);
			_animator.SetFloat(Vertical, _appliedVelocity.z);
		}

		public void PlayFireAnimation()
		{
			_animator.SetTrigger(Fire);
		}

		public void SetAnimationController(RuntimeAnimatorController animationController)
		{
			_animator.runtimeAnimatorController = animationController;
		}
	}
}