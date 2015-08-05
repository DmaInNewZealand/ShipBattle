using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMainController : MonoBehaviour
{
    //UI Object
    public GameObject LevelUp;
    public GameObject GameOver;

    //Main Menu Text
    public Text SpeedTxt;

    public Text HpTxt;

    public Text CoinTxt;

    public GameObject VirtualPad;

    //Player
    public GameObject Player;

    public void Awake()
    {
        Player.GetComponent<ShipController>().Dead += UIMainController_Dead;

        //Do not display virtual pad on standalone
#if UNITY_STANDALONE
                VirtualPad.SetActive(false);
#endif
    }

    //Player Dead
    void UIMainController_Dead(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
        GameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Update Txt
        SpeedTxt.text = Player.GetComponent<ShipController>().CurrentSpeed.ToString();
        HpTxt.text = Player.GetComponent<ShipController>().CurrentHp.ToString();
        CoinTxt.text = Player.GetComponent<PlayerController>().Coin.ToString();
    }

    public void OpenLevelUp()
    {
        gameObject.SetActive(false);
        LevelUp.SetActive(true);

        //Pause game
        Time.timeScale = 0;
    }
}
