using UnityEngine;

public class GhostState : PlayerState
{
    public GhostStateData _data;

    public GhostState(PlayerController controller, PlayerStateMachine stateMachine, GhostStateData data) :
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
}
