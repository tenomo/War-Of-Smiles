using UnityEngine;
using System.Collections;

public abstract class BehaviourGameObject : MonoBehaviour
{
    private float speedPerHour;
    
    protected float Speed;
    protected float lifetime;

    protected int ForceDemage;
    protected string EnemyTag;

    protected Demage demage { get; set; }
    private bool _isMove = true;
    public bool isMove { get { return _isMove; } set { _isMove = value; } } 

    protected void MoveObject(Vector3 direction, float Speed)
    {
        if (this.isMove)
        {
            speedPerHour = Time.deltaTime * Speed;
            transform.position += direction.normalized * speedPerHour;
        }
    }
    protected  void DestroyObject(float lifetime)
    {
        GameObject.Destroy(this.gameObject, lifetime);
    }
    protected void DestroyObject()
    {
        GameObject.Destroy(this.gameObject);
    }
}
