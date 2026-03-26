using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 inputVector;
    [SerializeField] private float speed = 2f;
    private int speedModifier = 1;
    
    [SerializeField] private GameObject torch;
    
    // TODO: Place hash variables here
    
    // TODO: Add Animator
    
    // TODO: Add bool for equipping the torch
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        // TODO: Get Animator component
        
        // TODO: set the Hash variables with StringToHash on animator
    }
    
    void Update()
    {
        Vector3 movement = transform.forward * inputVector.y + transform.right * inputVector.x;
        characterController.Move(speed * speedModifier * movement * Time.deltaTime);
        characterController.Move(Physics.gravity * Time.deltaTime);
        
        // TODO: Update animator parameters
        
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>().normalized;
    }
    
    void OnSprint(InputValue value)
    {
        speedModifier = value.isPressed ? 2 : 1;
    }

    void OnAttack(InputValue value)
    {
        // TODO
    }
    public void ToggleTorch()
    {
       // TODO
    }
}
