using game;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlotEvents : MonoBehaviour
{
    public Sprite plot_sprite;
    public Sprite plot_sprite_highlite;
    private Sprite seed_sprite;
    private Sprite seed_sprite_grown;

    //references a d'autres objets
    public GameObject PlotSupervisor;
    public GameObject InterfacePlantPanel;
    public openCanvas hidesPanel;

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

        //donnePlantedPlante(pplant);
    }

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

    public void recupPlante()
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
                CreateAllSeedPlant.dicoPlant.createPlant(plantedPlant.getTypePlante()),
                    10, CreateAllSeedPlant.mainInventory.getInventory());
        }


        //CreateAllSeedPlant.mainInventory.addToInventory(AllSeedPlant.createPlant(plantARetourner), 10);
        itemDansPlot = null;
        plantedPlant = null;
    }

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

            //on plante une graine de la seed choisie
            PlotSupervisor.GetComponent<GerePlant>().Soustraits(item, 1);
        }
        else
            Debug.Log("une graine est déja plantee, on ne peut pas planter une par dessus!!");
    }


    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (growthStatus == growthTime && growthStatus > 0)
            recupPlante();
        else if (!contientGraine)
        {
            //Debug.Log("on rentre dans le OnMouseDoxwn(devrait etre premiere fonction");
            PlotSupervisor.GetComponent<GerePlant>().StockedPlot = this.gameObject.GetComponent<PlotEvents>();
            hidesPanel.inverseAffichage();
            reafficheInvOnClick.Affiche();
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
            return;
        }
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite_highlite;
    }

    void OnMouseExit()
    {
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
    }
}
