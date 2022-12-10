using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	#region Fields
	[Header("Settings")]
	[SerializeField][Range(0f, 100f)] private float _playerSpeed;
	[SerializeField][Range(0f, 100f)] private float _rotationSensitivity;

	[Header("System fields")]
	[SerializeField] private Transform _camera;
	[SerializeField] private PlayerInput _playerInput;

	[SerializeField] private Animator _animator;
	private Transform _playerTransform
    {
		get { return this.transform; }
    }
    #endregion


    #region Main Methods
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
		Move();
		RotatForMouseLook();
    }
    #endregion


    #region Helper Methods
    private void Move()
    {
		Vector2 direction = _playerInput.GetMoveDirection();

		float scaledMoveSpeed = _playerSpeed * Time.deltaTime;

		Vector3 directionForfard = _playerTransform.forward * direction.y;
		Vector3 directionSide = _playerTransform.right * direction.x;
		Vector3 moveDirection = _playerTransform.position + directionForfard + directionSide;

		this.transform.position = Vector3.MoveTowards(_playerTransform.position, moveDirection, scaledMoveSpeed);

		_animator.SetFloat("moveForward", direction.y);
		_animator.SetFloat("moveSide", direction.x);
	}

	private void RotatForMouseLook()
    {
		Vector2 mouseLook = _playerInput.GetMouseLook();

		float scaledAngularSpeed = _rotationSensitivity * Time.deltaTime;

		Vector3 scaledRotate = mouseLook * scaledAngularSpeed;
		Vector3 rotation = new Vector3(0.0f, scaledRotate.x, 0.0f);

		this.transform.Rotate(rotation);
    }
	#endregion
}

