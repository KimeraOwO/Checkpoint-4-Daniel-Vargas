using System.Collections;
using UnityEngine;

public class PlayerPowerUpManager : MonoBehaviour
{
    private PlayerVFXManager vfxManager;

    private PowerUpEffect currentPowerUp;
    private Coroutine powerUpCoroutine;

    void Start()
    {
        vfxManager = GetComponent<PlayerVFXManager>();
        if (vfxManager == null)
        {
            Debug.LogError("PlayerVFXManager no encontrado en el Player!");
        }
    }

    public void ApplyPowerUp(PowerUpEffect powerUpToApply)
    {
        if (currentPowerUp != null)
        {
            RemoveCurrentPowerUp();
        }

        currentPowerUp = powerUpToApply;

        currentPowerUp.Activate(gameObject);

        vfxManager.ShowVFX(currentPowerUp.powerUpShader, currentPowerUp.vfxParticlesPrefab);

        powerUpCoroutine = StartCoroutine(PowerUpTimer(currentPowerUp));
    }

    private IEnumerator PowerUpTimer(PowerUpEffect powerUp)
    {
        float timer = powerUp.duration;
        while (timer > 0)
        {
            powerUp.OnUpdate(gameObject);
            timer -= Time.deltaTime;
            yield return null;
        }

        RemoveCurrentPowerUp();
    }

    private void RemoveCurrentPowerUp()
    {
        if (currentPowerUp == null) return;

        currentPowerUp.Deactivate(gameObject);

        vfxManager.HideVFX();

        if (powerUpCoroutine != null)
        {
            StopCoroutine(powerUpCoroutine);
        }
        currentPowerUp = null;
    }
}