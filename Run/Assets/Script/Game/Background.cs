using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 2f;        // 배경이 움직이는 속도
    public float resetPosition = -20f;    // 배경이 화면에서 벗어나면 리셋되는 위치
    public float startPosition = 20f;     // 배경이 다시 시작되는 위치

    private Vector3 startPos;

    void Start()
    {
        // 배경의 초기 위치를 저장
        startPos = transform.position;
    }

    void Update()
    {
        // 배경을 왼쪽으로 움직임
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 배경이 특정 위치를 벗어나면 다시 처음 위치로 이동
        if (transform.position.x <= resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}