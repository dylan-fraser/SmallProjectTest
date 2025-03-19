using UnityEngine;

public class FighterState : PlayerState
{
    public FighterStateData _data;
    public FighterState(PlayerController controller, PlayerStateMachine stateMachine, FighterStateData data) :
        base(controller, stateMachine)
    {
        _data = data;
    }

    public override void Enter()
    {
        base.Enter();

        _playerController.ChangeMaterial(_data._stateMaterial);
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
