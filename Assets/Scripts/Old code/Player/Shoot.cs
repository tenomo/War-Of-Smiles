using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shoot : MonoBehaviour
{

    public List<GameObject> BulletsForShooting;
    public Transform SpownPoint;

    void SpownBullet(Transform SpownPoint, int bulletID)
    {
        if (BulletsForShooting != null)
        {
            GameObject Bollet = BulletsForShooting[bulletID];

            GameObject.Instantiate(Bollet, SpownPoint.position, SpownPoint.rotation);
        }
        else
            Debug.LogError("Need objects to list");

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            short bulletID = 0;  
            SpownBullet(SpownPoint, bulletID);
        }
    }
}
