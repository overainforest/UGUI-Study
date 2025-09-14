using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainPanel.ShowMe();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            MainPanel.HideMe();
        }
    }
}
