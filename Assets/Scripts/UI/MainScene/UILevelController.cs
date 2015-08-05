using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UILevelController : MonoBehaviour
{
    public GameObject MainUI;

    public Text Description;

    public Text Title;

    public Text Cost;

    public Text Coin;

    public GameObject Player;

    public GameObject IconPanel;

    //Get Current Selected Icon
    private int currentSelected;

    public void OnEnable()
    {
        //Selected the first child
        IconPanel.GetComponentInChildren<Button>().onClick.Invoke();

        //Display Coin
        DisplayCoin();

        //Display Levels
        DisplayLevel();
    }

    public void DisplayLevel()
    {
        //GetLevels
        var levels = Player.GetComponent<ShipController>().GetShipLevel();

        //Get Buttons
        var buttons = IconPanel.GetComponentsInChildren<Button>();

        foreach (var btn in buttons)
        {
            int skillID = Int32.Parse(btn.image.sprite.name);

            btn.GetComponentInChildren<Text>().text = (levels[skillID] + 1).ToString();
        }
    }

    public void DisplayCoin()
    {
        //Display Coin
        Coin.text = Player.GetComponent<PlayerController>().Coin.ToString();
    }

    public void Selected(GameObject button)
    {
        var outLines = IconPanel.GetComponentsInChildren<Outline>();

        foreach (var outLine in outLines)
        {
            outLine.enabled = false;
        }

        button.GetComponent<Outline>().enabled = true;
    }

    public void SelectIcon(int iconNumber)
    {
        var level = Player.GetComponent<ShipController>().GetShipLevel()[iconNumber];

        //Set Title
        Title.text = Data.ShipAttributeData[iconNumber.ToString() + level.ToString()].AttributeName;

        //Set Description
        Description.text = Data.ShipAttributeData[iconNumber.ToString() + level.ToString()].AttributeDescription;

        //Set Cost
        if (level == 2)
        {
            Cost.text = "Level Max";
        }
        else
        {
            Cost.text = Data.ShipAttributeData[iconNumber.ToString() + level.ToString()].LevelUpCost.ToString();
        }

        currentSelected = iconNumber;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        MainUI.SetActive(true);
        //Resume game
        Time.timeScale = 1;
    }

    public void LevelUp()
    {
        if (currentSelected >= 0 && currentSelected <= 11)
        {
            //Get Skill Level
            var level = Player.GetComponent<ShipController>().GetShipLevel()[currentSelected];

            //If Level Max
            if (level == 2)
            {
                //Level Max Todo: Add Message
                return;
            }

            //Calculate if coin is sufficient
            if (Player.GetComponent<PlayerController>().Coin < Data.ShipAttributeData[currentSelected.ToString() + level.ToString()].LevelUpCost)
            {
                //Not sufficient Todo: Add Message
                return;
            }

            var result = Player.GetComponent<PlayerController>().LevelUp(currentSelected, level);

            if (result)
            {
                //Success Todo: Add Message

                //refresh
                SelectIcon(currentSelected);
                DisplayLevel();
                DisplayCoin();
                return;
            }
            else
            {
                //Unsuccess Todo: Add Message
                return;
            }
        }
    }
}
