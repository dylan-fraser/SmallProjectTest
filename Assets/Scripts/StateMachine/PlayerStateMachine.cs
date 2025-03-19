using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState _currentState { get; private set; }

    public void InitializeStateMachine(PlayerState initialState)
    { 
        _currentState = initialState;
        _currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
