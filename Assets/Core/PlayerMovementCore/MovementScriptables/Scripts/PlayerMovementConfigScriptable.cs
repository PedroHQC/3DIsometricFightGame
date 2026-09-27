using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerMovementConfig", menuName = "PlayerMovement/MovementConfig", order = 0)]
public class PlayerMovementConfigScriptable : ScriptableObject
{
    public float playerMaxSpeed = 10;
    public float playerAcceleration = 1;
    public float playerDecceleration = 1;
}
