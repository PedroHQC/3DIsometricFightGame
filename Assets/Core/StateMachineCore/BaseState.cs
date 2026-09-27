using UnityEngine;

public class BaseState : MonoBehaviour
{   
    public virtual StateTypes stateType => StateTypes.None;

    protected BaseStateMachine _stateMachine;
    public virtual void Start()
    {
        transform.parent.TryGetComponent<BaseStateMachine>(out _stateMachine);
        if(_stateMachine != null)
        {
            _stateMachine.RegisterState(this);
        }
    }
    public virtual void Enter() { }
    public virtual void StateUpdate() { }
}
