using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    //충돌했다면
    private void OnCollisionEnter(Collision collision)
    {
        // 이펙트 프리팹을 생성한다
        GameObject eff = Instantiate(bombEffect);
        // 이펙트 프리팹과 수류탄 오브젝트의 위치를 같게 한다.
        eff.transform.position = transform.position;

        //자기 자신을 제거
        Destroy(gameObject);
    }
}
