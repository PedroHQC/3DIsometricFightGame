using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    protected List<BaseState> _states = new();
    protected BaseState _currentState;
    void Start() { }

    public virtual void Update()
    {
        if(_currentState != null)
        {
            _currentState.StateUpdate();
        }
    }

    public virtual void RegisterState(BaseState state)
    {
        _states.Add(state);
    }

    public virtual void ChangeState(StateTypes stateType)
    {
        BaseState nextState = _states.Find((state) => state.stateType == stateType);

        if (nextState != null)
        {
            _currentState = nextState;
            _currentState.Enter();
        }
    }

}
