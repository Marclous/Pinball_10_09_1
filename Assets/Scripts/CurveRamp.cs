

using UnityEngine;

public class CurveRamp : MonoBehaviour
{
    private GameManager gameManager;
    private AnimateController aniController;
    private SpriteRenderer thisRenderer;
    private int score;

    public GameObject curveLampLightObj;
    public bool isInRamp = false;

    void Start()
    {
        // animation object
        thisRenderer = curveLampLightObj.GetComponent<Renderer>() as SpriteRenderer;
        aniController = curveLampLightObj.GetComponent<AnimateController>();
        // get scoreboard object
        GameObject obj = GameObject.Find("GameManager");
        if (obj != null)
        {
            gameManager = obj.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        if (isInRamp && gameManager != null)
        {
            Debug.Log("is in ramp");
            gameManager.currentScore += 10;
            thisRenderer.sprite = aniController.spriteSet[0];
        }
        else
        {
            thisRenderer.sprite = aniController.spriteSet[1];
        }
    }
}
