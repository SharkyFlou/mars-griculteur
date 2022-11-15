using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifPanel : MonoBehaviour
{
    public GameObject PanelNotif;
  //  public GameObject NotifInventory;


    void Start()
    {
        PanelNotif.SetActive(false);
       // NotifInventory.SetActive(false);

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

        //l'idee est d'ouvrir avec une fonction le panelInventory, une le panelNews, etc etc
        //si possible faire avec le nom bouton, comme ça on utilise une seule fonction
        /* public void OpenInventory(){
            if (NotifInventory.activeSelf == false)
            {
                NotifInventory.SetActive(true);
            }
            else
            {
                NotifInventory.SetActive(false);
            }
        } */
}
