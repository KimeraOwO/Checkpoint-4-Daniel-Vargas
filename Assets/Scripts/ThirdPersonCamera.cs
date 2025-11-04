using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public enum CameraMode { ThirdPerson, FirstPerson }
    public CameraMode currentMode = CameraMode.ThirdPerson;

    [Header("Referencias")]
    public Transform target;
    public Transform firstPersonTarget; 

    [Header("Configuración General")]
    public float mouseSensitivity = 2.0f;
    public LayerMask collisionMask;

    [Header("Configuración 3ra Persona")]
    public float distance = 4.0f;
    public float pitchMin = -30.0f;
    public float pitchMax = 70.0f;
    public float collisionOffset = 0.2f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float currentDistance;
    private Quaternion rotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentDistance = distance;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        switch (currentMode)
        {
            case CameraMode.ThirdPerson:
                HandleThirdPerson();
                break;
            case CameraMode.FirstPerson:
                HandleFirstPerson();
                break;
        }
    }

    void HandleThirdPerson()
    {
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance);
        RaycastHit hit;
        if (Physics.Raycast(target.position, (desiredPosition - target.position).normalized, out hit, distance, collisionMask))
        {
            currentDistance = hit.distance - collisionOffset;
        }
        else
        {
            currentDistance = Mathf.Lerp(currentDistance, distance, Time.deltaTime * 5f);
        }
        currentDistance = Mathf.Clamp(currentDistance, 0.1f, distance);

        transform.position = target.position - (rotation * Vector3.forward * currentDistance);
        transform.LookAt(target.position);

        target.rotation = Quaternion.Euler(0, yaw, 0);
    }

    void HandleFirstPerson()
    {
        pitch = Mathf.Clamp(pitch, -89f, 89f);
        rotation = Quaternion.Euler(pitch, yaw, 0);

        if (firstPersonTarget != null)
        {
            transform.position = firstPersonTarget.position;
        }
        else
        {
            transform.position = target.position;
        }

        transform.rotation = rotation;

        target.rotation = Quaternion.Euler(0, yaw, 0);
    }

    public void SetCameraMode(CameraMode newMode)
    {
        currentMode = newMode;
    }
}