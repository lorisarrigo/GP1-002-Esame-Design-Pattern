using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed; 
    public InputAction Movement;
    private void Awake()
    {
        Movement.Enable();
    }
    private void Update()
    {
        //Quaternion rotationInput = Movement.ReadValue<Quaternion>();
        Vector3 move = Movement.ReadValue<Vector3>();
        //float rotate = rotationInput * Time.fixedDeltaTime * speed;

        Vector3 position = (Vector3)transform.position + Time.deltaTime * speed * move;
        //Quaternion rotation = Quaternion.Euler(0, rotate, 0);

        transform.position = position;
        //transform.rotation = rotation; 
    }
}
