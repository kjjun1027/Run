using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float scrollSpeed = 5f;        // 오브젝트가 움직이는 속도
    public float removePosition = -20f;   // 오브젝트가 화면을 벗어나면 제거되는 위치

    void Update()
    {
        // 오브젝트를 왼쪽으로 움직임
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 오브젝트가 특정 위치를 벗어나면 비활성화 혹은 제거
        if (transform.position.x <= removePosition)
        {
            Destroy(gameObject); // 오브젝트 제거
            // 또는 gameObject.SetActive(false); // 오브젝트 비활성화
        }
    }
}
