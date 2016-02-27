using UnityEngine;
using System.Collections;

public class HealthGUI : MonoBehaviour {

    public Texture2D hpTexture;
    public Texture2D fontexture;
    public GameObject _Object;
    Health health;
    void Start ()
    {
         
        health = _Object.GetComponent<PlayerHealth>().health;
    }
  
	 private void OnGUI ()
     {
         if (GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>().statusGame == GameHandler.Status.NormalGame)
         {
             GUI.DrawTexture(new Rect(15, 15, (health.MaxHealth * 20) + 15, 30), fontexture);
             GUI.DrawTexture(new Rect(20, 20, health.points * 20, 20), hpTexture);
         }
     }
}
