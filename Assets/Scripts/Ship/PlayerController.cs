using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private ShipController shipController;

    public int Coin = 0;

    // Use this for initialization
    void Start()
    {
        shipController = gameObject.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press A
        if (Input.GetKey(KeyCode.A))
        {
            //Turn left
            shipController.TurnLeft();
        }

        //Press D
        if (Input.GetKey(KeyCode.D))
        {
            //Turn right
            shipController.TurnRight();
        }

        //Press W
        if (Input.GetKey(KeyCode.W))
        {
            //Speed Up
            shipController.SpeedUp();
        }

        //Press S
        if (Input.GetKey(KeyCode.S))
        {
            //Speed Down
            shipController.SpeedDown();
        }

        //Fire Cannon Ball
        if (Input.GetKeyDown(KeyCode.J))
        {
            shipController.FireCannonLeft();
        }

        //Fire Cannon Ball
        if (Input.GetKeyDown(KeyCode.K))
        {
            shipController.FireCannonRight();
        }

        //Fire Missile
        if (Input.GetKeyDown(KeyCode.L))
        {
            shipController.FireMissile();
        }
    }

    public bool LevelUp(int attrId, int level)
    {
        //Get Cost
        int cost = Data.ShipAttributeData[attrId.ToString() + level.ToString()].LevelUpCost;

        //Check Sufficient Coin
        if (Coin < cost)
        {
            return false;
        }

        var result = shipController.Ship.ShipAttributes.LevelUp(attrId);

        if (!result)
        {
            //Level Up False
            return false;
        }

        //Deduct the cost
        Coin = Coin - cost;
        return true;
    }
}
