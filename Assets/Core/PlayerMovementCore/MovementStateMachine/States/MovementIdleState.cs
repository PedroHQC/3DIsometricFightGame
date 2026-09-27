using UnityEngine;

public class MovementIdleState : BaseState
{
    public override StateTypes stateType => StateTypes.Idle;
    public Vector2 dir = new();
    
    public override void Start()
    {
        base.Start();
        _stateMachine.ChangeState(stateType);
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if(_stateMachine is PlayerMovementStateMachine movementStateMachine)
        movementStateMachine.MovePlayer(dir);
    }
}
