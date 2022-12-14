using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using static UnityEditor.Progress;

namespace game
{
    /// <summary>
    /// La classe <c>Notification</c> s'occupe d'afficher et supprimer les notifications.
    /// Elle possède 4 attributs : nextDay, SlotNotif, slotPanel et slots (un dictionnaire qui contient les événements)
    /// </summary>
    public class Notification : MonoBehaviour
    {
        //permet de prendre le dico notif
        public NextDay nextDay;

        //correspond au slot a initialiser
        public GameObject SlotNotif;
        //correspond au panel parent
        public Transform slotPanel;

        //dictionnaire des items pour remplir le inventory des notifs
        //si on ajoute un item on doit ajouter à ce dico pour l'afficher
        public Dictionary<EventInfo, int> slots = new Dictionary<EventInfo, int>();

        /// <summary>
        /// La méthode <c>clearInventoryDisplay</c> permet de supprimer les notifications
        /// </summary>
        public void clearInventoryDisplay()
        {
            foreach (Transform child in slotPanel)
                Destroy(child.gameObject);
        }

        /// <summary>
        /// La méthode <c>afficheInventory</c> permet d'afficher les notifications dans le panel
        /// </summary>
        public void afficheInventory()
        {
            clearInventoryDisplay();
            slots = NextDay.getInventoryNotif();

            for (int i = 0; i < slots.Count; i++)
            {
                //Debug.Log("Name = " + slots.ElementAt(i).Key.getName() + "Value = " + slots.ElementAt(i).Value);
                //on cree l'objet prefab slot
                GameObject slot = (GameObject)Instantiate(SlotNotif); //, new Vector3(1,1,0)

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i ##########################
                EventInfo itemOfSlot = slots.ElementAt(i).Key;
                int duree = slots.ElementAt(i).Value;

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE

                string target = itemOfSlot.getTarget();


                TextMeshProUGUI[] notif = slot.GetComponentsInChildren<TextMeshProUGUI>();
                notif[0].SetText(itemOfSlot.namee);
                notif[1].SetText(itemOfSlot.description);
                notif[2].text = target;

                //on dit que son parent est le Grid Layout Group PANEL NOTIF
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
