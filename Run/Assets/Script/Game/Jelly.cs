using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int scoreValue = 10; // ������ ���� �� ȹ���ϴ� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� ����
            ScoreManager.Instance.AddScore(scoreValue);

            // ���� ����
            Destroy(gameObject);
        }
    }
}
