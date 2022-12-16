using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

namespace game
{
    /// <summary>
    /// La classe <c>NotifPanel</c> s'occupe d'ouvrir la fen�tre qui contient les notifications (et de la pr�remplir)
    /// Elle poss�de 4 attributs : PanelInventory, PanelNotif, notif et dico (un dictionnaire qui contient les �v�nements)
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
        /// La m�thode <c>Start</c> est utilis�e pour le d�marrage. �tant donn� que Start n'est appel�e qu'une seule fois, elle permet d'initialiser les �l�ments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent �tre configur�s qu'imm�diatement avant utilisation.
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
        /// La m�thode <c>OpenPanel</c> permet d'ouvrir ou de fermer la fen�tre
        /// </summary>
        public void OpenPanel()
        {
            if (!PanelInventory.activeSelf)
            {
                PanelNotif.SetActive(!PanelNotif.activeSelf);
            }
        }
    }
}
