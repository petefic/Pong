using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject ball;
    public GameObject player;
    public GameObject cpu;

    public Text playerScoreText;
    public Text cpuScoreText;

    public int countdownLength = 2;
    public Text countdownText;
    public bool counting = false;

    private float timer;

    private int playerScore;
    private int cpuScore;

    void Start()
    {
        StartCountdown();
    }

    private void StartCountdown()
    {
        timer = countdownLength;
        counting = true;
    }

    private void NewBall()
    {
        //create ball
        Instantiate(ball, new Vector3(0, 0.5F, 0), Quaternion.identity);
    }

    public void Goal(string scoredOn)
    {
        if (scoredOn == "Player")
        {
            cpuScore++;
            cpuScoreText.text = cpuScore.ToString();
        }
        else
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Destroy(ball);

        if (!CheckForWin())
        {
            StartCountdown();
            cpu.GetComponent<AI>().Reset();
            player.GetComponent<MovePaddle>().Reset();
        }
    }

    void Update()
    {
        if (counting)
        {
            timer -= Time.deltaTime;
            countdownText.text = Mathf.Round(timer + 1).ToString();
            if (timer <= 0)
            {
                counting = false;
                countdownText.text = "";
                NewBall();
            }
        }
    }

    private bool CheckForWin()
    {
        if (playerScore == 5)
        {
            countdownText.text = "You Win!";
            return true;
        }
        else if (cpuScore == 5)
        {
            countdownText.text = "You Lose";
            return true;
        }
        else
        {
            return false;
        }
    }

}
