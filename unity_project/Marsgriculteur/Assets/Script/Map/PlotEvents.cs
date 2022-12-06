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


    public GameObject InterfacePlantPanel;
    public openCanvas gerePlantDisplay;


    private int growthTime;
    private int growthStatus;
    private Transform plotImage;
    private Transform seedImage;
    private PlantedPlant plantedPlant;
    private Boolean contientGraine = false;
    private BasicItem itemDansPlot;
    private int qtt;

    //param qui cache tout autour
    //public openCanvas hidesPanel;
    


    //on appelle le dico du inventory Player, puis on le modifie selon
    //recup plante
    //ou plantation

    public PlayerInventory playerInventory;



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



        donnePlantedPlante(pplant);
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
        /* PAS ENCORE FONCTIONNEL */

        //playerInventory.addToInventory((CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB)),15);
        //playerInventory.SubstractFromInventory((CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB)),15);
        //playerInventory.removeFromInventory(CreateAllSeedPlant.dicoPlant.createSeed(EnumTypePlant.ELB));

    }

    public void planteGraine()
    {
        //ouvre l'inventaire, pour planter une graine
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
        gerePlantDisplay.inverseAffichage();

        //ici : clear panel quand on revioent sur la meme interface

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
