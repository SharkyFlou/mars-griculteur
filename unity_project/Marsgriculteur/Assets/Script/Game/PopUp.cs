using System.Collections;
using UnityEngine;
using TMPro;

namespace game
{
    /// <summary>
    /// La classe <c>PopUp</c> permet d'afficher une petite notification quand le joueur n'a pas exemple plus d'argent.
    /// Elle poss�de 3 attributs : text, coroutine, isExecuting.
    /// </summary>
    public class PopUp : MonoBehaviour
    {
        public TextMeshProUGUI text;

        public IEnumerator coroutine = null;

        private bool isExecuting = false;

        /// <summary>
        /// La m�thode <c>setMessage</c> permet de cr�er la notif avec le texte et la faire attendre 3 secondes
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>IEnumerator.</returns>
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

        /// <summary>
        /// Quand le gameObject qui a commence un coroutine (avec StartCouroutine) est d�sactiv� (SetActive(false)) tous les coroutines en ex�cution s'arr�tent
        /// Ainsi cela permet � couper un affichage actuel et commencer le nouveau lors d'appels � intervalle < 3s
        /// </summary>
        /// <param name="msg">le message</param>
        public void message(string msg)
        {
            coroutine = setMessage(msg);
            if (isExecuting)
                this.gameObject.SetActive(false);
            if (!this.gameObject.activeSelf)
                this.gameObject.SetActive(true);
            isExecuting = true;
            StartCoroutine(coroutine);
        }
    }
}

