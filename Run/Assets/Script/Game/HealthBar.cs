using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f; // �ִ� ü��
    private float currentHealth;

    public Slider healthSlider;
    private bool isInvincible = false;
    public float invincibilityDuration = 1.0f;

    // �����̴��� �ּҰ� ����
    public float minSliderValue = 0.1f; // �����̴����� ���κ��� ���ƾ� �ϴ� �ּ� ��

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // HP�� ���ҽ�Ű�� �޼���
    public void TakeDamage(float damage)
    {
        if (isInvincible) return; // ���� ������ ���� ���ظ� ���� ����

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü���� 0 ���Ϸ� �������� �ʵ��� ����

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // �÷��̾� ��� ó�� (���� ���� ��)
            Debug.Log("Player is dead.");
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // ü�� UI ������Ʈ
    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            // ü���� ���� ��� (0~1 ������ ��ȯ)
            float healthRatio = currentHealth / maxHealth;

            // �����̴��� �� ���� (�ּҰ��� �ִ밪�� ����)
            healthSlider.value = Mathf.Max(healthRatio, minSliderValue);
        }
    }

    // ���� ���� ó��
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}