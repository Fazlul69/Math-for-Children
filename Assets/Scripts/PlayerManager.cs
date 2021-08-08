using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoin;
    public Text score;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        score.text = "Score: " + numberOfCoin;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
