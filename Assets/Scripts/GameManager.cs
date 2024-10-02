using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentScore;
    public int maxLives = 3;
    public int LivesRemaining = 3;

    public TextMeshProUGUI scoreDisplayed;
    public TextMeshProUGUI livesDisplayed;
    public TextMeshProUGUI gameTextDisplayed;

    public float puddleStrength = 0f;

    bool hasLostBall = false;
    bool isGameOver = false;
    //define variables

    public Vector3 ballStartingPosition;
    public GameObject currentBall;

    public GameObject ballPrefab;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ballStartingPosition = currentBall.transform.position;
    }

    void Update()
    {
        scoreDisplayed.text = "Score: " + currentScore.ToString();
        livesDisplayed.text = "Lives: " + LivesRemaining.ToString();

        if(Input.GetKeyDown(KeyCode.Return)) {

        }
    }

    public void BallLost()
    {

        if (!hasLostBall)
        {
            hasLostBall = true;

            LivesRemaining--;

            if (LivesRemaining > 0)
            {
                /*ball.transform.position = ballStartingPosition;
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                hasLostBall = false;*/
                ResetBall();
            }
            else
            {
                gameTextDisplayed.text = "GAME <color=red>OVER</color>.\nPress Enter to continue.";

            }

        }



    }

    void ResetBall() {
        Destroy(currentBall);
        currentBall = Instantiate(ballPrefab);
        hasLostBall = false;
    }

    void ResetGame() {
        LivesRemaining = maxLives;
        currentScore = 0;
        isGameOver = false;
        hasLostBall = false;
        gameTextDisplayed.text = "";
        ResetBall();
    }
}