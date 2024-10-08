using UnityEngine;
using System.Collections;

public class Floatpiece : MonoBehaviour
{
    // Sound
    private SoundController sound;

    // Score
    private GameManager gameManager;

    private BuoyancyEffector2D floatEffector;
    public float floatingTime = 0f;
    private float runningTime = 0f;
    private float startTime = 0f;

    void Start()
    {
        // Get scoreboard and sound object
        GameObject obj = GameObject.Find("GameManager");
        gameManager = obj.GetComponent<GameManager>();
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        floatEffector = GetComponent<BuoyancyEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            floatEffector.density = 50;
            // start timer
            if (startTime == 0f)
            {
                startTime = Time.time;
                sound.bonus.Play();
                gameManager.currentScore += 10;
                StartCoroutine(BeginFloat());
            }
        }
    }

    IEnumerator BeginFloat()
    {
        while (true)
        {
            // calculate current duration
            runningTime = Time.time - startTime;

            // play animation loop
            yield return new WaitForSeconds(0.1f);

            // when time is up
            if (runningTime >= floatingTime)
            {
                // stop float and reset timer
                floatEffector.density = 0;
                runningTime = 0f;
                startTime = 0f;

                // stop sound and animation
                sound.bonus.Stop();
                break;
            }
        }
    }
}
