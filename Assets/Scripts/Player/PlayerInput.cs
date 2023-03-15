using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        var horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        var jumpButtonDown = Input.GetButtonDown(GlobalStringVars.JUMP);
        var attackButtonDown = Input.GetButtonDown(GlobalStringVars.FIRE1);
        playerMovement.Move(horizontalDirection, jumpButtonDown, attackButtonDown);
    }
}