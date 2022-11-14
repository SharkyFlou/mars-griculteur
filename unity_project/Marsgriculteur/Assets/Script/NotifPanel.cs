using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject NotifPanel;

    void Start()
    {
        NotifPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        if (NotifPanel.activeSelf == false)
        {
            NotifPanel.SetActive(true);
        }
        else
        {
            NotifPanel.SetActive(false);
        }
        
    }
}
