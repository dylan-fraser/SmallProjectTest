using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region State Machine
    private PlayerStateMachine _playerStateMachine;

    private GhostState _ghostState;
    private FighterState _fighterState;
    private TitanState _titanState;

    [SerializeField] private GhostStateData _ghostData;
    [SerializeField] private TitanStateData _titanData;
    [SerializeField] private FighterStateData _fighterData;
    #endregion

    #region Attacks
    private bool _hasAttacked = false;
    private float _attackTime = 0.0f;
    #endregion

    #region Movement
    private CharacterController _characterController;
    private Vector2 _input;
    private Vector3 _direction;
    #endregion

    #region Rotation
    private float _currentVelocity;
    #endregion

    #region Gravity
    private float _gravity = -9.81f;
    private float _gravityVelocity;
    #endregion

    #region Materials
    private MeshRenderer _playerMeshRenderer;
    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerMeshRenderer = GetComponent<MeshRenderer>();

        _playerStateMachine = new PlayerStateMachine();

        _ghostState = new GhostState(this, _playerStateMachine, _ghostData);
        _fighterState = new FighterState(this, _playerStateMachine, _fighterData);
        _titanState = new TitanState(this, _playerStateMachine, _titanData);

        _playerStateMachine.InitializeStateMachine(_ghostState);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UseAttack();
        }
    }

    private void Update()
    {
        _playerStateMachine._currentState.LogicUpdate();

        _attackTime += Time.deltaTime;
        if(_attackTime > _playerStateMachine._currentState.GetAttackCooldown())
        {
            _hasAttacked = false;
            _attackTime = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        _playerStateMachine._currentState.PhysicsUpdate();
    }

    public void DebugToGhostState()
    {
        _playerStateMachine.ChangeState(_ghostState);
    }

    public void DebugToFighterState()
    {
        _playerStateMachine.ChangeState(_fighterState);
    }

    public void DebugToTitanState()
    {
        _playerStateMachine.ChangeState(_titanState);
    }

    public void UseAttack()
    {
        if(!_hasAttacked)
        {
            _hasAttacked = true;

            if(_playerStateMachine._currentState.GetAttackObject() != null)
            {
                GameObject Attack = Instantiate(_playerStateMachine._currentState.GetAttackObject(), this.transform);
                AttackGameObject AttackComponent = Attack.GetComponent<AttackGameObject>();
                AttackComponent.InitializeAttack(_playerStateMachine._currentState.GetAttackDamage(), this.gameObject);
            }
        }
    }

    public void ApplyGravity(float gravityMultiplier)
    {
        if(_characterController.isGrounded)
        {
            _gravityVelocity = -1.0f;
        }
        else
        {
            _gravityVelocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _gravityVelocity;
    }

    public void ApplyRotation(float smoothTime)
    {
        if(_input.sqrMagnitude == 0.0f) return;

        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

    }

    public void ApplyMovement(float speed)
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void ChangeMaterial(Material newMaterial)
    {
        _playerMeshRenderer.material = newMaterial;
    }
}
