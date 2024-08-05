using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;      // ���� ��
    public int maxJumps = 2;           // �ִ� ���� Ƚ��
    public float slideDuration = 1f;   // �����̵� ���� �ð�

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private bool isSliding;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        isSliding = false;
    }

    void Update()
    {
        // ���� �Է�: �����̽���
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }

        // �����̵� �Է�: ���� Shift Ű
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڰ� �浹 ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        // �����̵� ���¿� ���� �ִϸ��̼� �Ǵ� ���� ���� ����
        // ��: ĳ���� ũ�� ���� ��

        yield return new WaitForSeconds(slideDuration);
        isSliding = false;
        // �����̵� ���� �� ���� ���·� ����
    }
}