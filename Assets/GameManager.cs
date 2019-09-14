using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static int PlayToScore = 10;

    public GUISkin layout;
    private BallControl Ball;

    // Start is called before the first frame update
    void Start()
    {
        var ballObj = GameObject.FindGameObjectWithTag("Ball");
        if(ballObj != null) {
            Ball = ballObj.GetComponent<BallControl>();
        }
    }

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    public void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            Ball.RestartGame();
        }

        if (PlayerScore1 == GameManager.PlayToScore)
        {
            GUI.Label(new Rect(Screen.width / 2 -75, 200, 2000, 1000), "PLAYER ONE WINS");
            Ball.ResetBall();
        }
        else if (PlayerScore2 == GameManager.PlayToScore)
        {
            GUI.Label(new Rect(Screen.width / 2 -75, 200, 2000, 1000), "PLAYER TWO WINS");
            Ball.ResetBall();
        }
    }

}
