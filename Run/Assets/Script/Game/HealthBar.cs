using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f; // 최대 체력
    private float currentHealth;

    public Slider healthSlider;
    private bool isInvincible = false;
    public float invincibilityDuration = 1.0f;

    // 슬라이더의 최소값 설정
    public float minSliderValue = 0.1f; // 슬라이더에서 끝부분이 남아야 하는 최소 값

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // HP를 감소시키는 메서드
    public void TakeDamage(float damage)
    {
        if (isInvincible) return; // 무적 상태일 때는 피해를 받지 않음

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력이 0 이하로 떨어지지 않도록 설정

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // 플레이어 사망 처리 (게임 오버 등)
            Debug.Log("Player is dead.");
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // 체력 UI 업데이트
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            // 체력의 비율 계산 (0~1 범위로 변환)
            float healthRatio = currentHealth / maxHealth;

            // 슬라이더의 값 설정 (최소값과 최대값을 유지)
            healthSlider.value = Mathf.Max(healthRatio, minSliderValue);
        }
    }

    // 무적 상태 처리
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}