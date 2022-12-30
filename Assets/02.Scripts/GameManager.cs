using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 스테이지 단계
    public enum StageState { tutorial, level1, level2 };
    public StageState stage;


    private static GameManager instance = null;

    public int stackScore;

    public Text scoreText;

    [SerializeField]
    [Header("튜토리얼 -> 레벨1 로 넘어가는 점수")]
    private int nextStageLevel01 = 500;
    [SerializeField]
    [Header("레벨1 -> 레벨2 로 넘어가는 점수")]
    private int nextStageLevel02 = 3000;
    private bool isGameOver = false;
    public AudioClip audioClip;
    public GameObject gameOverText;
    public Vector3 TutorialPos;
    public Vector3 Level01Pos;
    public Transform CameraPos;


    // Fade Out 변수
    public Image image; // 검은색 화면

    // 밀림방지
    private Rigidbody Vector3zero;

    // 레벨 2 벽 이미지 변화
    float speed = 2f;
    float offset = 0.1f;
    Vector2 offVec = Vector2.zero;
    Renderer level2;
    Renderer level3;

    // 점수 도달시 Level 벽을 없애기 위한 오브젝트 변수
    public GameObject level02Wall;

    // 3은 아직 미구현
    // public GameObject level03Wall;
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

        // 밀림방지를 위하여 "리지드바디"태그를 가진 오브젝트의 리지드바디 컴포넌트를 할당
        Vector3zero = GameObject.FindWithTag("RigidBody").GetComponent<Rigidbody>();

        // 렌더러 컴포넌트 할당
        level2 = GameObject.FindWithTag("Level2").GetComponent<Renderer>();
        level3 = GameObject.FindWithTag("Level3").GetComponent<Renderer>();

        stage = StageState.tutorial;
    }

    // Update is called once per frame
    void Update()
    {
        // 물리적가속도 0으로 설정
        Vector3zero.velocity= Vector3.zero;

        // VECTOR2 변수에 값 할당
        offVec += new Vector2(offset * speed * Time.deltaTime, 0);
        // 태그네임 레벨2의 메테리얼컴포넌트의 오프셋 ++;

        level2.material.SetTextureOffset("_MainTex",offVec);
        level3.material.SetTextureOffset("_MainTex", offVec);
        // 튜토리얼에서 특정 점수 도달시
        // 레빌1로 위치이동
        #region ㄹㅇㄹㅇㄹ
        if (stackScore >= nextStageLevel01)
        {
            stage = StageState.level1;
            CameraPos.position = Level01Pos;
            FadeOut();
        }
        if (stackScore >= nextStageLevel02)
        {
            stage = StageState.level2;
            level02Wall.SetActive(false);
        }
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
