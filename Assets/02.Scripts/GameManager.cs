using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public int stackScore = 0;

    public Text scoreText;

    [SerializeField]
    [Header ("다음 씬으로 넘어갈 점수")]
    private int nextStage = 950;

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
