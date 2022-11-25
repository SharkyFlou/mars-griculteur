using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace game
{
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

        //dès qu'on ouvre l'inventory on l'affiche , appele depuis player inventory
        public void WakeUp(Dictionary<EventInfo, int> dico)
        {
            slots = dico;

            if (slots.Count == 0)
            {
                Debug.Log("nbSlots est de : " + slots.Count);
                Debug.Log("ERROR, DICO VIDE");
            }

            else
            {
                Debug.Log("nbSlots est de : " + slots.Count);

                Debug.Log("LE DICTIONNAIRE EST: \n");
                foreach (KeyValuePair<EventInfo, int> kvp in this.slots)
                {
                    Debug.Log("item : " + kvp.Key.getName() + ", reste : " + kvp.Value);
                }
            }
            afficheInventory();
        }

        void afficheInventory()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                //on cree l'objet prefab slot
                GameObject slot = (GameObject)Instantiate(SlotNotif); //, new Vector3(1,1,0)

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i ##########################
                EventInfo itemOfSlot = slots.ElementAt(i).Key;
                int duree = slots.ElementAt(i).Value;

                List<string> target = new List<string>();
                string listeTarget;
                target = itemOfSlot.getTarget();
                listeTarget = target[0] + ", ";
                for (int j = 1; j < (target.Count - 1); j++)
                {
                    listeTarget += target[j];
                    listeTarget += ", ";
                }
                listeTarget += target[target.Count - 1];

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE

                TextMeshProUGUI[] notif = slot.GetComponentsInChildren<TextMeshProUGUI>();
                notif[0].SetText(itemOfSlot.namee);
                notif[1].SetText(itemOfSlot.description);
                notif[2].SetText(listeTarget);

                //on dit que son parent est le Grid Layout Group PANEL NOTIF
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            }

        }
    }
}
