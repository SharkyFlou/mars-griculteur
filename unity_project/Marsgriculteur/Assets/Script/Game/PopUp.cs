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
        public OpenCanvas openCanvas;


        public IEnumerator message(string message)
        {
            text.SetText(message);
            openCanvas.inverseAffichage();
            yield return new WaitForSeconds(3);
            openCanvas.inverseAffichage();
        }

        void Start()
        {

        }
    }
}

