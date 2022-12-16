using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

namespace game
{
    /// <summary>
    /// La classe <c>NotifPanel</c> s'occupe d'ouvrir la fenêtre qui contient les notifications (et de la préremplir)
    /// Elle possède 4 attributs : PanelInventory, PanelNotif, notif et dico (un dictionnaire qui contient les événements)
    /// </summary>
    public class NotifPanel : MonoBehaviour
    {
        public GameObject PanelInventory;
        public GameObject PanelNotif;
        public Notification notif;
        public Dictionary<EventInfo, int> dico = new Dictionary<EventInfo, int>();
        public PopUp classePopup;
        public Transform render;

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas elle permet d'initialiser le panel des notifications (de le mettre invisible, etc).
        /// </summary>
        void Start()
        {
            PanelNotif.SetActive(false);

            dico = NextDay.getInventoryNotif();
            notif.afficheInventory();

            render.gameObject.SetActive(false);

        }

        /// <summary>
        /// La méthode <c>OpenPanel</c> permet d'ouvrir ou de fermer la fenêtre
        /// </summary>
        public void OpenPanel()
        {
            if (!PanelInventory.activeSelf)
                PanelNotif.SetActive(!PanelNotif.activeSelf);
        }
    }
}
