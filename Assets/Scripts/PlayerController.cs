using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerStats stats;
    private PlayerAbilities abilities;
    private Transform camTransform;

    private Vector3 velocity;
    private Vector2 inputDir;

    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isDashing = false; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();
        abilities = GetComponent<PlayerAbilities>();
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += stats.currentGravity * Time.deltaTime;

        if (!isDashing)
        {
            inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 moveDirection = Vector3.zero;

            if (inputDir.magnitude >= 0.1f)
            {
                Vector3 camForward = camTransform.forward;
                Vector3 camRight = camTransform.right;
                camForward.y = 0;
                camRight.y = 0;
                camForward.Normalize();
                camRight.Normalize();

                moveDirection = (camForward * inputDir.y + camRight * inputDir.x).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, stats.currentRotationSpeed * Time.deltaTime);
            }

            controller.Move(moveDirection * stats.currentMoveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(stats.currentJumpForce * -2f * stats.currentGravity);
            }
        }

        controller.Move(velocity * Time.deltaTime);
    }

    public void PerformDash(Vector3 dashDirection, float dashSpeed)
    {
        controller.Move(dashDirection * dashSpeed * Time.deltaTime);
    }
}