using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector2> onClick;
    [SerializeField]
    private UnityEvent<Vector2> onDrag;

    [SerializeField]
    private float dragThreshold = 0.12f;

    private Vector2 lastPointerPosition;
    private Vector2 dragStartPosition;
    private bool isPointerDown;
    private bool isDragging;

    public void Click(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            dragStartPosition = lastPointerPosition;
            isPointerDown = true;
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            if (!isDragging)
            {
                onClick?.Invoke(lastPointerPosition);
            }

            isPointerDown = false;
            isDragging = false;
        }
    }

    public void Point(InputAction.CallbackContext context)
    {
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        if (isPointerDown)
        {
            if (!isDragging)
            {
                if (Vector2.Distance(dragStartPosition, pointerPosition) > dragThreshold)
                {
                    isDragging = true;
                }
            }

            if (isDragging)
            {
                Vector2 dragDirection = pointerPosition - lastPointerPosition;
                onDrag?.Invoke(dragDirection);
            }
        }

        lastPointerPosition = pointerPosition;
    }
}
