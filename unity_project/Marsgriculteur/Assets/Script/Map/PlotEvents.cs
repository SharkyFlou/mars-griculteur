using game;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// La classe <c>PlotEvents</c> permet de gérer la pousse, la récolte, etc, des plantes et des graines.
/// Elle possède les attributs suivants : plot_sprite, plot_sprite_highlite, seed_sprite, seed_sprite_grown, PlotSupervisor, InterfacePlantPanel,
/// hidesPanel, growthTime, growthStatus, plotImage, seedImage, plantedPlant, contientGraine, itemDansPlot, inventory, reafficheInvOnClick.
/// </summary>
public class PlotEvents : MonoBehaviour
{
    public bool isDesactive;
    
    public Sprite plot_sprite;
    public Sprite plot_sprite_highlite;
    private Sprite seed_sprite;
    private Sprite seed_sprite_grown;

    //references a d'autres objets
    public GameObject PlotSupervisor;
    public GameObject InterfacePlantPanel;
    public OpenCanvas hidesPanel;

    //pour ne pas verifier growthTime == growthStatus
    private int growthTime = -10;
    private int growthStatus = -1;

    private Transform plotImage;
    private Transform seedImage;
    private PlantedPlant plantedPlant = null;
    private bool contientGraine = false;
    private BasicItem itemDansPlot = null;
    //private int qtt = 0;

    public Inventory inventory;

    public ActivePanel reafficheInvOnClick;

    public ChangeTextError error;
    public OpenCanvas errorDislp;

    public BuyPlot buy;

    /// <summary>
    /// La méthode <c>Start</c> est utilisée pour le démarrage. Etant donné que Start n'est appelée qu'une seule fois, elle permet d'initialiser les éléments
    /// qui doivent persister tout au long de la vie du script, mais ne doivent être configurés qu'immédiatement avant utilisation.
    /// Pour notre cas elle permet d'initialiser les champs.
    /// </summary>
    private void Start()
    {
        List<Transform> children = GetChildren(transform);
        foreach (Transform child in children)
        {
            if (child.gameObject.name == "seedImage")
            {
                seedImage = child;
                seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = seed_sprite;
            }
            else
            {
                plotImage = child;
                plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
            }
        }
        //PlantedPlant pplant = CreateAllSeedPlant.dicoPlant.createPlantedPlant(EnumTypePlant.ELB);
        if (isDesactive)
            plotImage.gameObject.GetComponent<SpriteRenderer>().color = new Color(164, 0, 0, 255);
        //donnePlantedPlante(pplant);
    }

    /// <summary>
    /// La méthode <c>fairePousser</c> permet de faire pousser une plante.
    /// </summary>
    public void fairePousser()
    {
        if (!contientGraine)
        {
            return;
        }

        if (growthStatus < growthTime)
        {
            growthStatus++;
        }

        if (growthStatus == growthTime)
        {
            seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = seed_sprite_grown;
        }
    }

    /// <summary>
    /// La méthode <c>recupPlante</c> permet de récupérer la plante.
    /// </summary>
    public void recupPlante()
    {
        Plant testPlant = CreateAllSeedPlant.dicoPlant.createPlant(plantedPlant.getTypePlante());
        if (CreateAllSeedPlant.mainInventory.getCurrentWeight() + (plantedPlant.getNbCollect() * testPlant.getWeight()) < CreateAllSeedPlant.mainInventory.getWeightMax())
        {
            contientGraine = false;
            growthStatus = -1;
            //EnumTypePlant plantARetourner = new EnumTypePlant();
            //avant etait CreateAllSeedPlant.dicoPlant.createPlant(plantedPlant.getTypePlante()
            seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = null;

            if (plantedPlant != null)
            {
                //Debug.Log("planted plant . get type plant = " + plantedPlant.getTypePlante());
                //la plante avec croissance finie revient à l'inventory
                //Debug.Log("#### inventory : " + CreateAllSeedPlant.mainInventory.getInventory().Count);
                CreateAllSeedPlant.mainInventory.addToInventory(
                    testPlant,
                    plantedPlant.getNbCollect(), CreateAllSeedPlant.mainInventory.getInventory());
            }


            //CreateAllSeedPlant.mainInventory.addToInventory(AllSeedPlant.createPlant(plantARetourner), 10);
            itemDansPlot = null;
            plantedPlant = null;
        }
        else
        {
            error.changeText("Inventaire plein", "Vous ne pouvez pas récuperer cette plante, votre inventaire est plein");
            errorDislp.inverseAffichage();
        }
    }

    /// <summary>
    /// La méthode <c>planteGraine</c> permet de planter une graine.
    /// </summary>
    /// <param name="item">l'item de la graine à planter</param>
    public void planteGraine(BasicItem item)
    {
        if (!contientGraine)
        {
            contientGraine = true;
            growthStatus = 0;

            //on stocke l'item de la graine plantee
            //itemDansPlot = PlotSupervisor.GetComponent<GerePlant>().getStockedItem();
            itemDansPlot = item;
            //on garde sa version planted plant (graine--->planted plant--->plant)
            BasicPlant bp = (BasicPlant)itemDansPlot;
            EnumTypePlant typePlant = bp.getTypePlante();
            PlantedPlant pl = CreateAllSeedPlant.dicoPlant.createPlantedPlant(typePlant);

            //on associe tous les elements propres au planted plant au plot
            //fusion de la fonction donnePlantedPlant
            plantedPlant = pl;
            List<Sprite> listeSprites = pl.getSpriteLinks();
            seed_sprite = listeSprites[0];
            seed_sprite_grown = listeSprites[1];
            growthTime = pl.getGrowthTime();

            seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = seed_sprite;
            CreateAllSeedPlant.mainInventory.SubstractFromInventory(item, 1, CreateAllSeedPlant.mainInventory.getInventory());
            //on plante une graine de la seed choisie
            //PlotSupervisor.GetComponent<GerePlant>().Soustraits(item, 1);
        }
        else
            Debug.Log("une graine est déja plantee, on ne peut pas planter une par dessus!!");
    }

    /// <summary>
    /// La méthode <c>OnMouseDown</c> permet, lors du clique sur le champs, de récupérer la plante.
    /// </summary>
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(isDesactive)
        {
            openBuyPlot();
        }
        else if (growthStatus == growthTime && growthStatus > 0)
            recupPlante();
        else if (!contientGraine)
        {
            //Debug.Log("on rentre dans le OnMouseDoxwn(devrait etre premiere fonction");
            PlotSupervisor.GetComponent<GerePlant>().StockedPlot = this.gameObject.GetComponent<PlotEvents>();
            hidesPanel.inverseAffichage();
            reafficheInvOnClick.Affiche();
        }
    }

    /// <summary>
    /// La méthode <c>GetChildren</c> permet d'obtenir les champs à partir d'un parent (la map)
    /// </summary>
    /// <param name="parent">le parent, sur lequel les champs sont disposés</param>
    /// <returns>la liste des champs</returns>
    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }

    public void openBuyPlot()
    {
        buy.open(this);
    }

    public void setPlotActive()
    {
        isDesactive = false;
        plotImage.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }

    /// <summary>
    /// La méthode <c>OnMouseOver</c> permet de surligner le champs lors du survole avec la souris.
    /// </summary>
    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
            return;
        }
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite_highlite;
    }

    /// <summary>
    /// La méthode <c>OnMouseExit</c> permet d'enlever le surlignement des champs après le survole de la souris.
    /// </summary>
    void OnMouseExit()
    {
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
    }
}
