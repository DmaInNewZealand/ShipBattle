using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Data
{
    /// <summary>
    /// Ship Attribute Data
    /// </summary>
    public static Dictionary<string, ShipAttributeData> ShipAttributeData = new Dictionary<string, ShipAttributeData>();

    //TODO: Generate Data from Excel Files
    static Data()
    {
        ShipAttributeData.Add("00", new ShipAttributeData() { AttributeID = 0, AttributeLevel = 0, AttributeName = "ShipArmorLevel", AttributeDescription = "Ship MaxHp: 100", LevelUpCost = 3, AttributeValue = 100 });
        ShipAttributeData.Add("01", new ShipAttributeData() { AttributeID = 0, AttributeLevel = 1, AttributeName = "ShipArmorLevel", AttributeDescription = "Ship MaxHp: 300", LevelUpCost = 8, AttributeValue = 300 });
        ShipAttributeData.Add("02", new ShipAttributeData() { AttributeID = 0, AttributeLevel = 2, AttributeName = "ShipArmorLevel", AttributeDescription = "Ship MaxHp: 500", LevelUpCost = 15, AttributeValue = 500 });
        ShipAttributeData.Add("10", new ShipAttributeData() { AttributeID = 1, AttributeLevel = 0, AttributeName = "ShipSpeedLevel", AttributeDescription = "Ship Max Speed: 1.8", LevelUpCost = 3, AttributeValue = 1.8f });
        ShipAttributeData.Add("11", new ShipAttributeData() { AttributeID = 1, AttributeLevel = 1, AttributeName = "ShipSpeedLevel", AttributeDescription = "Ship Max Speed: 2.7", LevelUpCost = 8, AttributeValue = 2.7f });
        ShipAttributeData.Add("12", new ShipAttributeData() { AttributeID = 1, AttributeLevel = 2, AttributeName = "ShipSpeedLevel", AttributeDescription = "Ship Max Speed: 3.6", LevelUpCost = 15, AttributeValue = 3.6f });
        ShipAttributeData.Add("20", new ShipAttributeData() { AttributeID = 2, AttributeLevel = 0, AttributeName = "ShipEngineLevel", AttributeDescription = "Ship Acceleration: 0.5", LevelUpCost = 3, AttributeValue = 0.5f });
        ShipAttributeData.Add("21", new ShipAttributeData() { AttributeID = 2, AttributeLevel = 1, AttributeName = "ShipEngineLevel", AttributeDescription = "Ship Acceleration: 0.75", LevelUpCost = 8, AttributeValue = 0.75f });
        ShipAttributeData.Add("22", new ShipAttributeData() { AttributeID = 2, AttributeLevel = 2, AttributeName = "ShipEngineLevel", AttributeDescription = "Ship Acceleration: 1.0", LevelUpCost = 15, AttributeValue = 1.0f });
        ShipAttributeData.Add("30", new ShipAttributeData() { AttributeID = 3, AttributeLevel = 0, AttributeName = "ShipRudderLevel", AttributeDescription = "Ship Turn Speed: 15", LevelUpCost = 3, AttributeValue = 15 });
        ShipAttributeData.Add("31", new ShipAttributeData() { AttributeID = 3, AttributeLevel = 1, AttributeName = "ShipRudderLevel", AttributeDescription = "Ship Turn Speed: 30", LevelUpCost = 8, AttributeValue = 30 });
        ShipAttributeData.Add("32", new ShipAttributeData() { AttributeID = 3, AttributeLevel = 2, AttributeName = "ShipRudderLevel", AttributeDescription = "Ship Turn Speed: 45", LevelUpCost = 15, AttributeValue = 45 });
        ShipAttributeData.Add("40", new ShipAttributeData() { AttributeID = 4, AttributeLevel = 0, AttributeName = "CannonPowerLevel", AttributeDescription = "Cannon Power: 50", LevelUpCost = 3, AttributeValue = 50 });
        ShipAttributeData.Add("41", new ShipAttributeData() { AttributeID = 4, AttributeLevel = 1, AttributeName = "CannonPowerLevel", AttributeDescription = "Cannon Power: 65", LevelUpCost = 8, AttributeValue = 65 });
        ShipAttributeData.Add("42", new ShipAttributeData() { AttributeID = 4, AttributeLevel = 2, AttributeName = "CannonPowerLevel", AttributeDescription = "Cannon Power: 100", LevelUpCost = 15, AttributeValue = 100 });
        ShipAttributeData.Add("50", new ShipAttributeData() { AttributeID = 5, AttributeLevel = 0, AttributeName = "CannonRangeLevel", AttributeDescription = "Cannon Shooting Range: 12", LevelUpCost = 3, AttributeValue = 12 });
        ShipAttributeData.Add("51", new ShipAttributeData() { AttributeID = 5, AttributeLevel = 1, AttributeName = "CannonRangeLevel", AttributeDescription = "Cannon Shooting Range: 20", LevelUpCost = 8, AttributeValue = 20 });
        ShipAttributeData.Add("52", new ShipAttributeData() { AttributeID = 5, AttributeLevel = 2, AttributeName = "CannonRangeLevel", AttributeDescription = "Cannon Shooting Range: 30", LevelUpCost = 15, AttributeValue = 30 });
        ShipAttributeData.Add("60", new ShipAttributeData() { AttributeID = 6, AttributeLevel = 0, AttributeName = "CannonSpeedLevel", AttributeDescription = "Cannonball Flying Speed: 6", LevelUpCost = 3, AttributeValue = 6 });
        ShipAttributeData.Add("61", new ShipAttributeData() { AttributeID = 6, AttributeLevel = 1, AttributeName = "CannonSpeedLevel", AttributeDescription = "Cannonball Flying Speed: 13", LevelUpCost = 8, AttributeValue = 13 });
        ShipAttributeData.Add("62", new ShipAttributeData() { AttributeID = 6, AttributeLevel = 2, AttributeName = "CannonSpeedLevel", AttributeDescription = "Cannonball Flying Speed: 24", LevelUpCost = 15, AttributeValue = 24 });
        ShipAttributeData.Add("70", new ShipAttributeData() { AttributeID = 7, AttributeLevel = 0, AttributeName = "CannonShootLevel", AttributeDescription = "One Shot Cannonball Count: 1", LevelUpCost = 3, AttributeValue = 1 });
        ShipAttributeData.Add("71", new ShipAttributeData() { AttributeID = 7, AttributeLevel = 1, AttributeName = "CannonShootLevel", AttributeDescription = "One Shot Cannonball Count: 2", LevelUpCost = 8, AttributeValue = 2 });
        ShipAttributeData.Add("72", new ShipAttributeData() { AttributeID = 7, AttributeLevel = 2, AttributeName = "CannonShootLevel", AttributeDescription = "One Shot Cannonball Count: 3", LevelUpCost = 15, AttributeValue = 3 });
        ShipAttributeData.Add("80", new ShipAttributeData() { AttributeID = 8, AttributeLevel = 0, AttributeName = "MissilePowerLevel", AttributeDescription = "Missile Power: 100", LevelUpCost = 3, AttributeValue = 100 });
        ShipAttributeData.Add("81", new ShipAttributeData() { AttributeID = 8, AttributeLevel = 1, AttributeName = "MissilePowerLevel", AttributeDescription = "Missile Power: 300", LevelUpCost = 8, AttributeValue = 300 });
        ShipAttributeData.Add("82", new ShipAttributeData() { AttributeID = 8, AttributeLevel = 2, AttributeName = "MissilePowerLevel", AttributeDescription = "Missile Power: 500", LevelUpCost = 15, AttributeValue = 500 });
        ShipAttributeData.Add("90", new ShipAttributeData() { AttributeID = 9, AttributeLevel = 0, AttributeName = "MissileSpeedLevel", AttributeDescription = "Missile Speed: 10", LevelUpCost = 3, AttributeValue = 10 });
        ShipAttributeData.Add("91", new ShipAttributeData() { AttributeID = 9, AttributeLevel = 1, AttributeName = "MissileSpeedLevel", AttributeDescription = "Missile Speed: 20", LevelUpCost = 8, AttributeValue = 20 });
        ShipAttributeData.Add("92", new ShipAttributeData() { AttributeID = 9, AttributeLevel = 2, AttributeName = "MissileSpeedLevel", AttributeDescription = "Missile Speed: 30", LevelUpCost = 15, AttributeValue = 30 });
        ShipAttributeData.Add("100", new ShipAttributeData() { AttributeID = 10, AttributeLevel = 0, AttributeName = "MissileTimeLevel", AttributeDescription = "Missile Fly Time: 10", LevelUpCost = 3, AttributeValue = 10 });
        ShipAttributeData.Add("101", new ShipAttributeData() { AttributeID = 10, AttributeLevel = 1, AttributeName = "MissileTimeLevel", AttributeDescription = "Missile Fly Time: 15", LevelUpCost = 8, AttributeValue = 15 });
        ShipAttributeData.Add("102", new ShipAttributeData() { AttributeID = 10, AttributeLevel = 2, AttributeName = "MissileTimeLevel", AttributeDescription = "Missile Fly Time: 20", LevelUpCost = 15, AttributeValue = 20 });
        ShipAttributeData.Add("110", new ShipAttributeData() { AttributeID = 11, AttributeLevel = 0, AttributeName = "MissileTurnLevel", AttributeDescription = "Missile Turn Speed: 60", LevelUpCost = 3, AttributeValue = 60 });
        ShipAttributeData.Add("111", new ShipAttributeData() { AttributeID = 11, AttributeLevel = 1, AttributeName = "MissileTurnLevel", AttributeDescription = "Missile Turn Speed: 120", LevelUpCost = 8, AttributeValue = 120 });
        ShipAttributeData.Add("112", new ShipAttributeData() { AttributeID = 11, AttributeLevel = 2, AttributeName = "MissileTurnLevel", AttributeDescription = "Missile Turn Speed: 180", LevelUpCost = 15, AttributeValue = 180 });
    }
}
