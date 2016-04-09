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

    public float countdownLength = 2F;
    public Text countdownText;

    private bool counting;
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

        StartCountdown();
        cpu.GetComponent<AI>().Reset();
        player.GetComponent<MovePaddle>().Reset();
    }

    void Update()
    {
        if (counting)
        {
            timer -= Time.deltaTime;
            countdownText.text = timer.ToString() + 1;
            if (timer <= 0)
            {
                counting = false;
                countdownText.text = "";
                NewBall();
            }
        }
    }

}
