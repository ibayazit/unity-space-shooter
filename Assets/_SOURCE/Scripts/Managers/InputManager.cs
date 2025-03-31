using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private GameInput gameInput;

    public Vector2 GamePlayMoveInput { get; private set; } = Vector2.zero;

    private void OnEnable()
    {
        gameInput ??= new GameInput();

        if (GameManager.Instance.isGamePaused)
        {
            EnableUIInput();
        }
        else
        {
            EnableGameplayInput();
        }

        // Gameplay
        gameInput.Gameplay.Move.performed += OnGameplayMove;
        gameInput.Gameplay.Move.canceled += OnGameplayMove;
        gameInput.Gameplay.Pause.started += OnGameplayPause;

        // UI
        gameInput.UI.Resume.started += OnUIResume;
    }

    private void OnDisable()
    {
        // Gameplay
        gameInput.Gameplay.Move.performed -= OnGameplayMove;
        gameInput.Gameplay.Move.canceled -= OnGameplayMove;
        gameInput.Gameplay.Pause.started -= OnGameplayPause;

        // UI
        gameInput.UI.Resume.started -= OnUIResume;

        DisableAllInput();
    }

    private void EnableGameplayInput()
    {
        gameInput.Gameplay.Enable();
        gameInput.UI.Disable();
    }

    private void EnableUIInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.UI.Enable();
    }

    private void DisableAllInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.UI.Disable();
    }

    private void OnGameplayMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        GamePlayMoveInput = context.ReadValue<Vector2>();
    }

    private void OnGameplayPause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        EnableUIInput();
        GameManager.Instance.GamePaused(true);
    }

    private void OnUIResume(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        EnableGameplayInput();
        GameManager.Instance.GamePaused(false);
    }
}
