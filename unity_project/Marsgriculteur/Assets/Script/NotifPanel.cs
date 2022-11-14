using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Panel : MonoBehaviour
    {
        public GameObject NotifPanel;
        public Dictionary<EventInfo, int> Events = new Dictionary<EventInfo, int>();

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
}
