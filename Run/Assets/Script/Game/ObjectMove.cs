using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float scrollSpeed = 5f;        // ������Ʈ�� �����̴� �ӵ�
    public float removePosition = -20f;   // ������Ʈ�� ȭ���� ����� ���ŵǴ� ��ġ

    void Update()
    {
        // ������Ʈ�� �������� ������
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // ������Ʈ�� Ư�� ��ġ�� ����� ��Ȱ��ȭ Ȥ�� ����
        if (transform.position.x <= removePosition)
        {
            Destroy(gameObject); // ������Ʈ ����
            // �Ǵ� gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        }
    }
}
