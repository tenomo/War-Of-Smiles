using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{

    public enum Status { NormalGame, Pause, Win, lose };
    public int PointsToWin = 10;   

    public Status statusGame
    {

        get;
        set;
    }

    public int GamePoints
    {
        get;
        set;
    }

    public void StartGame ()
    {
        Time.timeScale = 1;
        statusGame = Status.NormalGame;

    }
    public void StopGame ()
    {
        Time.timeScale = 0;
    }

    public void ReloadLevel ()
    {
        Application.LoadLevel("GameScene");
    }

    
    public void AddPoint(int Points)
    {
        GamePoints += Points;
    }

    private void Start()
    {
        GamePoints = 0;
        statusGame = Status.NormalGame;
    }

    public void GameLose()
    {
        statusGame = Status.lose;
    }
    private void Update()
    {
        if (GamePoints >= PointsToWin)
        {
            statusGame = Status.Win;
             
        }

        

        if (statusGame == Status.NormalGame)
            StartGame();
        else
            StopGame();
    }



}
