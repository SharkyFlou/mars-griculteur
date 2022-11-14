using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifPanel : MonoBehaviour
{
    public GameObject PanelNotif;

    void Start()
    {
        PanelNotif.SetActive(false);
    }

    public void OpenPanel()
    {
        if (PanelNotif.activeSelf == false)
        {
            PanelNotif.SetActive(true);

        }
        else
        {
            PanelNotif.SetActive(false);
        }
        
    }
}
