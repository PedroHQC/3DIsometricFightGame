using UnityEngine;

public class PlayerMovementStateMachine : BaseStateMachine
{
    [SerializeField] private PlayerMovementConfigScriptable MoveConfigData;
    [HideInInspector] public PlayerInput playerInput;
    public Rigidbody playerPhysicsBody;

    void Start()
    {
        playerInput = new();
    }
    public override void Update()
    {
        base.Update();
    }

    public override void RegisterState(BaseState state)
    {
        base.RegisterState(state);
    }

    public override void ChangeState(StateTypes stateType)
    {
        base.ChangeState(stateType);

    }
    public void ApplyForceToPlayer(Vector3 force)
    {
        playerPhysicsBody.AddForce(force);
    }

    public void MovePlayer(Vector2 direction)
    {
        float maxSpeed = MoveConfigData.playerMaxSpeed;
        float acceleration = MoveConfigData.playerAcceleration;
        float decceleration = MoveConfigData.playerDecceleration;
        Vector2 planarVelocity = new Vector2(playerPhysicsBody.linearVelocity.x, playerPhysicsBody.linearVelocity.y);
        bool isAtMaxSpeed = planarVelocity.sqrMagnitude >= maxSpeed * maxSpeed || direction.sqrMagnitude == 0;
        Vector2 directionDiference = (direction.normalized * maxSpeed) - planarVelocity;
        
        Vector2 forceToAdd = directionDiference.normalized *  (isAtMaxSpeed? - 1 * (decceleration * ((planarVelocity.sqrMagnitude - (maxSpeed * maxSpeed))/ maxSpeed)) :  acceleration); 
        ApplyForceToPlayer(new Vector3(forceToAdd.x, 0, forceToAdd.y));
    }

}
