using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using game;
using TMPro;

namespace game
{
    public class GerePlant : MonoBehaviour
    {
        public Inventory inventoryFunctions;
        public ActivePanel reafficheInv;

        /*     [SerializeField]
         */
        public PlotEvents StockedPlot;


        private BasicItem stockedItem;
        private int stockedQtt;

        //sealed == FINAL en java
        private int MAX_STOCKED_QTT = 20;

        //appelee par le click sur le slot qu'on veut planter (seulement de type seed)
        public void sendInfoClick(BasicItem item, int qtt)
        {
            stockedItem = item;
            stockedQtt = qtt;

            Transform[] goInactive = this.GetComponentsInChildren<Transform>();

            //traite tous les enfants de panelPlot, permet de planter
            foreach (Transform go in goInactive)
            {
                //Debug.Log(go.name);
                if (go.name == "TextItemSelected")
                {
                    go.GetComponent<TextMeshProUGUI>().text = "Vous avez choisi : " + item.getName().ToString();

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
                    go.GetComponent<Button>().onClick.AddListener(Soustraits); //elimine le nb choisi de graines a planter 
                    go.GetComponent<Button>().onClick.AddListener(StockedPlot.planteGraine); //doit appeler la fonction plategraine de PlotEvents
                                                                                             //@@@@@@@@@@@@@@@@@@@@@@@ ici on peut ajouter directement le enumTypePlant pour planteGraine @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                                                                                             //NE PAS AJOUTER () A LA FONCTION, SINON ON ENVOIE LE RESULTAT
                }
            }
        }

        //public void Soustrait(BasicItem item, int qtt)
        //{
        //    inventoryFunctions.SubstractFromInventory(item, qtt/2);
        //    inventoryFunctions.displayInventory();
        //}

        public void Soustraits()
        {
            //IMPERATIF d'utiliser CreateAllSeedPlant.mainInventory.getInventory(), sinon on travaille avec un inventory qui est VIDE COMPLETEMENT
            //Debug.Log(CreateAllSeedPlant.mainInventory.isDicoVide());

            //si le dico n'est pas vide
            if (!CreateAllSeedPlant.mainInventory.isDicoVide())
            {
                //on soustrait au item du dico la qtt voulue
                inventoryFunctions.SubstractFromInventory(getStockedItem(), getStockedQtt(), CreateAllSeedPlant.mainInventory.getInventory());
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
