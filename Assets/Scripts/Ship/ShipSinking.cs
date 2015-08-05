using UnityEngine;
using System.Collections;

public class ShipSinking : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Sinking
        transform.Translate(Vector3.down * Time.deltaTime, Space.World);
    }
}
