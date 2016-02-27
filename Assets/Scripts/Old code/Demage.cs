using UnityEngine;
using System.Collections;

public class Demage
{

    public int forceDamage { get; set; }    
    public string TagEnemy { get; set; }

    
    public Demage(int forceDamage)
    {
        this.forceDamage = forceDamage;
    }
    public Demage (int forceDamage, string TagEnemy)
    {
        this.forceDamage = forceDamage;
        this.TagEnemy = TagEnemy;
    }
    public void Harm(GameObject otherObj, string TagEnemy)
    {
        try
        {

            if (otherObj.tag == TagEnemy)
            {
                Debug.Log("Harm: " + forceDamage.ToString() + "  Enemy tag: " + TagEnemy);
                this.internal_harm(otherObj);
            }
        }
        catch { } // Исключение с объектом плеер так как у него нету компонента HP. ловим, пока ничего не делаем
         
    }
  
   public void Harm(GameObject otherObj)
    {
        try
        {
            if (otherObj.tag == this.TagEnemy)
            {
                Debug.Log("Harm: " + forceDamage.ToString() + "  Enemy tag: " + TagEnemy);
                this.internal_harm(otherObj);
            }
        }
        catch { }// Исключение с объектом плеер так как у него нету компонента HP. ловим, пока ничего не делаем
         
    }

   private void internal_harm(GameObject otherObj)
   { 
       IHealth iHealth = (IHealth)otherObj.GetComponent(typeof(IHealth));
       Health health = iHealth.GetHealth();
       health.points -= forceDamage;
   }
}
