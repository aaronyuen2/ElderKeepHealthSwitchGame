using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaryCounter : MonoBehaviour
{
    public int n=0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Speed: " + n.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        n++;
    }
}
