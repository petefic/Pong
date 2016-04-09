using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject ball;
    public Text playerScoreText;
    public Text cpuScoreText;

    private int playerScore;
    private int cpuScore;

    void Start()
    {
        NewBall();
    }

    public void NewBall()
    {
        //create ball
        Instantiate(ball, new Vector3(0, 0.5F, 0), Quaternion.identity);
        Ball ballObj = ball.GetComponent<Ball>();
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

        NewBall();
    }

}
