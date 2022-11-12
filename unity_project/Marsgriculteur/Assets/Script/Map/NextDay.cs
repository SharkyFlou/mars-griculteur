using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    public Transform plots;
    List<Transform> plotList; //contient tous les plots pour les faire pousser
    

    void Start()
    {
        if (plots == null) //pour éviter de planter (ahah "plant")
        {
            return;
        }


        GetPlots(plots);
    }

    void OnMouseDown()
    {
        faitPousser();
        //prochain jour
        //si jour%5 == 0 fait vendre les trucs

    }


        public void faitPousser() //parcours chaque plot, puis appelle leur fonction fairePousser
    {
        foreach (Transform transform in plotList)
        {
            transform.gameObject.SendMessage("fairePousser");
        }   
    }


    private void GetPlots(Transform parent) //recupere les plots
    {
        plotList = new List<Transform>();
        foreach (Transform child in parent)
        {
            plotList.Add(child);
        }
        return;
    }
}
