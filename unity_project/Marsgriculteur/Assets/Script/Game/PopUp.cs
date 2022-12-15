using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace game
{
    public class PopUp : MonoBehaviour
    {
        
        public TextMeshProUGUI text;

        public IEnumerator coroutine = null;

        private bool isExecuting = false;

        public IEnumerator message(string message)
        {
            
            text.SetText(message);
            this.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            if (isExecuting)
            {
                this.gameObject.SetActive(false);
                isExecuting = false;
            }
        }

        public void startCoroutine(string msg)
        {
            coroutine = message(msg);
            if (isExecuting)
                this.gameObject.SetActive(false);
            if (!this.gameObject.activeSelf)
                this.gameObject.SetActive(true);
            isExecuting = true;
            StartCoroutine(coroutine);
        }

        void Start()
        {

        }
    }
}

