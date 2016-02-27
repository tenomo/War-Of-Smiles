using UnityEngine;
using System.Collections;

public class QuickMonster : EnemyBase
{
    private bool isQuickStep;

    private Vector2 directionStep;
    private Vector3 player_pos_to_step = Vector3.zero;
    protected override void Start()
    {
        base.Start();
        this.InstanceObjectOfVision();
        base.Speed = 3.0f;
        base.ForceDemage = 2;
        this.isQuickStep = false;
    }
    protected override void Update()
    {
        base.Update();
        if (!this.isQuickStep)
            base.MoveObject(Vector3.down, base.Speed);
        else
            this.quickStep();
    }
    void InstanceObjectOfVision()
    {
        GameObject ObjectOfVision = new GameObject("ObjectOfVision");
        ObjectOfVision.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1);
        ObjectOfVision.AddComponent<BoxCollider2D>();
        ObjectOfVision.GetComponent<Collider2D>().isTrigger = true;
        ObjectOfVision.transform.parent = this.transform;
        ObjectOfVision.transform.localScale = new Vector3(2.5f, 5);
    }

    private void enableQuickStep()
    {
        Debug.Log("enable step");
        this.isQuickStep = true;
    }
    private void disableQuickStep()
    {
        Debug.Log("disable step");
        this.isQuickStep = false;

        Time.timeScale = 1;
    }
    private Vector2 GenerationStepPosition()
    {
        float sizeCamera = Camera.main.orthographicSize;
        Vector2[] directionsStep = { new Vector2(player_pos_to_step.x - 3, 0),
                                       new Vector2(player_pos_to_step.x + 3, 0) };
        Vector2 dir = directionsStep[Random.Range(0, directionsStep.Length)];
        if (dir.x > -sizeCamera & dir.x < sizeCamera)
            return dir;
        else
            disableQuickStep();

        return Vector2.zero;
    }

    private void quickStep()
    {
        if (this.isQuickStep)
        {
            Time.timeScale = 0.3f;
            float quickStepSpeed = base.Speed * 4;

            base.MoveObject(this.directionStep, quickStepSpeed);

            this.gameObject.GetComponent<Collider2D>().enabled = false;

            //if ((this.transform.position.x - player_pos_to_step.x + 3) <= 0.1f &
            //    (this.transform.position.x - player_pos_to_step.x - 3) <= 0.1f)
            //{
            //    this.gameObject.collider2D.enabled = true;
            //    this.disableQuickStep();
            //}

            if ( ( (player_pos_to_step.x + 3) - this.transform.position.x)<=0.1f ||
               ( (player_pos_to_step.x - 3) - this.transform.position.x) <= 0.1f)

            {
                this.gameObject.GetComponent<Collider2D>().enabled = true;
               this.disableQuickStep();
            }
        }
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire Ball")
        {
            Debug.Log("Collision is fire ball: " + other.tag);
            this.directionStep = this.GenerationStepPosition();
            this.player_pos_to_step = this.transform.position;
            this.enableQuickStep();
        }
        else if (other.tag == base.EnemyTag)
        {
            base.demage.Harm(other.gameObject);
            this.DestroyObject(/*lifeTimeInCollision*/);
            // play the animation death.
        }
        else
        {

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire Ball")
        {
            this.disableQuickStep();
        }

    }
}
