using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] string moveActionStringRef = "Move";
    [SerializeField] string fireActionStringRef = "Fire";
    [SerializeField] float moveSpeed = 100.0f;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float bottomBoundPadding;
    [SerializeField] float topBoundPadding;

    Shooter playerShooter;
    
    InputAction moveAction;
    InputAction fireAction;

    Vector3 moveVector;
    Vector2 minBound;
    Vector2 maxBound;

    void Start()
    {
        playerShooter = gameObject.GetComponent<Shooter>();

        moveAction = InputSystem.actions.FindAction(moveActionStringRef);
        fireAction = InputSystem.actions.FindAction(fireActionStringRef);

        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        PlayerMove();
        FireShooter();
    }

    void PlayerMove()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBound.x + leftBoundPadding, maxBound.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y + bottomBoundPadding, maxBound.y - topBoundPadding);
        
        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}
