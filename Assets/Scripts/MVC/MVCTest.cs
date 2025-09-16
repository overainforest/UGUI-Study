using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainController.ShowMe();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            MainController.HideMe();
        }
    }
}
