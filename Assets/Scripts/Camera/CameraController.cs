using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Player Ship
    private GameObject playerShip;

    //Screen Border to move camera
    private float borderTop = 6.0f;
    private float borderBottom = -6.0f;
    private float borderLeft = -10.0f;
    private float borderRight = 10.0f;

    // Use this for initialization
    void Start()
    {
        //Get Player
        playerShip = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //Get Ship Position
        var currentPosition = playerShip.transform.position;

        //Get Current Speed
        var currentSpeed = playerShip.GetComponent<ShipController>().CurrentSpeed;

        //Set Horizontal and Vertical Speed
        float horizontalSpeed = 0.0f;
        float verticalSpeed = 0.0f;

        //Enter left or right border
        if ((currentPosition.x - transform.position.x <= borderLeft) || (currentPosition.x - transform.position.x >= borderRight))
        {
            //Get Player transform
            var currentTransform = playerShip.transform.rotation.eulerAngles.y;

            //Calculate Horizontal Speed
            horizontalSpeed = currentSpeed * Mathf.Sin(currentTransform / 180 * Mathf.PI);
        }

        //Enter top or buttom border
        if ((currentPosition.z - transform.position.z <= borderBottom) || (currentPosition.z - transform.position.z >= borderTop))
        {
            //Get Player transform
            var currentTransform = playerShip.transform.rotation.eulerAngles.y;

            //Calculate Horizontal Speed
            verticalSpeed = currentSpeed * Mathf.Cos(currentTransform / 180 * Mathf.PI);
        }

        transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime, 0.0f, verticalSpeed * Time.deltaTime), Space.World);
    }
}
