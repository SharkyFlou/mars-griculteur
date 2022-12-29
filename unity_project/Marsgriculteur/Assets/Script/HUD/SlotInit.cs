using UnityEngine;
using TMPro;
using game;


/// <summary>
/// La classe <c>SlotInit</c> permet d'initialiser les slots à afficher dans les inventaires.
/// Elle possède les attributs suivant : item, qttSlot, panelInfosVente, reafficheInv.
/// </summary>
public class SlotInit : MonoBehaviour
{
    public BasicItem item;
    public int qttSlot;

    public Transform panelInfosVente;

//        private ActivePanel reafficheInv;

    /// <summary>
    /// La méthode <c>OnMouseDown</c> permet d'initialiser les slots suivant l'inventaire.
    /// </summary>
    private void OnMouseDown()
    {
        //CreateAllSeedPlant.mainInventory.SubstractFromInventory(item, 1);
        //Debug.Log(item.getId());
        //Debug.Log(qttSlot);

        //check if item=seed, sinon pas possible de le planter
        //seed = 1 a 100
        if (panelInfosVente != null)
        {
            if (this.transform.root.name == "Canvas Shop")
            {
                if (item.getId() is > 0 and < 101)
                {
                    // Prix de la graine dans le slot.
                    int price = GameObject.Find("marketBase").GetComponent<Market>().getLastPriceSeed(((Seed)item).getTypePlante());
                    TextMeshProUGUI[] texts = this.transform.root.GetComponentsInChildren<TextMeshProUGUI>();

                    if (this.transform.root.GetComponentInChildren<InventoryPanel>().moneyText.GetComponent<Game>().money >= price
                        && ((CreateAllSeedPlant.mainInventory.getCurrentWeight() + item.getWeight()) <= CreateAllSeedPlant.mainInventory.getWeightMax()))
                    {
                        CreateAllSeedPlant.mainInventory.addToInventory(item, 1, CreateAllSeedPlant.mainInventory.getInventory());
                        this.transform.root.GetComponentInChildren<InventoryPanel>().moneyText.GetComponent<Game>().SubsMoney(price);

                        //affiche le message "achat successful"
                        foreach (TextMeshProUGUI text in texts)
                        {
                            if (text.name == "TextSeed")
                            {
                                text.text = "Vous avez obtenu une graine de " + item.getName();
                            }
                        }
                    }
                    else
                    {
                        //affiche le message "achat successful"
                        foreach (TextMeshProUGUI text in texts)
                        {
                            if (text.name == "TextSeed")
                            {
                                text.text = "";
                            }
                        }
                    }


                }
            }
            else if (this.transform.root.name == "Canvas Market")
            {
                if (item.getId() is > 100 and <= 200)
                {
                    BasicPlant itemplante = (BasicPlant)item;
                    this.transform.root.GetComponentInChildren<SellScript>().changePlant(itemplante.getTypePlante());
                    this.transform.root.GetComponentInChildren<SellScript>().changeMaxValue(qttSlot);
                    this.transform.root.GetComponentInChildren<SellScript>().slider.interactable = true;
                }
            }
            else if (this.transform.root.name == "Canvas Plant Seed" && (item.getId() is > 0 and < 101))
            {
                //panelInfosVente.GetComponent<GerePlant>().sendInfoClick(item, qttSlot);
                this.transform.root.GetComponentInChildren<GerePlant>().StockedPlot.planteGraine(item);
                this.transform.root.GetComponentInChildren<OpenCanvas>().inverseAffichage();
            }


        }


    }

    /// <summary>
    /// La méthode <c>af</c> permet d'afficher les slots, en vrérifiant s'ils sont bien présent dans l'inventaire du joueur.
    /// </summary>
    /// <param name="deuxInvs">les inventaires</param>
    /// <param name="isStorage"></param>
    public void af(ActivePanel[] deuxInvs, bool isStorage)
    {
        foreach (ActivePanel ap in deuxInvs)
        {
            /* if (isStorage)
            {
                if (ap.panelAvecInfos.name == "PanelStorage")
                {
                    ap.Affiche();
                }
            }
            else
            {
                if ((ap.panelAvecInfos.name == "PanelInvToStore"))
                {
                    ap.Affiche();
                }
            } */
            ap.Affiche();


        }
    }


}