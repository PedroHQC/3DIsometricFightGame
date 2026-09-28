using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementStateMachine : BaseStateMachine
{
    [SerializeField] private PlayerMovementConfigScriptable MoveConfigData;
    public PlayerInputManager inputManager;
    public Rigidbody playerPhysicsBody;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
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

        float sqrMaxSpeed = maxSpeed * maxSpeed;

        Vector2 planarVelocity = new Vector2(playerPhysicsBody.linearVelocity.x, playerPhysicsBody.linearVelocity.z);
        bool isAtMaxSpeed = planarVelocity.sqrMagnitude > sqrMaxSpeed;
        bool needsDeccelerate =  isAtMaxSpeed || direction.sqrMagnitude == 0;

        if(needsDeccelerate)
        {
            direction = (planarVelocity * -1).normalized * (decceleration * (isAtMaxSpeed? 
            ((planarVelocity.sqrMagnitude - sqrMaxSpeed) / sqrMaxSpeed)
            : Mathf.Max(planarVelocity.sqrMagnitude / sqrMaxSpeed, 0.25f)));
        }
        else
        {
            direction = Quaternion.Euler(1,1,1) * Vector3.one;
            direction *= acceleration;
        }

        Vector3 forceToAdd = new(direction.x, 0 ,direction.y);

        ApplyForceToPlayer(forceToAdd);
    }

}