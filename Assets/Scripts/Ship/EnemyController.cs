using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private ShipController shipController;

    private GameObject target;

    public GameObject Sink;

    //Ship movement parameters
    private float linearV;
    private float angularV;
    private float radius;

    // Use this for initialization
    void Start()
    {
        shipController = gameObject.GetComponent<ShipController>();

        //Set Target
        target = GameObject.FindGameObjectWithTag("Player");

        //Get player level
        var playerLevels = target.GetComponent<ShipController>().GetShipLevel();

        int totalLevel = 0;

        foreach (var level in playerLevels)
        {
            totalLevel += level;
        }

        //Generate Ship level based on player level
        int[] shipLevels = new int[12];

        for (int i = 0; i < totalLevel; i++)
        {
            //Add level to random attribute
            var number = Random.Range(0, 11);

            //if this attribute level max?
            if (shipLevels[number] < 4)
            {
                //No
                shipLevels[number]++;
            }
            else
            {
                //Yes, lose this point
                continue;
            }
        }

        //Generate the Enemy ship
        shipController.LoadShip(shipLevels);

        //Register the Dead Event
        shipController.Dead += OnDead;

        CalculateShipMoveParameters();
    }

    private void CalculateShipMoveParameters()
    {
        //Get radius
        radius = shipController.Ship.CannonRange;

        //Get Linear Velocity
        linearV = shipController.Ship.MaxSpeed;

        //Get Angular Velocity
        angularV = shipController.Ship.TurnSpeed / 180.0f * Mathf.PI;

        if (linearV / angularV <= radius)
        {
            //If real radius <= preset radius 
            radius = linearV / angularV;
        }
        else
        {
            //If real radius > preset radius , speed has to be reduced
            linearV = angularV * radius;
        }

        //Debug.Log("-----------------------");
        //Debug.Log(radius);
        //Debug.Log(linearV);
        //Debug.Log(angularV);
        //Debug.Log("-----------------------");
    }

    private void OnDead(object sender, System.EventArgs e)
    {
        //Debug.Log("Enemy Dead!!!!!!!");
        //Add Coin to Player
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Coin++;

        //Generate the ruin of the ship
        Instantiate(Sink, transform.position, transform.rotation);
        
        //TODO:Play Animation
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Check If this ship is far away from the target

        //If distance is greater than 60.0f
        if (Vector3.Distance(target.transform.position, transform.position) >= 60.0f)
        {
            Destroy(gameObject);
        }

        //aim the target
        var v1 = transform.forward;
        var v2 = (target.transform.position - transform.position).normalized;

        var targetRotationAngle = Vector3.Angle(v1, v2);

        if (v1.x * v2.z - v2.x * v1.z > 0)
        {
            targetRotationAngle = 360 - targetRotationAngle;
        }

        //Move Strategy
        if (Vector3.Distance(target.transform.position, transform.position) > radius)
        {
            //distance between the ship and the target is larger than the radius

            //Keep speed up
            shipController.SpeedUp();

            if (Mathf.Sin(targetRotationAngle / 180.0f * Mathf.PI) > 0)
            {
                //TurnRight
                shipController.TurnRight();
            }
            else if (Mathf.Sin(targetRotationAngle / 180.0f * Mathf.PI) < 0)
            {
                //TurnLeft
                shipController.TurnLeft();
            }
        }
        else
        {
            //Rotate against the target
            if (shipController.CurrentSpeed < linearV)
            {
                //Speed is lower than preset
                shipController.SpeedUp();
            }
            else if (shipController.CurrentSpeed > linearV)
            {
                //Speed is higher than preset
                shipController.SpeedDown();
            }

            if ((targetRotationAngle >= 0 && targetRotationAngle < 90) || (targetRotationAngle > 180 && targetRotationAngle < 270))
            {
                //TurnLeft
                shipController.TurnLeft();
            }
            else if ((targetRotationAngle > 90 && targetRotationAngle <= 180) || (targetRotationAngle > 270 && targetRotationAngle <= 360))
            {
                //TurnRight
                shipController.TurnRight();
            }
        }

        //Fire Weapon Strategy
        if (targetRotationAngle >= 75 && targetRotationAngle <= 105)
        {
            //Fire Right Cannon
            shipController.FireCannonRight();
        }

        if (targetRotationAngle >= 255 && targetRotationAngle <= 285)
        {
            //Fire Left Cannon
            shipController.FireCannonLeft();
        }
    }
}
