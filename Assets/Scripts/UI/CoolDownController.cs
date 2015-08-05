using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolDownController : MonoBehaviour
{
    //Skill CD
    public float CoolDownTime;

    // Update is called once per frame
    void Update()
    {
        var currFillAmount = gameObject.GetComponent<Image>().fillAmount;

        //If still in cd
        if (currFillAmount > 0)
        {
            //update current 
            currFillAmount = currFillAmount - Time.deltaTime / CoolDownTime;

            if(currFillAmount < 0)
            {
                currFillAmount = 0;
            }

            gameObject.GetComponent<Image>().fillAmount = currFillAmount;
        }
    }
}
