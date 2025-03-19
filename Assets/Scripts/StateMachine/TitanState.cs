using UnityEngine;

public class TitanState : PlayerState
{
    public TitanStateData _data;
    private Vector3 _oldScale;
    private Vector3 _positionChange;
    private Vector3 _newScale;

    public TitanState(PlayerController controller, PlayerStateMachine stateMachine, TitanStateData data) :
        base(controller, stateMachine)
    {
        _data = data;
        _positionChange = new Vector3(0.0f, (_data._scaleChange / 2.0f), 0.0f);
        _newScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public override void Enter()
    {
        base.Enter();

        _playerController.ChangeMaterial(_data._stateMaterial);

        _oldScale = _playerController.transform.localScale;
        _positionChange.y = _data._scaleChange/2.0f;
        _playerController.transform.position += _positionChange;

        float newScale = _playerController.transform.localScale.x+_data._scaleChange;
        _newScale.x = newScale;
        _newScale.y = newScale;
        _newScale.z = newScale;

       _playerController.transform.localScale = _newScale;
    }

    public override void Exit()
    {
        base.Exit();

        _playerController.transform.localScale = _oldScale;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _playerController.ApplyRotation(_data._rotationSmoothTime);
        _playerController.ApplyGravity(_data._gravityMultiplier);
        _playerController.ApplyMovement(_data._speed);
    }

    public override void TransitionChecks()
    {
        base.TransitionChecks();

        //need to have information passed so that we know to transition state appropriately
    }

    public override GameObject GetAttackObject()
    {
        return _data._attackToSpawn;
    }

    public override float GetAttackCooldown()
    {
        return _data._attackCooldown;
    }

    public override float GetAttackDamage()
    {
        return _data._attackDamage;
    }
}
