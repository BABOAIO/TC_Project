using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static AshTraySpawner;

public class AshTraySpawner : MonoBehaviour
{
    public enum SuitManState { idle, attack, die };
    public SuitManState suitmanState = SuitManState.idle;

    public GameObject AshPrefab;        // 재떨이 프리팹
    public Transform AshLocation;       // 재떨이가 발사될 위치
    // public float spawnRate = 1.0f;
     public float AshTime = 1.0f;        // 재떨이 발사 시간
    private Transform target;          // 플레이어를 향해
    // private float spawnTime = 0;
    // private float timeAfterSpawn;
    private Animator animator;
    private int hp = 100;
    int loopNum = 0;
    private bool isDie = false;         // 슈트맨의 사망 여부
    private bool StandUp = false;
    private float currentTime = 0;
    public float DelayTime = 5;
    public float spawnHeight = 2.3f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
        Invoke("SuitStandUp", 5.0f);

        //animator.SetBool("StandUp", false);
        //StartCoroutine(this.CheckSuitManState());
        
        //StartCoroutine(Ash());
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn= Time.deltaTime;
        //if(StandUp)
        //{
        
        if(GameManager.Instance.stage == GameManager.StageState.level1) { 
          currentTime += 1;
        // StartCoroutine(this.SuitManAction());

        //print(suitmanState);
        if(spawnHeight <= AshLocation.transform.position.y)
        {
            if (currentTime > DelayTime)
            {
                GameObject AshTray = Instantiate(AshPrefab, AshLocation.position, AshLocation.rotation);
                AshTray.transform.LookAt(target);
                currentTime = 0;
            }
           
        }
        }

    }

    public void SuitStandUp()
    {
        suitmanState = SuitManState.attack;
        animator.SetBool("StandUp", true);
        StandUp = true;
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
        animator.SetTrigger("IsDie");



        // 점수 10000
        FindObjectOfType<GameManager>().AddScore(10000);

    }
}
