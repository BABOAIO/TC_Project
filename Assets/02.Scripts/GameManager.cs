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
    [Header("���� ������ �Ѿ�� ����")]
    private int nextStage = 0;
    private bool isGameOver = false;
    public AudioClip audioClip;
    public GameObject gameOverText;
    public Vector3 TutorialPos;
    public Vector3 Level01Pos;
    public Transform CameraPos;


    // Fade Out ����
    public Image image; // ������ ȭ��

 

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

    }

    // Update is called once per frame
    void Update()
    {
        // Ʃ�丮�󿡼� Ư�� ���� ���޽�
        // ����1�� ��ġ�̵�
        #region ����������
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
        float fadeCount = 0;        // ���� ���İ�
        while (fadeCount < 1.0f)    // ���� �ִ밪 1.0���� �ݺ� 
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);     // 0.01�ʸ��� �ݺ�
            image.color = new Color(0, 0, 0, fadeCount);// �ش� ���������� ���İ� ����
        }
    }
}
