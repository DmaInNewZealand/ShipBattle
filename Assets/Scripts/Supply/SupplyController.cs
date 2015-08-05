using UnityEngine;
using System.Collections;

public class SupplyController : MonoBehaviour
{
    private float heal = 50.0f;

    //PlayerEnter
    public void OnTriggerEnter(Collider other)
    {
        //Hit by Player
        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<ShipController>().AddHp(heal);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Check If supply is far away from player
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //If distance is greater than 50.0f
        if (Vector3.Distance(playerPosition, transform.position) >= 50.0f)
        {
            Destroy(gameObject);
        }
    }
}