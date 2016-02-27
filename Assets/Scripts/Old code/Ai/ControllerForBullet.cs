using UnityEngine;
using System.Collections;

public class ControllerForBullet : BehaviourGameObject
{
    private void Start()
    {
        base.Speed = 3.0f;
        base.lifetime = 6.0f;
        base.EnemyTag = "Enemy";
        base.demage = new Demage(5, base.EnemyTag);
    }
    void Update()
    {
        MoveObject(Vector3.up, base.Speed);
        DestroyObject(lifetime);
    }
    public   void OnTriggerEnter2D(Collider2D other)
    {
        base.demage.Harm(other.gameObject);
        this.DestroyObject(/*lifeTimeInCollision*/);
        // play the animation death.
    }
}
