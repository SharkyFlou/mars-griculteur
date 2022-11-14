using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Notification : BasicItem
    {
        public int month;
        public int year;
        private List<string> content = new List<string>();

        private GameObject WindowNotif;

        public void AddNotif(string notif)
        {
            content.Add(notif);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                WindowNotif.SetActive(WindowNotif.activeSelf);
            }
        }
    }
}


