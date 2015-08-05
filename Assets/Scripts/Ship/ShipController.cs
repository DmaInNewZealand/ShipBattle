using UnityEngine;
using System.Collections;
using System;

public class ShipController : MonoBehaviour
{
    /// <summary>
    /// Get Ship Current Speed
    /// </summary>
    public float CurrentSpeed
    {
        get
        {
            return currentSpeed;
        }
    }
    private float currentSpeed;

    /// <summary>
    /// Get Ship Current HP
    /// </summary>
    public float CurrentHp
    {
        get
        {
            return currentHp;
        }
    }
    private float currentHp;

    //Prefabs weapon
    public GameObject CannonBall;
    public GameObject Missile;

    //Ship attributes
    public Ship Ship { get; private set; }

    //Weapons Cool Down
    private float cannonLeftCD = 0.0f;
    private float cannonRightCD = 0.0f;
    private float missileCD = 0.0f;

    //Set CD
    private const float MAXCANNONCD = 1.5f;
    private const float MAXMISSILECD = 10.0f;

    //System Events
    //Ship Dead
    public event EventHandler Dead;

    // Use this for initialization
    void Start()
    {
        //New ship
        Ship = new Ship();

        //Set Hp = maxHp
        currentHp = Ship.MaxHP;

        //Set current Speed
        currentSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move forword
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.Self);

        //Calculate Cool Down
        if (cannonLeftCD > 0)
        {
            cannonLeftCD = cannonLeftCD - Time.deltaTime;
        }

        if (cannonRightCD > 0)
        {
            cannonRightCD = cannonRightCD - Time.deltaTime;
        }

        if (missileCD > 0)
        {
            missileCD = missileCD - Time.deltaTime;
        }

    }

    public void SpeedUp()
    {
        //Speed up
        currentSpeed = currentSpeed + Ship.Acceleration * Time.deltaTime;

        //Check for Max Speed
        if (currentSpeed > Ship.MaxSpeed)
        {
            currentSpeed = Ship.MaxSpeed;
        }
    }

    public void SpeedDown()
    {
        //Speed down
        currentSpeed = currentSpeed - Ship.Acceleration * Time.deltaTime;

        //Check for Min Speed
        if (currentSpeed < Ship.MinSpeed)
        {
            currentSpeed = Ship.MinSpeed;
        }
    }

    public void TurnLeft()
    {
        //Turn Left
        gameObject.transform.Rotate(Vector3.up, -1 * Ship.TurnSpeed * Time.deltaTime);
    }

    public void TurnRight()
    {
        //Turn Right
        gameObject.transform.Rotate(Vector3.up, Ship.TurnSpeed * Time.deltaTime);
    }

    public void FireCannonLeft()
    {
        //Check if in CD
        if (cannonLeftCD <= 0)
        {
            //Fire Cannon
            for (int i = 0; i < Ship.CannonNumber; i++)
            {
                var cannonBall = Instantiate(CannonBall, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + UnityEngine.Random.Range(-100, -80), 0)) as GameObject;
                cannonBall.GetComponent<CannonBallController>().CannonInit(gameObject, Ship.CannonPower, Ship.CannonSpeed, Ship.CannonRange / Ship.CannonSpeed);
            }

            //set cannonleft in cd
            cannonLeftCD = MAXCANNONCD;
        }
    }

    public void FireCannonRight()
    {
        //Check if in CD
        if (cannonRightCD <= 0)
        {
            //Fire Cannon
            for (int i = 0; i < Ship.CannonNumber; i++)
            {
                var cannonBall = Instantiate(CannonBall, transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + UnityEngine.Random.Range(80, 100), 0)) as GameObject;
                cannonBall.GetComponent<CannonBallController>().CannonInit(gameObject, Ship.CannonPower, Ship.CannonSpeed, Ship.CannonRange / Ship.CannonSpeed);
            }

            //set cannonright in cd
            cannonRightCD = MAXCANNONCD;
        }
    }

    public void FireMissile()
    {
        //Check if in CD
        if (missileCD <= 0)
        {
            //Fire Missile
            var missile = Instantiate(Missile, transform.position, transform.rotation) as GameObject;
            missile.GetComponent<MissileController>().MissileInit(gameObject, Ship.MissilePower, Ship.MissileSpeed, Ship.MissileFlyTime, Ship.MissileTurnSpeed);

            //set missile in cd
            missileCD = MAXMISSILECD;
        }
    }

    //Lose Hp
    public void LoseHp(float lostHp)
    {
        //Player only recieve 50% damage
        if(gameObject.tag == "Player")
        {
            lostHp = lostHp / 2;
        }

        currentHp = currentHp - lostHp;
        if (currentHp <= 0.0f)
        {
            //Hp drops below 0, Dead
            if (Dead != null)
            {
                Dead(this, EventArgs.Empty);
            }
        }
    }

    //Add Hp
    public void AddHp(float addedHp)
    {
        currentHp = currentHp + addedHp;
        if (currentHp >= Ship.MaxHP)
        {
            currentHp = Ship.MaxHP;
        }
    }

    //Load
    public void LoadShip(int[] attributes)
    {
        Ship = new Ship(attributes);
    }

    //Get Ship Level
    public int[] GetShipLevel()
    {
        return Ship.ShipAttributes.Attributes;
    }

    public float GetCannonLeftCD()
    {
        return cannonLeftCD;
    }

    public float GetCannonRightCD()
    {
        return cannonRightCD;
    }

    public float GetMissileCD()
    {
        return missileCD;
    }
}
