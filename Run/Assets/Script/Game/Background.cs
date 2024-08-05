using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 2f;        // ����� �����̴� �ӵ�
    public float resetPosition = -20f;    // ����� ȭ�鿡�� ����� ���µǴ� ��ġ
    public float startPosition = 20f;     // ����� �ٽ� ���۵Ǵ� ��ġ

    private Vector3 startPos;

    void Start()
    {
        // ����� �ʱ� ��ġ�� ����
        startPos = transform.position;
    }

    void Update()
    {
        // ����� �������� ������
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // ����� Ư�� ��ġ�� ����� �ٽ� ó�� ��ġ�� �̵�
        if (transform.position.x <= resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}