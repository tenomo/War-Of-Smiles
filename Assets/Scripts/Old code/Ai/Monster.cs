using UnityEngine;
using System.Collections;

public class Monster : EnemyBase {

    protected override void Start()
    {
        base.Start();
        base.Speed = 3.0f;
        base.ForceDemage = 1;
    }
    protected override void Update()
    {
        base.Update();
        base.MoveObject(Vector3.down, base.Speed);

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == EnemyTag)
        {
            base.demage.Harm(other.gameObject);
            this.DestroyObject(/*lifeTimeInCollision*/);
        }
    }
}
