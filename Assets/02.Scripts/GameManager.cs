using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �������� �ܰ�
    public enum StageState { tutorial, level1, level2 };
    public StageState stage;


    private static GameManager instance = null;

    public int stackScore;

    public Text scoreText;

    [SerializeField]
    [Header("Ʃ�丮�� -> ����1 �� �Ѿ�� ����")]
    private int nextStageLevel01 = 500;
    [SerializeField]
    [Header("����1 -> ����2 �� �Ѿ�� ����")]
    private int nextStageLevel02 = 3000;
    private bool isGameOver = false;
    public AudioClip audioClip;
    public GameObject gameOverText;
    public Vector3 TutorialPos;
    public Vector3 Level01Pos;
    public Transform CameraPos;


    // Fade Out ����
    public Image image; // ������ ȭ��

    // �и�����
    private Rigidbody Vector3zero;

    // ���� 2 �� �̹��� ��ȭ
    float speed = 2f;
    float offset = 0.1f;
    Vector2 offVec = Vector2.zero;
    Renderer level2;
    Renderer level3;

    // ���� ���޽� Level ���� ���ֱ� ���� ������Ʈ ����
    public GameObject level02Wall;

    // 3�� ���� �̱���
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

        Debug.Log( $"�������� : {stackScore}");
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
    void Start()
    {
        //CameraPos.position = TutorialPos;

        // �и������� ���Ͽ� "������ٵ�"�±׸� ���� ������Ʈ�� ������ٵ� ������Ʈ�� �Ҵ�
        Vector3zero = GameObject.FindWithTag("RigidBody").GetComponent<Rigidbody>();

        // ������ ������Ʈ �Ҵ�
        level2 = GameObject.FindWithTag("Level2").GetComponent<Renderer>();
        level3 = GameObject.FindWithTag("Level3").GetComponent<Renderer>();

        stage = StageState.tutorial;
    }

    // Update is called once per frame
    void Update()
    {
        // ���������ӵ� 0���� ����
        Vector3zero.velocity= Vector3.zero;

        // VECTOR2 ������ �� �Ҵ�
        offVec += new Vector2(offset * speed * Time.deltaTime, 0);
        // �±׳��� ����2�� ���׸���������Ʈ�� ������ ++;

        level2.material.SetTextureOffset("_MainTex",offVec);
        level3.material.SetTextureOffset("_MainTex", offVec);
        // Ʃ�丮�󿡼� Ư�� ���� ���޽�
        // ����1�� ��ġ�̵�
        #region ����������
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
        float fadeCount = 0;        // ���� ���İ�
        while (fadeCount < 1.0f)    // ���� �ִ밪 1.0���� �ݺ� 
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);     // 0.01�ʸ��� �ݺ�
            image.color = new Color(0, 0, 0, fadeCount);// �ش� ���������� ���İ� ����
        }
    }
}
