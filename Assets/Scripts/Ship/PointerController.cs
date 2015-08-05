using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //get all enemies
        var enemies = GameObject.FindGameObjectsWithTag("Enemies");

        //if no enemy, dont move
        if(enemies.Length == 0)
        {
            return;
        }

        var distance = Mathf.Infinity;

        //Default is the first enemy in the list
        Transform nearest = enemies[0].transform;

        foreach(var enemy in enemies)
        {
          var currentDis =  Vector3.Distance(enemy.transform.position,transform.position);

            //Get the nearest enemy
            if (currentDis < distance)
            {
                distance = currentDis;
                nearest = enemy.transform;
            }
        }
        transform.LookAt(nearest);
        
        //Set rotation;
        transform.Rotate(90, 90, 0);
    }
}
