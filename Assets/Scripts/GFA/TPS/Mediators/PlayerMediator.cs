using System;
using System.Collections;
using System.Collections.Generic;
using GFA.TPS.Input;
using GFA.TPS.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GFA.TPS.Mediators
{
	public class PlayerMediator : MonoBehaviour
	{
		private CharacterMovement _characterMovement;
		private Shooter _shooter;

		private GameInput _gameInput;

		[SerializeField] private float _dodgePower;

		private Plane _plane = new Plane(Vector3.up, Vector3.zero);

		private Camera _camera;

		private void Awake()
		{
			_characterMovement = GetComponent<CharacterMovement>();
			_shooter = GetComponent<Shooter>();
			_gameInput = new GameInput();

			_camera = Camera.main;
		}

		private void OnEnable()
		{
			_gameInput.Enable();
			_gameInput.Player.Dodge.performed += OnDodgeRequested;
		}

		private void OnDisable()
		{
			_gameInput.Disable();
			_gameInput.Player.Dodge.performed -= OnDodgeRequested;
		}

		private void OnDodgeRequested(InputAction.CallbackContext obj)
		{
			_characterMovement.ExternalForces += _characterMovement.Velocity.normalized * _dodgePower;
		}

		private void Update()
		{
			HandleMovement();

			if (_gameInput.Player.Shoot.IsPressed())
			{
				_shooter.Shoot();
			}
		}

		private void HandleMovement()
		{
			var movementInput = _gameInput.Player.Movement.ReadValue<Vector2>();
			_characterMovement.MovementInput = movementInput;

			var ray = _camera.ScreenPointToRay(_gameInput.Player.PointerPosition.ReadValue<Vector2>());

			var gamepadLookDir = _gameInput.Player.Look.ReadValue<Vector2>();

			if (gamepadLookDir.magnitude > 0.1f)
			{
				var angle = -Mathf.Atan2(gamepadLookDir.y, gamepadLookDir.x) * Mathf.Rad2Deg + 90;
				_characterMovement.Rotation = angle;
			}
			else
			{
				if (_plane.Raycast(ray, out float enter))
				{
					var worldPosition = ray.GetPoint(enter);
					var dir = (worldPosition - transform.position).normalized;
					//Quaternion.LookRotation(dir).eulerAngles.y

					var angle = -Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;
					_characterMovement.Rotation = angle;
				}
			}
		}
	}
}