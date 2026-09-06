using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public GameObjectClickEvent mouseClicked;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

   public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;
        Debug.Log(rayHit.collider.gameObject.name);
        mouseClicked.Invoke(rayHit.collider.gameObject);
    }
}

[System.Serializable]
public class GameObjectClickEvent : UnityEvent<GameObject> { }
