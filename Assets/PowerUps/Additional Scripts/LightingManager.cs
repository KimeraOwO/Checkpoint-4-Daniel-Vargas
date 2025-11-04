using UnityEngine;
using UnityEngine.Rendering;

public class LightingManager : MonoBehaviour
{
    public static LightingManager Instance;

    [Header("Referencias")]
    public Volume globalVolume;

    [Header("Perfiles de Post-Processing")]
    public VolumeProfile normalProfile;
    public VolumeProfile nightVisionProfile;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableNightVision()
    {
        if (globalVolume != null && nightVisionProfile != null)
        {
            globalVolume.profile = nightVisionProfile;
        }
    }

    public void DisableNightVision()
    {
        if (globalVolume != null && normalProfile != null)
        {
            globalVolume.profile = normalProfile;
        }
    }
}