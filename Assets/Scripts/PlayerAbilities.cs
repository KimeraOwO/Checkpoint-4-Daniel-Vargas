using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerAbilities : MonoBehaviour
{
    private PlayerController controller;
    private PlayerStats stats;

    [Header("Dash")]
    public int baseDashCharges = 1;
    public float dashCooldown = 4.0f;
    public float dashSpeed = 25.0f;
    public float dashDuration = 0.15f;

    private int currentMaxCharges;
    private int chargesRemaining;
    private float cooldownTimer;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        stats = GetComponent<PlayerStats>();
        currentMaxCharges = baseDashCharges;
        chargesRemaining = currentMaxCharges;
        cooldownTimer = 0;
    }

    void Update()
    {
        if (chargesRemaining < currentMaxCharges)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                chargesRemaining++;
                cooldownTimer = dashCooldown;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && chargesRemaining > 0 && !controller.isDashing)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        chargesRemaining--;
        controller.isDashing = true;

        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 dashDirection = transform.forward;

        if (inputDir.magnitude > 0.1f)
        {
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            dashDirection = (camForward * inputDir.y + camRight * inputDir.x).normalized;
        }

        float timer = 0;
        float originalGravity = stats.currentGravity;
        stats.currentGravity = 0;

        while (timer < dashDuration)
        {
            controller.PerformDash(dashDirection, dashSpeed);
            timer += Time.deltaTime;
            yield return null;
        }

        stats.currentGravity = originalGravity;
        controller.isDashing = false;

        if (chargesRemaining == currentMaxCharges - 1)
        {
            cooldownTimer = dashCooldown;
        }
    }

    public void SetMaxCharges(int newMax)
    {
        currentMaxCharges = newMax;
        chargesRemaining = newMax;
        cooldownTimer = 0;
    }

    public void ResetMaxCharges()
    {
        currentMaxCharges = baseDashCharges;
        chargesRemaining = Mathf.Min(chargesRemaining, baseDashCharges);
    }
}