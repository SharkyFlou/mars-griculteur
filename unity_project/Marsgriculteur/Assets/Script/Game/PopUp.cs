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
    /// <summary>
    /// La classe <c>PopUp</c> permet d'afficher une petite notification quand le joueur n'a pas exemple plus d'argent.
    /// Elle possède 3 attributs : text, coroutine, isExecuting
    /// </summary>
    public class PopUp : MonoBehaviour
    {
        
        public TextMeshProUGUI text;

        public IEnumerator coroutine = null;

        private bool isExecuting = false;

        private IEnumerator setMessage(string message)
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

        public void message(string msg)
        {
            // Quand le gameObject qui a commence un coroutine (avec StartCouroutine) est désactivé (SetActive(fals)) tous les coroutine ne exécution s'arrête
            // Ainsi cela permet à coupé un affichage actuelle et commencer le nouveau lors d'appels à intervalle < 3s
            coroutine = setMessage(msg);
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

