using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.0f; // ��������Ʈ�� ���ŵ� �ð�
    float currentTime = 0; // ��� �ð� ������ ����

    // Update is called once per frame
    void Update()
    {
        // ��� �ð��� ���ŵ� �ð��� �ʰ��ϸ��ڱ� �ڽ��� �����Ѵ�
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime; // ��� �ð� ����
    }
}
