using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    //�浹�ߴٸ�
    private void OnCollisionEnter(Collision collision)
    {
        // ����Ʈ �������� �����Ѵ�
        GameObject eff = Instantiate(bombEffect);
        // ����Ʈ �����հ� ����ź ������Ʈ�� ��ġ�� ���� �Ѵ�.
        eff.transform.position = transform.position;

        //�ڱ� �ڽ��� ����
        Destroy(gameObject);
    }
}
