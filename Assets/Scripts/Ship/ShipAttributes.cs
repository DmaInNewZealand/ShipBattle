using UnityEngine;
using System.Collections;

public class ShipAttributes
{
    #region Ship Level Attributes
    /// <summary>
    /// The ship armor level, controls the max hp of a ship
    /// </summary>
    public int ShipArmorLevel { get { return Attributes[0]; } }

    /// <summary>
    /// The ship speed level, controls the Max Speed of a ship
    /// </summary>
    public int ShipSpeedLevel { get { return Attributes[1]; } }

    /// <summary>
    /// The ship acceleration level, controls the accelrate ability of a ship
    /// </summary>
    public int ShipEngineLevel { get { return Attributes[2]; } }

    /// <summary>
    /// The ship helm wheel levell, controls the turning speed of a ship
    /// </summary>
    public int ShipRudderLevel { get { return Attributes[3]; } }
    #endregion

    #region Cannon Level Attributes
    /// <summary>
    /// The ship cannon level, controls the power of the cannon ball
    /// </summary>
    public int CannonPowerLevel { get { return Attributes[4]; } }

    /// <summary>
    /// The ship cannon range level, controls the range of the cannon ball
    /// </summary>
    public int CannonRangeLevel { get { return Attributes[5]; } }

    /// <summary>
    /// The ship cannon speed level, controls the fly speed of the cannon ball
    /// </summary>
    public int CannonSpeedLevel { get { return Attributes[6]; } }

    /// <summary>
    /// The ship cannon shoot level, controls the number of cannon balls of one shot
    /// </summary>
    public int CannonShootLevel { get { return Attributes[7]; } }
    #endregion

    #region Missile Level Attributes
    /// <summary>
    /// The ship missile power level, controls the power of the missile
    /// </summary>
    public int MissilePowerLevel { get { return Attributes[8]; } }

    /// <summary>
    /// The ship missile speed level, controls the fly speed of the missile
    /// </summary>
    public int MissileSpeedLevel { get { return Attributes[9]; } }

    /// <summary>
    /// The ship missile time level, controls the fly time of the missile
    /// </summary>
    public int MissileTimeLevel { get { return Attributes[10]; } }

    /// <summary>
    /// The ship missile turn level, controls the turning speed of the missile
    /// </summary>
    public int MissileTurnLevel { get { return Attributes[11]; } }
    #endregion

    //Ship All Levels
    public int[] Attributes;

    public ShipAttributes(int[] attributes)
    {
        //Set Attributes
        Attributes = attributes;
    }

    public bool LevelUp(int attributeId)
    {
        if (attributeId < 0 || attributeId > 11)
        {
            //Attribute ID out of range
            return false;
        }

        //Level Max
        if (Attributes[attributeId] < 0 || Attributes[attributeId] >= 2)
        {
            //Level Max or Level Error
            return false;
        }

        Attributes[attributeId]++;
        return true;
    }
}
