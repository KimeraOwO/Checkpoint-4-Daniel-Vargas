using UnityEngine;

[CreateAssetMenu(fileName = "FirstPersonUp", menuName = "PowerUp Effects/FirstPersonUp")]
public class FirstPersonUpEffect : PowerUpEffect
{
    private ThirdPersonCamera cameraScript;

    public override void Activate(GameObject player)
    {
        cameraScript = Camera.main.GetComponent<ThirdPersonCamera>();
        if (cameraScript != null)
        {
            cameraScript.SetCameraMode(ThirdPersonCamera.CameraMode.FirstPerson);
        }
    }

    public override void Deactivate(GameObject player)
    {
        if (cameraScript != null)
        {
            cameraScript.SetCameraMode(ThirdPersonCamera.CameraMode.ThirdPerson);
        }
    }
}