using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float hp = 100.0f;        //플레이어의 체력 변수
    public float maxHp = 100.0f;     //플레이어의 최대 체력 변수
    
    public Slider hpSlider;     // hp 슬라이더 변수

    
    public GameObject hitEffect; // 피격 이미지
    // Start is called before the first frame update
    public void GetDamage(float amount)
    {
        hp -= amount;
        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
        else if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ASHTRAY")
        {
            GetDamage(1.0f);
        }
    }
    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);              // 피격 이미지를 활성화
        yield return new WaitForSeconds(0.3f);  // 0.3초 대기
        hitEffect.SetActive(false);             // 비활성화
        // GameObject의 활성화, 비활성화는 SetActive()
        // Component의 활성화, 비활성화는 enabled = true or false;
    }
    private void Update()
    {
        hpSlider.value = (float)hp / (float)maxHp; // 현재 플레이어의 hp(%)를 hp 슬라이더의 value에 반영한다
    }
}
