using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed; //Movement Velocity
    public InputAction Movement; //Input Action that stores the input given in the inspector
    private void Awake()
    {
        Movement.Enable(); //Enables the Inputs
    }
    private void Update()
    {
        Vector3 move = Movement.ReadValue<Vector3>(); //sets the movement Input to a Vector3 Value

        //calculate the movement velocity based on the position and the speed of the Player and, olso, the Inputs 
        Vector3 position = (Vector3)transform.position + Time.deltaTime * speed * move; 
        transform.position = position; //sets the position
    }
}
