using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace RhythmGame.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputActions.IGameplayActions
    {
        // Gameplay
        public event UnityAction<Vector2> leftCollectorMoveEvent;
        public event UnityAction<Vector2> rightCollectorMoveEvent;
        public event UnityAction leftCapture1Event;
        public event UnityAction leftCapture2Event;
        public event UnityAction rightCapture1Event;
        public event UnityAction rightCapture2Event;

        private InputActions inputActions;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
                inputActions.Gameplay.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        // Gameplay

        public void OnLeftCollector(InputAction.CallbackContext context)
        {
        	if (leftCollectorMoveEvent != null)
        	{
        		leftCollectorMoveEvent?.Invoke(context.ReadValue<Vector2>());
        	}
        }

        public void OnRightCollector(InputAction.CallbackContext context)
        {
        	if (rightCollectorMoveEvent != null)
        	{
        		rightCollectorMoveEvent?.Invoke(context.ReadValue<Vector2>());
        	}
        }

        public void OnLeftCapture1(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                leftCapture1Event?.Invoke();
        }

        public void OnLeftCapture2(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                leftCapture2Event?.Invoke();
        }

        public void OnRightCapture1(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                rightCapture1Event?.Invoke();
        }

        public void OnRightCapture2(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                rightCapture2Event?.Invoke();
        }

        // Enable/Disable

        public void EnableGameplayInput()
        {
            inputActions.Gameplay.Enable();
        }

        public void DisableAllInput()
        {
            inputActions.Gameplay.Disable();
        }
    }
}
