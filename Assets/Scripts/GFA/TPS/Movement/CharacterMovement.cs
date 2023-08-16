using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TPS.Movement
{
	[RequireComponent(typeof(CharacterController))]
	public class CharacterMovement : MonoBehaviour
	{
		private CharacterController _characterController;
		
		public Vector3 ExternalForces { get; set; }
		
		public Vector2 MovementInput { get; set; }

		[SerializeField]
		private float _movementSpeed = 4;
		
		
		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			var movement = new Vector3(MovementInput.x, 0, MovementInput.y);
			
			_characterController.SimpleMove(movement * _movementSpeed + ExternalForces);

			ExternalForces = Vector3.Lerp(ExternalForces,Vector3.zero, 8 * Time.deltaTime);
		}
	}
}