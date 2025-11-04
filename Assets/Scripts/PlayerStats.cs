using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats Base")]
    public float baseMoveSpeed = 6.0f;
    public float baseJumpForce = 8.0f;
    public float baseGravity = -20.0f;
    public float baseRotationSpeed = 10.0f;
    [Range(0, 1)] public float baseDamageReduction = 0f;
    [HideInInspector] public int baseLayer;

    [Header("Stats Actuales (Solo Lectura)")]
    public float currentMoveSpeed;
    public float currentJumpForce;
    public float currentGravity;
    public float currentRotationSpeed;
    public float currentDamageReduction;

    void Awake()
    {
        baseLayer = gameObject.layer;

        ResetStats();
    }

    public void ResetStats()
    {
        currentMoveSpeed = baseMoveSpeed;
        currentJumpForce = baseJumpForce;
        currentGravity = baseGravity;
        currentRotationSpeed = baseRotationSpeed;
        currentDamageReduction = baseDamageReduction;
    }

    public void ApplySpeedMultiplier(float multiplier)
    {
        currentMoveSpeed = baseMoveSpeed * multiplier;
    }

    public void ApplyJumpMultiplier(float multiplier)
    {
        currentJumpForce = baseJumpForce * multiplier;
    }

    public void SetDamageReduction(float reductionPercent)
    {
        currentDamageReduction = Mathf.Clamp01(reductionPercent);
    }
}