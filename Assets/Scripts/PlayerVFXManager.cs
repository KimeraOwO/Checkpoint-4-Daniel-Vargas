using UnityEngine;

public class PlayerVFXManager : MonoBehaviour
{
    [Header("Referencias Visuales")]
    public Renderer playerRenderer;

    private Material originalMaterial;
    private GameObject currentVFXInstance;

    void Start()
    {
        if (playerRenderer != null)
        {
            originalMaterial = playerRenderer.material;
        }
    }

    public void ShowVFX(Material shaderMaterial, GameObject vfxPrefab)
    {
        if (playerRenderer != null && shaderMaterial != null)
        {
            playerRenderer.material = shaderMaterial;
        }

        if (vfxPrefab != null)
        {
            currentVFXInstance = Instantiate(vfxPrefab, transform.position, transform.rotation, transform);

            currentVFXInstance.SetActive(true);
        }
    }

    public void HideVFX()
    {
        if (playerRenderer != null)
        {
            playerRenderer.material = originalMaterial;
        }

        if (currentVFXInstance != null)
        {
            Destroy(currentVFXInstance);
        }
    }
}