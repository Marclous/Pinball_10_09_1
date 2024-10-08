using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int livesLeft = 3;
    public int maxLives = 3;

    public int currentScore = 0;

    public int highScore = 0;

    public static GameManager Instance;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI livesDisplay;

    public TextMeshProUGUI gameTextDisplay;

    bool hasLostBall = false;
    bool isGameOver = false;

    public Vector2 ballStartingPosition;

    public List<GameObject> currentBalls; //ref to the current ball gameobject that's in play


    public GameObject myBallPrefab; //ref to the prefab for the ball to use to create new balls


    void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        ballStartingPosition = currentBalls[0].transform.position;


        highScore = PlayerPrefs.GetInt("HighScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "score:" + currentScore.ToString();
        highScoreDisplay.text = "hi-score:" + highScore.ToString();
        livesDisplay.text = "balls remaining:" + livesLeft.ToString();


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isGameOver)
            {
                //restart the game
                ResetGame();
            }

        }

    }

    public void BallLost(GameObject whichBallToLose)
    {

        if (!hasLostBall)
        {

            livesLeft--;
            hasLostBall = true;

            if (livesLeft > 0)
            {
                ResetBall(whichBallToLose);
                AdjustTheScore();

            }
            else
            {
                //reset the whole game
                gameTextDisplay.text = "GAME <color=red>OVER</color>.\nPress Enter to continue.";
                isGameOver = true;


            }
        }
    }

    void ResetBall(GameObject whichBallToLose)
    {
        // //reset the ball 
        // myBall.transform.position = ballStartingPosition;
        // myBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0); //same as Vector2.zero
        // hasLostBall = false;

        Destroy(whichBallToLose);
        currentBalls.Remove(whichBallToLose);

        AddNewBall();
        
        hasLostBall = false;
    }

    void ResetGame()
    {
        livesLeft = maxLives;
        currentScore = 0;
        isGameOver = false;
        hasLostBall = false;
        gameTextDisplay.text = "";

        for(int i = 0; i < currentBalls.Count; i++)
        {
            ResetBall(currentBalls[i]);
        }
        
    }


    public void AdjustTheScore()
    {
        


        if(currentScore > highScore)
        {
            highScore = currentScore; 
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        

    }

    public void AddNewBall()
    {

           
        
        GameObject brandNewBall = Instantiate(myBallPrefab);
        brandNewBall.transform.position = ballStartingPosition;
        currentBalls.Add(brandNewBall);
        brandNewBall.name = "CurrentBall";
        


    }



}
