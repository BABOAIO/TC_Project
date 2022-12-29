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
     
    }

    // Update is called once per frame
    void Update()
    {
        if(stackScore >= nextStage)
        {
            SceneManager.LoadScene(1);
        }
    }

}
