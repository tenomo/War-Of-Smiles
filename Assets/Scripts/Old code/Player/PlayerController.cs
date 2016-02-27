using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    float Speed = 10;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0) 
        {
           if ( this.gameObject.transform.position.x <= 5)
           {
               this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
           }
            else
           {

               move = 0;
               this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);

           }
        }
        else
        {
            if (this.gameObject.transform.position.x >= -5)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                move = 0;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
                 
            }
        }
         

       
       

    }
}
