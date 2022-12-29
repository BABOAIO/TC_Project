using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public int stackScore;

    public Text scoreText;

    [SerializeField]
    [Header("다음 씬으로 넘어가는 점수")]
    private int nextStage = 0;
    private bool isGameOver = false;
    public AudioClip audioClip;
    public GameObject gameOverText;
    public Vector3 TutorialPos;
    public Vector3 Level01Pos;
    public Transform CameraPos;


    // Fade Out 변수
    public Image image; // 검은색 화면

 

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        stackScore = 0;
    }

    public void AddScore(int pt)
    {
        stackScore += pt;

        scoreText.text = "SCORE : " + stackScore;

        Debug.Log( $"누적점수 : {stackScore}");
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
    void Start()
    {
        //CameraPos.position = TutorialPos;

    }

    // Update is called once per frame
    void Update()
    {
        // 튜토리얼에서 특정 점수 도달시
        // 레빌1로 위치이동
        #region ㄹㅇㄹㅇㄹ
        //if(stackScore >= nextStage)
        //{
        //    CameraPos.position = Level01Pos;
        //    FadeOut();
        //}
        #endregion 
    }

    public void FadeOut()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0;        // 시작 알파값
        while (fadeCount < 1.0f)    // 알파 최대값 1.0까지 반복 
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);     // 0.01초마다 반복
            image.color = new Color(0, 0, 0, fadeCount);// 해당 변수값으로 알파값 지정
        }
    }
}
