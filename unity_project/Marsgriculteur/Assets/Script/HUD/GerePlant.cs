using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;
using static UnityEditor.Progress;

namespace game
{
    public class GerePlant : MonoBehaviour
    {
        public Inventory inventoryFunctions;
        public ActivePanel reafficheInv;

        public PlotEvents StockedPlot;


        private BasicItem stockedItem;
        private int stockedQtt;

        //sealed == FINAL en java
        //private int MAX_STOCKED_QTT = 20;

        //ces deux fonctions suivantes ne seront plus utilisees; vu que la graine sera plantee et le click ferme le shop auto


        /* public void cleanAffichage()
        {
            stockedItem = null;
            stockedQtt = 0;
            Transform[] gos = this.GetComponentsInChildren<Transform>();

            //traite tous les enfants de panelPlot, permet de planter
            foreach (Transform go in gos)
            {
                //Debug.Log(go.name);
                if (go.name == "TextItemSelected")
                {
                    go.GetComponent<TextMeshProUGUI>().text = "Choisissez un item";

                }
                if (go.name == "ImageSeed")
                {
                    //Debug.Log("ok, image attribue");
                    //go.gameObject.SetActive(true);
                    go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Panel");
                }
                if (go.name == "ButtonOKPlant")
                {
                    //cela ajoute un evenement soustraits au click du button ButtonOKPlant
                    go.GetComponent<Button>().onClick.RemoveAllListeners(); //elimine le nb choisi de graines a planter 

                }
            }
        }


        //appelee par le click sur le slot qu'on veut planter (seulement de type seed)
        public void sendInfoClick(BasicItem item, int qtt)
        {

            stockedItem = item;
            stockedQtt = 1;

            Transform[] gos = this.GetComponentsInChildren<Transform>();

            //traite tous les enfants de panelPlot, permet de planter
            foreach (Transform go in gos)
            {
                //Debug.Log(go.name);
                if (go.name == "TextItemSelected")
                {
                    //go.GetComponent<TextMeshProUGUI>().text = "Vous avez choisi 1 graine de " + item.getName().ToString() + ". \n Sa croissance dure " + item.get + "cycles.";

                }
                if (go.name == "ImageSeed")
                {
                    //Debug.Log("ok, image attribue");
                    //go.gameObject.SetActive(true);
                    go.GetComponent<Image>().sprite = item.getSprite();
                }
                if (go.name == "ButtonOKPlant")
                {
                    //Debug.Log("ok, button attribue");
                    //go.GetComponent<Button>().onClick.AddListener(delegate { Soustrait(stockedItem, stockedQtt); });

                    //cela ajoute un evenement soustraits au click du button ButtonOKPlant
                    //go.GetComponent<Button>().onClick.AddListener(StockedPlot.planteGraine);
                    //go.GetComponent<Button>().onClick.AddListener(go.parent.parent.parent.GetComponentInChildren<openCanvas>().inverseAffichage); //doit appeler la fonction plategraine de PlotEvents

                }
            }

        }
 */
        public void Soustraits(BasicItem item, int qtt)
        {
            //IMPERATIF d'utiliser CreateAllSeedPlant.mainInventory.getInventory(), sinon on travaille avec un inventory qui est VIDE COMPLETEMENT
            //Debug.Log(CreateAllSeedPlant.mainInventory.isDicoVide());

            //si le dico n'est pas vide
            if (!CreateAllSeedPlant.mainInventory.isDicoVide())
            {
                //on soustrait au item du dico la qtt voulue
                inventoryFunctions.SubstractFromInventory(item, qtt, CreateAllSeedPlant.mainInventory.getInventory());
                //on reaffiche les elements
                reafficheInv.Affiche();
            }
        }

        public BasicItem getStockedItem()
        {
            return this.stockedItem;
        }

        public int getStockedQtt()
        {
            return this.stockedQtt;
        }


    }
}
