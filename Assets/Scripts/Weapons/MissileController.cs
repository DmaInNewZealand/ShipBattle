using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
    //Set Missile Belongs to
    private GameObject parent;

    //Set Missile Power
    private float missilePower;

    //Missile Speed
    private float missileSpeed;

    //Set Missile Fly Time
    private float missileFlyTime;

    //Missile Turn Speed
    private float missileTurnSpeed;

    //Missile Target
    private GameObject target;

    //Missile Retarget Cool Down
    private float retargetCoolDown = 0.0f;

    //Flied Time
    private float fliedTime = 0.0f;

    //Set if the missile hit something
    private bool isHit = false;

    //Effects
    public GameObject Explosion;
    public GameObject WaterFlare;

    // Use this for initialization
    void Start()
    {
        //Set Self Destroy Time
        Destroy(gameObject, missileFlyTime);

        //Get Target
        ReTargeting();
    }

    void Update()
    {
        //If missing target and retarget is cool down
        if (target == null && retargetCoolDown <= 0)
        {
            //Retarget
            ReTargeting();
        }

        //Calculate Cool Down
        if (retargetCoolDown > 0)
        {
            retargetCoolDown = retargetCoolDown - Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        fliedTime += Time.deltaTime; 

        //Check the missile has a Target
        if (target == null)
        {
            //Still No target
            //TODO: Fly Randomly
        }
        else
        {
            //Has a target
            //Set Target Rotation
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

            //Rotate to Target Rotation
            gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, missileTurnSpeed * Time.deltaTime));
        }

        //Set Missile Velocity
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * missileSpeed * Mathf.Cos(Mathf.PI / 30 * fliedTime);
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
            other.gameObject.GetComponent<ShipController>().LoseHp(missilePower);

            isHit = true;

            //Destroy Cannon Ball
            Destroy(gameObject);
        }
    }

    //Initiate Missile Attributes
    public void MissileInit(GameObject parent, float missilePower, float missileSpeed, float missileFlyTime, float missileTurnSpeed)
    {
        //Set Missile Belongs to
        this.parent = parent;

        //Set Missile Power
        this.missilePower = missilePower;

        //Missile Speed
        this.missileSpeed = missileSpeed;

        //Set Missile Fly Time
        this.missileFlyTime = missileFlyTime;

        //Missile Turn Speed
        this.missileTurnSpeed = missileTurnSpeed;
    }

    //Missile ReTarget
    private void ReTargeting()
    {
        //Get Targets
        var targets = GameObject.FindGameObjectsWithTag("Enemies");

        //If None Targets exist
        if (targets.Length == 0)
        {
            //Set No Target and Return
            target = null;
            return;
        }

        //If Multiple Targets exists
        //Select the nearest one
        var nearest = Mathf.Infinity;
        foreach (var t in targets)
        {
            var distance = Vector3.Distance(parent.transform.position, t.transform.position);
            if (distance < nearest)
            {
                nearest = distance;
                target = t;
            }
        }

        //Trigger Cool Down Time = 1.0 second
        retargetCoolDown = 1.0f;
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
