using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshTraySpawner : MonoBehaviour
{
    public enum SuitManState { idle, attack, die };
    public SuitManState suitmanState = SuitManState.idle;

    public GameObject AshPrefab;        // 재떨이 프리팹
    public Transform AshLocation;       // 재떨이가 발사될 위치
    // public float spawnRate = 1.0f;
    public float AshTime = 1.0f;               // 재떨이 발사 시간
    private Transform target;           // 플레이어를 향해
    private float spawnTime = 0;
    private float timeAfterSpawn;
    private Animator animator;
    private int hp = 100;

    private bool isDie = false;         // 슈트맨의 사망 여부

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
        //StartCoroutine(Ash());
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn= Time.deltaTime;
        //if(timeAfterSpawn >= spawnTime)
        //{
        //    timeAfterSpawn = 0f;

        //    GameObject Ash = Instantiate(AshPrefab, AshLocation.position, AshLocation.rotation);

        //    Ash.transform.LookAt(target);


        //}
        StartCoroutine(this.SuitManAction());
    }
    IEnumerator SuitManAction()
    {
        while (!isDie)
        {
            switch (suitmanState)
            {
                case SuitManState.idle:
                    animator.SetBool("StandUp", false);
                    break;

                case SuitManState.attack:
                    animator.SetBool("StandUp", true);
                    break;

            }
        }

        yield return null;
    }
    IEnumerator Ash()
    {
        Instantiate(AshPrefab, AshLocation.position, AshLocation.rotation);
        yield return new WaitForSeconds(AshTime);
    }


    public void GetDamage(float amount)
    {
        if (isDie == true) return;

        hp -= (int)(amount); 
        animator.SetTrigger("IsHit");

        if (hp <= 0)
            SuitManDie();
    }

    void SuitManDie()
    {
        if (isDie == true) return;

        //모든 코루틴을 정지
        StopAllCoroutines();
        isDie = true;
        suitmanState = SuitManState.die;
        animator.SetBool("StandUp", false);
        animator.SetTrigger("IsDie");

        // 외계인은 2점!
        FindObjectOfType<GameManager>().AddScore(10000);

    }
}
