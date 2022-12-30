using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.0f; // 폭발이펙트가 제거될 시간
    float currentTime = 0; // 경과 시간 측정용 변수

    // Update is called once per frame
    void Update()
    {
        // 경과 시간이 제거될 시간을 초과하면자기 자신을 제거한다
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime; // 경과 시간 누적
    }
}
