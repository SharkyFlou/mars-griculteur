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



    private int growthTime;
    private int growthStatus;
    private Transform plotImage;
    private Transform seedImage;
    private PlantedPlant plantedPlant;
    private bool contientGraine = false;
    private BasicItem itemDansPlot;
    private int qtt;



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


        PlantedPlant pplant = CreateAllSeedPlant.dicoPlant.createPlantedPlant(EnumTypePlant.ELB);



        //donnePlantedPlante(pplant);
    }

    public void donnePlantedPlante(PlantedPlant pl)
    {
        plantedPlant = pl;
        List<Sprite> listeSprites = pl.getSpriteLinks();
        seed_sprite = listeSprites[0];
        seed_sprite_grown = listeSprites[1];
        growthTime = pl.getGrowthTime();
        growthStatus = 0;

        seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = seed_sprite;
        contientGraine = true;
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
        growthStatus = 0;
        //EnumTypePlant plantARetourner = new EnumTypePlant();
        //avant etait CreateAllSeedPlant.dicoPlant.createPlant(plantedPlant.getTypePlante()
        seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = null;

        //faut changer ca pour arriver a faire new Plant(plante de la seed qu'on a plantee)
        if (itemDansPlot.getId() > 0 && itemDansPlot.getId() < 200)
        {
            //EnumTypePlant plantARetourner = (BasicPlant)itemDansPlot.GetTypePlant();
        }
        //CreateAllSeedPlant.mainInventory.addToInventory(AllSeedPlant.createPlant(plantARetourner), 10);
        //plantedPlant = null;
        itemDansPlot = null;
    }

    public void planteGraine()
    {
        contientGraine = true;
        growthStatus = 0;

        Transform[] elements = InterfacePlantPanel.GetComponentsInChildren<Transform>();
        Debug.Log("get component in children : " + elements);//cree la planted plant
        foreach (Transform element in elements)
        {
            if (element.name == "PanelPlot")
            {
                itemDansPlot = element.GetComponent<GerePlant>().getStockedItem();
                //seedImage.game
                Debug.Log("seed plantee : graine de " + itemDansPlot.getName());
            }
        }
        //pas vraiment besoin d'implementer un plantedplant... @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ a revoir
    }


    void OnMouseDown()
    {
        //recupPlante();
        //InventoryPanel.SetActive(true);
        //InterfacePlantPanel.SetActive(true);
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (growthStatus == growthTime)
            recupPlante();
        else if (!contientGraine)
        {
            hidesPanel.inverseAffichage();
            //on doit faire a partir de hidepanel, au lieu de passer par plotSupervisor
            //change
            PlotSupervisor.GetComponent<GerePlant>().StockedPlot = this.gameObject.GetComponent<PlotEvents>();
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        //ici on devra remettre le bool a true/false, comme ça on aura deux interfaces qui se lanceront selon ce qu'on a planté ou non
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
