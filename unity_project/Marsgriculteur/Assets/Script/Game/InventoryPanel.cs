using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

namespace game
{
    /// <summary>
    /// La classe <c>InventoryPanel</c> implémente l'interface <c>InventoryInterface</c>. Elle gère l'affichage des inventaires dans les panels.
    /// Elle possède un attribut slotPanel qui correspond au panel sur lequel va être affiché l'inventaire.
    /// </summary>
    public class InventoryPanel : MonoBehaviour, InventoryInterface
    {
        public Transform slotPanel;

        public Transform moneyText;

        //public TextMeshProUGUI textWeight;

        /// <summary>
        /// Le constructeur <c>InventoryPanel</c> prend en référence le parent pour pouvoir afficher l'inventaire. C'est utile pour supprimer les slots.
        /// </summary>
        /// <param name="slotPanel">Le panel Transform parent.</param>
        public InventoryPanel(Transform slotPanel)
        {
            this.slotPanel = slotPanel;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="InventoryPanel"/>.
        /// </summary>
        /// <param name="slotPanel">le panel.</param>
        /// <param name="panelAvecInfos">Le panel avec les infos.</param>
        public InventoryPanel(Transform slotPanel, Transform panelAvecInfos)
        {
            this.slotPanel = slotPanel;
        }

        /// <summary>
        /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
        /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
        /// Pour notre cas elle permet d'afficher les panels.
        /// </summary>
        public void Start()
        {
            if (this.transform.root != null)
            {
                if (this.transform.root.name == "Canvas Inventory")
                {
                    afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), slotPanel);
                    return;
                }
                if (this.transform.root.name == "Canvas Plant Seed")
                {
                    afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), slotPanel, false);
                    return;
                }
                if (this.transform.root.name == "Canvas Market")
                {
                    slotPanel.transform.localScale = new Vector3(0.8f, 0.8f, 1);

                    slotPanel.transform.GetComponent<RectTransform>().offsetMax = new Vector2(slotPanel.transform.parent.GetComponent<RectTransform>().rect.width / 3, slotPanel.transform.GetComponent<RectTransform>().offsetMin.y);

                    afficheInventory(CreateAllSeedPlant.mainInventory.getInventory(), slotPanel, true);
                    return;
                }
                if (this.transform.root.name == "Canvas Shop")
                {
                    afficheInventory(CreateAllSeedPlant.shopInv.getInventory(), slotPanel);
                    TextMeshProUGUI[] texts = slotPanel.transform.root.GetComponentsInChildren<TextMeshProUGUI>();
                    foreach (TextMeshProUGUI text in texts)
                    {
                        if (text.name == "TextSeed")
                        {
                            text.text = " ";
                        }
                    }
                    return;
                }
            }



        }
        /// <summary>
        /// La méthode <c>afficheInventory</c> permet de choisir où afficher l'inventaire et de l'afficher.
        /// </summary>
        /// <param name="dico">Le dictionnaire qui contient les items.</param>
        public void afficheInventory(Dictionary<BasicItem, int> dico)
        {
            clearInventoryDisplay();

            Debug.Log("Taille inventaire : " + dico.Count().ToString());
            for (int i = 0; i < dico.Count; i++)
            {
                //on cree l'objet prefab slot
                GameObject slot = InventorySlot.createSlot();

                //slot = ajouteBoxCollider(slot);

                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i
                BasicItem itemOfSlot = dico.ElementAt(i).Key;
                int qttDuSlot = dico.ElementAt(i).Value;

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                foreach (Image imgS in imgDuSlot)
                {
                    if (imgS.gameObject.transform.parent != null)
                    {
                        imgS.sprite = itemOfSlot.getSprite();
                        imgS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
                }

                TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                foreach (TextMeshProUGUI text in qtt)
                {
                    if (text.gameObject.transform.parent != null)
                    {
                        text.SetText(qttDuSlot.ToString());
                    }
                }

                //Ceci remplit chaque slot avec un item, on pourra l'utiliser pour vente/plantation...
                //ajoute en attribut au script SlotInit le bon item
                slot.GetComponent<SlotInit>().item = itemOfSlot;
                slot.GetComponent<SlotInit>().qttSlot = qttDuSlot;

                //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                slot.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        /// <summary>
        /// La méthode surchargée <c>afficheInventory</c> permet aussi de choisir où afficher l'inventaire et de l'afficher.
        /// Mais il y a un paramètre <paramref name="panelAInitialiser"/> en plus pour pouvoir avoir des informations du panel, ex: lorsqu'on vend, on a besoin de connaître le prix et la quantité.
        /// </summary>
        /// <param name="dico">Le dictionnaire qui contient les items</param>
        /// <param name="panelAInitialiser">Le panel avec les informations utiles</param>
        public void afficheInventory(Dictionary<BasicItem, int> dico, Transform panelAInitialiser)
        {
            clearInventoryDisplay();

            for (int i = 0; i < dico.Count; i++)
            {

                //on cree l'objet prefab slot
                GameObject slot = InventorySlot.createSlot();


                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i
                Seed salut = new Seed();

                BasicItem itemOfSlot = dico.ElementAt(i).Key;
                int slotText;
                if (this.transform.root.name == "Canvas Shop")
                    slotText = GameObject.Find("marketBase").GetComponent<Market>().getLastPriceSeed(((Seed)dico.ElementAt(i).Key).getTypePlante());
                else
                    slotText = dico.ElementAt(i).Value;


                //ceci affiche tous les weights de inventory

                //pour remplir les infos a l'interieur du slot
                //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                foreach (Image imgS in imgDuSlot)
                {
                    if (imgS.gameObject.transform.parent != null)
                    {
                        imgS.sprite = itemOfSlot.getSprite();
                        imgS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
                }

                TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                foreach (TextMeshProUGUI text in qtt)
                {
                    if (text.gameObject.transform.parent != null)
                    {
                        if (this.transform.root.name == "Canvas Shop")
                            text.SetText(slotText.ToString() + "$");
                        else
                            text.SetText(slotText.ToString());
                    }
                }

                //Ceci remplit chaque slot avec un item, on pourra l'utiliser pour vente/plantation...
                //ajoute en attribut au script SlotInit le bon item
                slot.GetComponent<SlotInit>().item = itemOfSlot;
                if (panelAInitialiser != null)
                    slot.GetComponent<SlotInit>().panelInfosVente = panelAInitialiser;
                slot.GetComponent<SlotInit>().qttSlot = slotText;
                //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                slot.transform.SetParent(slotPanel);


                //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                slot.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        /// <summary>
        /// La méthode <c>afficheInventory</c> permet aussi de choisir où afficher l'inventaire et de l'afficher.
        /// Mais il y a un paramètre <paramref name="showAll"/> en plus pour pouvoir savoir si on les affiche tous (si on affiche que les graines ou tous).
        /// </summary>
        /// <param name="dico">Le dictionnaire qui contient les items.</param>
        /// <param name="panelAInitialiser">Le panel avec les informations utiles.</param>
        /// <param name="showAll">Booléen pour savoir si on affiche tout l'inventaire.</param>
        public void afficheInventory(Dictionary<BasicItem, int> dico, Transform panelAInitialiser, bool showAll)
        {
            clearInventoryDisplay();

            for (int i = 0; i < dico.Count; i++)
            {
                //MOMENT DE REMPLIR LE SLOT
                //on prend la key/value du dico a la pos i
                BasicItem itemOfSlot = dico.ElementAt(i).Key;
                int slotText;
                if (!showAll)
                {
                    //Si SEED
                    if (itemOfSlot.getId() > 0 && itemOfSlot.getId() < 101)
                    {
                        //on cree l'objet prefab slot
                        GameObject slot = InventorySlot.createSlot();
                        if (this.transform.root.name == "Canvas Shop")
                            slotText = dico.ElementAt(i).Key.getPrice();
                        else
                            slotText = dico.ElementAt(i).Value;


                        //ceci affiche tous les weights de inventory

                        //pour remplir les infos a l'interieur du slot
                        //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                        Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                        foreach (Image imgS in imgDuSlot)
                        {
                            if (imgS.gameObject.transform.parent != null)
                            {
                                imgS.sprite = itemOfSlot.getSprite();
                                imgS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            }
                        }

                        TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                        foreach (TextMeshProUGUI text in qtt)
                        {
                            if (text.gameObject.transform.parent != null)
                            {
                                if (this.transform.root.name == "Canvas Shop")
                                    text.SetText(slotText.ToString() + "$");
                                else
                                    text.SetText(slotText.ToString());
                            }
                        }

                        //Ceci remplit chaque slot avec un item, on pourra l'utiliser pour vente/plantation...
                        //ajoute en attribut au script SlotInit le bon item
                        slot.GetComponent<SlotInit>().item = itemOfSlot;
                        if (panelAInitialiser != null)
                            slot.GetComponent<SlotInit>().panelInfosVente = panelAInitialiser;
                        slot.GetComponent<SlotInit>().qttSlot = slotText;
                        //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                        slot.transform.SetParent(slotPanel);


                        //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                        // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                        slot.transform.localPosition = new Vector3(0, 0, 0);
                    }
                }
                else
                {
                    //SI PLANTE
                    if (itemOfSlot.getId() > 100 && itemOfSlot.getId() < 201)
                    {
                        //on cree l'objet prefab slot
                        GameObject slot = InventorySlot.createSlot();
                        if (this.transform.root.name == "Canvas Shop")
                            slotText = dico.ElementAt(i).Key.getPrice();
                        else
                            slotText = dico.ElementAt(i).Value;


                        //ceci affiche tous les weights de inventory

                        //pour remplir les infos a l'interieur du slot
                        //IL FAUT FAIRE GET COMPONENTS ET PARCOURIR TAB, PARENT[0] FAIRE GAFFE
                        Image[] imgDuSlot = slot.GetComponentsInChildren<Image>();
                        foreach (Image imgS in imgDuSlot)
                        {
                            if (imgS.gameObject.transform.parent != null)
                            {
                                imgS.sprite = itemOfSlot.getSprite();
                                imgS.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            }
                        }

                        TextMeshProUGUI[] qtt = slot.GetComponentsInChildren<TextMeshProUGUI>();
                        foreach (TextMeshProUGUI text in qtt)
                        {
                            if (text.gameObject.transform.parent != null)
                            {
                                if (this.transform.root.name == "Canvas Shop")
                                    text.SetText(slotText.ToString() + "$");
                                else
                                    text.SetText(slotText.ToString());
                            }
                        }

                        //Ceci remplit chaque slot avec un item, on pourra l'utiliser pour vente/plantation...
                        //ajoute en attribut au script SlotInit le bon item
                        slot.GetComponent<SlotInit>().item = itemOfSlot;
                        if (panelAInitialiser != null)
                            slot.GetComponent<SlotInit>().panelInfosVente = panelAInitialiser;
                        slot.GetComponent<SlotInit>().qttSlot = slotText;
                        //on dit que son parent est le Grid Layout Group PANEL INVENTORY
                        slot.transform.SetParent(slotPanel);


                        //CHANGER LA TAILLE APRES DAVOIR AJOUTE AU PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        slot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                        // Met la position z à 0 pour pas qu'il sort du render de la caméra au dézoom
                        slot.transform.localPosition = new Vector3(0, 0, 0);
                    }
                }
            }
        }

        /// <summary>
        /// La méthode <c>updateWeight</c> permet de mettre à jour la capacité de l'inventaire.
        /// </summary>
        /// <param name="text">La zone de texte où sera affiché la capacité de l'inventaire.</param>
        public void updateWeight(Transform text)
        {
            text.GetComponent<TextMeshProUGUI>().SetText("Weight : " + CreateAllSeedPlant.mainInventory.getCurrentWeight().ToString() + " / " + CreateAllSeedPlant.mainInventory.getWeightMax().ToString() + " kg");
            Debug.Log("update le texte");
        }

        /// <summary>
        /// La méthode <c>clearInventoryDisplay</c> permet de supprimer les slots de l'inventaire.
        /// </summary>
        public void clearInventoryDisplay()
        {
            foreach (Transform child in slotPanel)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Cette méthode est juste là pour debug
        /// </summary>
        public void affiche()
        {
            Debug.Log(slotPanel.name);
        }

    }
}
