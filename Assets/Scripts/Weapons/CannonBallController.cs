using UnityEngine;
using System.Collections;

public class CannonBallController : MonoBehaviour
{
    //Set cannon ball belongs to
    private GameObject parent;

    //Set Cannon Ball Power
    private float cannonPower;

    //Set Cannon Ball Speed
    private float cannonSpeed;

    //Set Cannon Ball Fly Time
    private float cannonFlyTime;

    //Set if the cannon ball hit something
    private bool isHit = false;

    //Effects
    public GameObject Explosion;
    public GameObject WaterFlare;

    // Use this for initialization
    void Start()
    {
        //Set Self Destroy Time
        Destroy(gameObject, cannonFlyTime);
    }

    void FixedUpdate()
    {
        //Set CannonBall Velocity
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * cannonSpeed;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        if (parent.tag == other.gameObject.tag)
        {
            //Hit Self or Friendly Target, ignore
            return;
        }
        else if (other.gameObject.tag == "Enemies" || other.gameObject.tag == "Player")
        {
            //Hit Player Ship or Enemy Ship
            other.gameObject.GetComponent<ShipController>().LoseHp(cannonPower);

            isHit = true;

            //Destroy Cannon Ball
            Destroy(gameObject);
        }
    }

    public void CannonInit(GameObject parent, float cannonPower, float cannonSpeed, float cannonFlyTime)
    {
        //Set Cannon Ball Parent
        this.parent = parent;

        //Set Cannon Ball Power
        this.cannonPower = cannonPower;

        //Set Cannon Ball Speed
        this.cannonSpeed = cannonSpeed;

        //Set Missile Fly Time
        this.cannonFlyTime = cannonFlyTime;
    }

    public void OnDisable()
    {
        if (isHit)
        {
            //Display Explosion
            var obj = Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(obj, 5);
        }
        else
        {
            //Display WaterFlare
            var obj = Instantiate(WaterFlare, transform.position, transform.rotation);
            Destroy(obj, 5);
        }
    }
}
