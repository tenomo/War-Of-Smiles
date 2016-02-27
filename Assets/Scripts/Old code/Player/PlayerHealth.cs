using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public Health health;
    public int MaxHealth;
    public GameObject GameHandlerObj;

    private void Awake()
    {
        health = new Health(MaxHealth);

    }

    private void Update()
    {
        Death();
    }

    public Health GetHealth()
    {
        return health;
    }


    public void Death()
    {
        if (health.points == 0)
        {
            // animation.Play();
            GameHandlerObj.GetComponent<GameHandler>().GameLose();
        }
    }
}
