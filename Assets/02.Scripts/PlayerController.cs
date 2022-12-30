using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float hp = 100.0f;        //�÷��̾��� ü�� ����
    public float maxHp = 100.0f;     //�÷��̾��� �ִ� ü�� ����
    
    public Slider hpSlider;     // hp �����̴� ����

    
    public GameObject hitEffect; // �ǰ� �̹���
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
        hitEffect.SetActive(true);              // �ǰ� �̹����� Ȱ��ȭ
        yield return new WaitForSeconds(0.3f);  // 0.3�� ���
        hitEffect.SetActive(false);             // ��Ȱ��ȭ
        // GameObject�� Ȱ��ȭ, ��Ȱ��ȭ�� SetActive()
        // Component�� Ȱ��ȭ, ��Ȱ��ȭ�� enabled = true or false;
    }
    private void Update()
    {
        hpSlider.value = (float)hp / (float)maxHp; // ���� �÷��̾��� hp(%)�� hp �����̴��� value�� �ݿ��Ѵ�
    }
}
