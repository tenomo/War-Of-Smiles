using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class SpawnMonsters : MonoBehaviour
{

    public GameObject mob; 
    private const short IntervalWaves = 2500;   
    private List<float> DiapasonSpawning;

    private bool StatusSpawned;
    private short SpawnCounter;
    private short WaweCounter;

    void Start()
    {
        this.SpawnCounter = 0;
        this.WaweCounter = 0;

        this.initDiapasonSpawning();
        this.StatusSpawned = false;
        this.Spawn();

        dualTimer.StartTimer();
    }


    private void CountSpawn()    
    {
        this.SpawnCounter++;
    }
    private void CountWawe()    
    {
        this.SpawnCounter = 0;
        this.WaweCounter++;
    }

    private void StartedTimerInitialization()
    {
        this.initLevel(500, 1500, 3, 5);   // магические цыфры

    }

    DualTimer dualTimer;

    #region Status spawned
    private void Spawned()
    {
        this.StatusSpawned = true;
    }
    private void NoSpawned()
    {
        this.StatusSpawned = false;
    }
    #endregion

    #region create a position
    private void initDiapasonSpawning()
    {
        this.DiapasonSpawning = new List<float>();

        float mainCameraSize = Camera.main.orthographicSize;

        float lenght = mainCameraSize * 2 - 1;
        float startPoint = -(mainCameraSize - 1);

        for (int i = 0; i < lenght; i++)
        {
            this.DiapasonSpawning.Add(startPoint);
            startPoint++;
        }
    }

    Vector2 RandomPosition()
    {
        System.Random rndObj = new System.Random();
        if (this.DiapasonSpawning != null & this.DiapasonSpawning.Count > 0)
        {
            int indexRange = rndObj.Next(0, this.DiapasonSpawning.Count - 1);
            float x = this.DiapasonSpawning[indexRange];
            this.DiapasonSpawning.RemoveAt(indexRange);
            var SpawnPosition = new Vector2(x, this.transform.position.y);
            return SpawnPosition;
        }
        else
        {
            initDiapasonSpawning();
            return RandomPosition();

        }
    }
    #endregion

    private void Spawn()
    {

        int level = 1; // заглушка

        switch (level)
        {
            case 1:
                this.initLevel(500, 1500, 5, 8);
                this.InstanceGameObject(this.mob);
                 
                this.NoSpawned();
                break;

            case 2:
                break;

            case 3: 
                break;

            default:
                this.NoSpawned();
                break;
        }
    }
    
    void initLevel(short IntervalMin, short intervalMax, short SpawnCountMin, short SpawnCountMax)
    {
        System.Random rndObj = new System.Random();
        dualTimer = new DualTimer(Spawned, IntervalWaves, IntervalMin, intervalMax, rndObj.Next(SpawnCountMin, SpawnCountMax));
        this.dualTimer.MethodPerformedInExternal = CountWawe;
        
    }

    private void InstanceGameObject(GameObject obj)
    {
        if (StatusSpawned & Time.timeScale > 0)
        {
            GameObject.Instantiate(obj, this.RandomPosition(), this.transform.rotation)  ;
           
            this.CountSpawn();

        }
       

    }
    void Update()
    {
        Spawn();

    }
}
