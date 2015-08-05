using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerVirtualController : MonoBehaviour
{
    public Image leftCannonCD;
    public Image rightCannonCD;
    public Image missileCD;

    private ShipController shipController;

    private enum AccelerationStatus
    {
        SpeedUp,
        SpeedDown,
        Maintain
    };

    private enum TurningStatus
    {
        TurnLeft,
        TurnRight,
        Maintain
    }

    //Record current status
    private AccelerationStatus currentAS = AccelerationStatus.Maintain;
    private TurningStatus currentTS = TurningStatus.Maintain;

    // Use this for initialization
    void Start()
    {
        shipController = gameObject.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Speed up or Speed down
        switch (currentAS)
        {
            case AccelerationStatus.SpeedUp:
                shipController.SpeedUp();
                break;
            case AccelerationStatus.SpeedDown:
                shipController.SpeedDown();
                break;
            case AccelerationStatus.Maintain:
                break;
            default:
                break;
        }

        //Turn left or turn right
        switch (currentTS)
        {
            case TurningStatus.TurnLeft:
                shipController.TurnLeft();
                break;
            case TurningStatus.TurnRight:
                shipController.TurnRight();
                break;
            case TurningStatus.Maintain:
                break;
            default:
                break;
        }
    }

    //Speed UP
    public void SpeedUp()
    {
        currentAS = AccelerationStatus.SpeedUp;
    }

    //Speed down
    public void SpeedDown()
    {
        currentAS = AccelerationStatus.SpeedDown;
    }

    //Maintain current speed
    public void SpeedMaitain()
    {
        currentAS = AccelerationStatus.Maintain;
    }

    //turn left
    public void TurnLeft()
    {
        currentTS = TurningStatus.TurnLeft;
    }

    //turn right
    public void TurnRight()
    {
        currentTS = TurningStatus.TurnRight;
    }

    //turn maintain
    public void TurnMaitain()
    {
        currentTS = TurningStatus.Maintain;
    }

    //Fire Left Cannon
    public void FireLeftCannon()
    {
        //IF CD?
        if (shipController.GetCannonLeftCD() <= 0)
        {
            //No
            shipController.FireCannonLeft();

            //Set Skill to CD
            leftCannonCD.fillAmount = 1.0f;
        }
    }
    //Fire Right Cannon
    public void FireRightCannon()
    {
        //IF CD?
        if (shipController.GetCannonRightCD() <= 0)
        {
            //No
            shipController.FireCannonRight();

            //Set Skill to CD
            rightCannonCD.fillAmount = 1.0f;
        }
    }

    //Fire Missile
    public void FireMissile()
    {
        //IF CD?
        if (shipController.GetMissileCD() <= 0)
        {
            //No
            shipController.FireMissile();

            //Set Skill to CD
            missileCD.fillAmount = 1.0f;
        }
    }
}
