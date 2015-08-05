using UnityEngine;
using System.Collections;

public class SupplyGenerator : MonoBehaviour
{
    public GameObject Supply;

    //Generate Supply CD
    private float generateCD = 0;

    //Max Count
    private const int MAXCOUNT = 3;

    // Update is called once per frame
    void Update()
    {
        if (generateCD <= 0)
        {
            //Get Current supply in the field
            var currentCount = GameObject.FindGameObjectsWithTag("Supply").Length;

            if (currentCount < MAXCOUNT)
            {
                //Generate a supply
                Vector3 supplyPosition = new Vector3(Random.Range(-30.0f, 30.0f) + Camera.main.transform.position.x, 0, Random.Range(-20.0f, 20.0f) + Camera.main.transform.position.z);

                Instantiate(Supply, supplyPosition, Quaternion.identity);

                //Set CD to 15 seconds
                generateCD = 15.0f;
            }
        }
        else
        {
            //Generator is cd
            generateCD -= Time.deltaTime;
        }
    }
}
