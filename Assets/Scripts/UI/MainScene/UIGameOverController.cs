using UnityEngine;
using System.Collections;

public class UIGameOverController : MonoBehaviour
{
    public void Replay()
    {
        Application.LoadLevel(1);
    }

    public void Menu()
    {
        Application.LoadLevel(0);
    }
}
