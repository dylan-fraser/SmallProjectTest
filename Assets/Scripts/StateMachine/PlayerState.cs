using UnityEngine;

public class PlayerState
{
    protected PlayerController _playerController;
    protected PlayerStateMachine _stateMachine;

    protected bool isExitingState;
    protected float startTime;

    public PlayerState(PlayerController controller, PlayerStateMachine stateMachine)
    {
        _playerController = controller;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        isExitingState = false;
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        TransitionChecks();
    }

    public virtual void PhysicsUpdate() {}

    public virtual void TransitionChecks() {}

    public virtual GameObject GetAttackObject()
    {
        return null;
    }

    public virtual float GetAttackCooldown()
    {
        return 1.0f;
    }

    public virtual float GetAttackDamage()
    {
        return 1.0f;
    }
}
