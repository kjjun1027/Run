using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private HealthBar healthBar;

    public float jumpForce = 5f;      // 점프 힘
    public int maxJumps = 2;           // 최대 점프 횟수
    public float slideDuration = 1f;   // 슬라이드 지속 시간

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private bool isSliding;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        isSliding = false;
    }

    void Update()
    {
        // 점프 입력: 스페이스바
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }

        // 슬라이드 입력: 좌측 Shift 키
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
        // 바닥과 충돌 감지
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // 장애물과 충돌 시 데미지 처리
            healthBar.TakeDamage(20);
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        // 슬라이드 상태에 대한 애니메이션 또는 상태 변경 가능
        // 예: 캐릭터 크기 조정 등

        yield return new WaitForSeconds(slideDuration);
        isSliding = false;
        // 슬라이드 종료 후 원래 상태로 복원
    }
}