using game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotEvents : MonoBehaviour
{
    public Sprite plot_sprite_highlight;
    public Sprite plot_sprite;


    private Sprite seed_sprite;
    private Sprite seed_sprite_grown;



    private int growthTime;
    private int growthStatus;
    private Transform plotImage;
    private Transform seedImage;
    private PlantedPlant plantedPlant;

    private Boolean contientGraine = false;


    private void Start()
    {

        List<Transform> children = GetChildren(transform);
        foreach(Transform child in children)
        {
            if(child.gameObject.name == "seedImage")
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

        if(growthStatus == growthTime)
        {
            seedImage.gameObject.GetComponent<SpriteRenderer>().sprite = seed_sprite_grown;
        }
    }

    public void recupPlante()
    {
        //donne les trucs au joueur
    }

    public void planteGraine()
    {
        //ouvre l'inventaire, pour planter une graine
    }


    void OnMouseDown()
    {
        if (contientGraine && growthStatus == growthTime)
        {
            recupPlante();
        }
        else if(!contientGraine)
        {
            planteGraine();
        }

    }

    void OnMouseOver()
    {
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite_highlight;
    }

    void OnMouseExit()
    {
        plotImage.gameObject.GetComponent<SpriteRenderer>().sprite = plot_sprite;
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach(Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }
}
