using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public CameraBob cameraBob;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    

    private Vector3 velocity;
    private bool isGrounded;
    private bool canDoubleJump = false;

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            canDoubleJump = true;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        } 
        else if (canDoubleJump == true && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canDoubleJump = false;
        }

        bool isMoving = controller.velocity.magnitude > 0.1f && isGrounded;
        cameraBob.DoBob(isMoving);


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
