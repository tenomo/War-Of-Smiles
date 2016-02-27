using UnityEngine;
using System.Collections;

public abstract class EnemyBase : BehaviourGameObject, IHealth  
{   
    protected int maxHealth = 5;
    protected int PointsForDeath = 1;
    protected Health health; 
    private GameHandler gameHandler;
    protected virtual void Start()
    {
        base.lifetime = 6.0f;
        this.Speed = 3.0f;
        base.EnemyTag = "Player";
        base.ForceDemage = 1; 
        this.demage = new Demage(this.ForceDemage,this.EnemyTag);
        health = new Health(this.maxHealth);
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
    }

    protected virtual void Update ()
    {
        this.Death();
    }
     
    public Health GetHealth()
    {
        return this.health;
    }
    public void Death()
    {
        base.DestroyObject(base.lifetime);
        if (health.points == 0)
        { 
            this.gameHandler.AddPoint(PointsForDeath); 
            base.DestroyObject();            
        }
    }


    public abstract void OnTriggerEnter2D(Collider2D other);
   //public  abstract  void OnTriggerEnter2D(Collider2D other)
   // {
   //     base.demage.Harm(other.gameObject);
   //     this.DestroyObject(/*lifeTimeInCollision*/);
   //     // play the animation death.
       
   // }
     
}
