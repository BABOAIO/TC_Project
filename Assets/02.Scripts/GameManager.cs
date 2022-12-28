using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int stackScore;
    public bool isGameOver;
    public GameObject gameOverText;

    public Text scoreText;
    public int nextStage = 0;


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
        //if(nextStage <= stackScore)
        //{
        //    SceneManager.LoadScene(1);
        //}
    }
}
