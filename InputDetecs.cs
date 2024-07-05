using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetect : MonoBehaviour
{
    public GameObject Cards_panel;
public void SetActive() {

        if(!Cards_panel.activeSelf) {
            Cards_panel.SetActive(true);
        } else {
            Cards_panel.SetActive(false);
    }
}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
        SetActive();
        }
    }
}
