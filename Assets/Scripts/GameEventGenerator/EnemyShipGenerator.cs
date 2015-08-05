using UnityEngine;
using System.Collections;

public class EnemyShipGenerator : MonoBehaviour
{
    public GameObject EnemyShip;

    //Generate Ship CD
    private float generateCD = 0;

    //Max Count
    private int MAXCOUNT = 2;

    //Total Enemy Ship Generate
    private int total = 0;

    // Update is called once per frame
    void Update()
    {
        if (generateCD <= 0)
        {
            //Get Current Enemy Ships in the field
            var currentCount = GameObject.FindGameObjectsWithTag("Enemies").Length;

            if (currentCount < MAXCOUNT)
            {
                //Generate a ship
                Vector3 shipPosition;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        //Top
                        shipPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0, Camera.main.transform.position.z + 30.0f);
                        break;
                    case 1:
                        //Bottom
                        shipPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0, Camera.main.transform.position.z - 30.0f);
                        break;
                    case 2:
                        //Right
                        shipPosition = new Vector3(Camera.main.transform.position.x + 40.0f, 0, Random.Range(-30.0f, 30.0f));
                        break;
                    case 3:
                        //Left
                        shipPosition = new Vector3(Camera.main.transform.position.x - 40.0f, 0, Random.Range(-30.0f, 30.0f));
                        break;
                    default:
                        shipPosition = new Vector3(Camera.main.transform.position.x + 40.0f, 0, Camera.main.transform.position.z + 30.0f);
                        break;
                }
                Instantiate(EnemyShip, shipPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0.0f, 360.0f), 0));
                total++;

                //every 20 ships generated, max count + 1
                MAXCOUNT = (int)(total / 20) + 2;

                //Set CD to 3seconds
                generateCD = 3.0f;
            }
        }
        else
        {
            //Generator is cd
            generateCD -= Time.deltaTime;
        }
    }
}
