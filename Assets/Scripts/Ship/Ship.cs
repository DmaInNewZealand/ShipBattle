using UnityEngine;
using System.Collections;

public class Ship
{
    public ShipAttributes ShipAttributes;

    #region Ship Attributes
    /// <summary>
    /// Ship Max HP from ShipArmorLevel
    /// </summary>
    public float MaxHP
    {
        get
        {
            return Data.ShipAttributeData["0" + ShipAttributes.ShipArmorLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Ship Max Speed from ShipSpeedLevel 
    /// </summary>
    public float MaxSpeed
    {
        get
        {
            return Data.ShipAttributeData["1" + ShipAttributes.ShipSpeedLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Ship Min Speed 
    /// </summary>
    public float MinSpeed
    {
        get
        {
            return 0.0f;
        }
    }

    /// <summary>
    /// Ship Acceleration from ShipEngineLevel
    /// </summary>
    public float Acceleration
    {
        get
        {
            return Data.ShipAttributeData["2" + ShipAttributes.ShipEngineLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Ship Turn Speed from ShipRudderLevel
    /// </summary>
    public float TurnSpeed
    {
        get
        {
            return Data.ShipAttributeData["3" + ShipAttributes.ShipRudderLevel].AttributeValue;
        }
    }
    #endregion

    #region Cannon Attributes
    /// <summary>
    /// Cannon Power from CannonPowerLevel
    /// </summary>
    public float CannonPower
    {
        get
        {
            return Data.ShipAttributeData["4" + ShipAttributes.CannonPowerLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Cannon Range from CannonRangeLevel
    /// </summary>
    public float CannonRange
    {
        get
        {
            return Data.ShipAttributeData["5" + ShipAttributes.CannonRangeLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Cannon Speed from CannonSpeedLevel
    /// </summary>
    public float CannonSpeed
    {
        get
        {
            return Data.ShipAttributeData["6" + ShipAttributes.CannonSpeedLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Number of Cannonball Shot from CannonShootLevel
    /// </summary>
    public int CannonNumber
    {
        get
        {
            return (int)Data.ShipAttributeData["7" + ShipAttributes.CannonShootLevel].AttributeValue;
        }
    }
    #endregion

    #region Missile Attributes
    /// <summary>
    /// Missile Power from MissilePowerLevel 
    /// </summary>
    public float MissilePower
    {
        get
        {
            return Data.ShipAttributeData["8" + ShipAttributes.MissilePowerLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Missile Speed from MissileSpeedLevel 
    /// </summary>
    public float MissileSpeed
    {
        get
        {
            return Data.ShipAttributeData["9" + ShipAttributes.MissileSpeedLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Missile Fly Time from MissileTimeLevel 
    /// </summary>
    public float MissileFlyTime
    {
        get
        {
            return Data.ShipAttributeData["10" + ShipAttributes.MissileTimeLevel].AttributeValue;
        }
    }

    /// <summary>
    /// Missile Turn Speed from MissileTurnLevel 
    /// </summary>
    public float MissileTurnSpeed
    {
        get
        {
            return Data.ShipAttributeData["11" + ShipAttributes.MissileTurnLevel].AttributeValue;
        }
    }
    #endregion

    //Create a new ship
    public Ship()
    {
        NewShip();
    }

    //Load a ship
    public Ship(int[] attributes)
    {
        if (attributes.Length < 12)
        {
            //if input array is wrong, create a new one
            NewShip();
            return;
        }

        for (int i = 0; i < 12; i++)
        {
            //Check if the level is out of range, if yes create a new one
            if (attributes[i] < 0 || attributes[i] > 4)
            {
                NewShip();
                return;
            }
        }

        ShipAttributes = new ShipAttributes(attributes);
    }

    private void NewShip()
    {
        ShipAttributes = new ShipAttributes(new int[12]);
    }
}