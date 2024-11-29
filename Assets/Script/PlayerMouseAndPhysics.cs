using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMouseAndPhysics : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1.0f; // Controls how fast the player moves
    [SerializeField] private float RotationSpeed = 1.0f; // Controls how fast the player rotates

    [SerializeField] private Transform PlayerHead; // Reference to the player's "head" for looking around

    private Rigidbody physicsBody;
    private float horizontalFacing = 0f; // Horizontal rotation for left and right movement
    private float verticalFacing = 0f; // Vertical rotation for looking up and down
    private float desiredHeight;

    void Start()
    {
        // Adjust the player's camera height
        PlayerHead.localPosition = new Vector3(PlayerHead.localPosition.x, -0.8f, PlayerHead.localPosition.z);

        // Initialize the Rigidbody and lock the cursor to the screen
        physicsBody = GetComponent<Rigidbody>();
        

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;


        // Stop the Rigidbody from rotating due to physics
        physicsBody.freezeRotation = true;
    }

    void Update()
    {
        // Allow the player to look around with the mouse
        MoveCameraWithMouse();
    }

    private void FixedUpdate()
    {
        // Move the player smoothly with physics (fixed time steps)
        MoveWithPhysics();
    }

    private void MoveCameraWithMouse()
    {
        // Get the mouse movement for horizontal and vertical rotation
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;

        // Adjust the vertical rotation (up/down) and limit it to prevent over-rotation
        verticalFacing -= mouseY;
        verticalFacing = Mathf.Clamp(verticalFacing, -90f, 90f);

        // Adjust the horizontal rotation (left/right)
        horizontalFacing += mouseX;

        // Apply the vertical rotation to the player's head
        PlayerHead.localRotation = Quaternion.Euler(verticalFacing, 0f, 0f);

        // Apply the horizontal rotation to the whole player body
        physicsBody.rotation = Quaternion.Euler(0f, horizontalFacing, 0f);
    }

    private void MoveWithPhysics()
    {
        // Get the WASD input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Determine the movement direction based on the player's current orientation
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Move the player based on input direction and speed
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime, Space.World);
    }
}
