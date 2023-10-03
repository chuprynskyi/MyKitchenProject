using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isWalking;
    private float moveSpeed = 7f;
    private Vector3 lastInteractionDir;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float interactionDistance = 2f;

        if (moveDir != Vector3.zero)
        {
            lastInteractionDir = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractionDir, out RaycastHit raycastHit, interactionDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // Has ClearCounter
                clearCounter.Interact();
            }
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float interactionDistance = 2f;

        if (moveDir != Vector3.zero)
        {
            lastInteractionDir = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractionDir, out RaycastHit raycastHit, interactionDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // Has ClearCounter
                // clearCounter.Interact();
            }
        }
    }

    public void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistanse = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistanse);

        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt to move only in the X direction
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistanse);

            if (canMove)
            {
                // Can move only in X direction
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only in X direction

                // Attempt to move only in the Z direction
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistanse);

                if (canMove)
                {
                    // Can move only in Z direction
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move only in Z direction
                }
            }

        }

        if (canMove)
        {
            transform.position += moveDir * moveDistanse;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 15f;

        transform.forward += Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }
}
