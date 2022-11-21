using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class graphMarket : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    public RectTransform graphContainer;
    public TextMeshProUGUI labelTemplateY;
    public TextMeshProUGUI labelTemplateX;
    public RectTransform dashTemplateY;
    public RectTransform dashTemplateX;


    private float yMaximum; //maximum de la hauteur, pour �quilibrer l'affichage
    private float xSize; //maximum de la longueur, pour �quilibrer l'affichage
    private float graphHeight; //hauteur de container, calcul� en amont pour permettre certaines modifications
    private float yMin;
    private int numberOfDays;

    private void Awake()
    {
        //instantie les list, c'est temporaire
        List<int> graphList = new List<int>() { 0, 11, 9, 8, 2, 3, 7, 8, 15, 19, 17, 13, 12, 11, 9, 8, 2, 3, 7, 8, 15, 19, 17, 13 , 12, 11, 9, 8, 2, 3, 7, 8, 15, 19, 17, 13 , 12, 11, 9, 8, 2, 3, 7, 8, 15, 19, 17, 13 , 12, 11, 9, 8, 2, 3, 7, 8, 15, 19, 17, 13 };
        List<string> monthList = new List<string>() { "Janv", "Fev", "Mars", "Avril", "Mai", "Juin", "Juil", "Aout", "Sept", "Oct", "Nov", "Dec" };
        yMaximum = graphList.Max(); //Y maximum pour l'affichage
        xSize = (float) (graphContainer.sizeDelta.x/  (graphList.Count*1.1)); //espace entre les points en X
        graphHeight = graphContainer.sizeDelta.y*0.9f; //hauteur du graph
        yMin = 10f; //pour rendre le graph plus beau

        numberOfDays = 36; //bullshit

        ShowGraph(graphList, monthList); //affiche le graph
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) //cr�er un cercle et le renvoie
    {
        GameObject gameobject = new GameObject("circle", typeof(Image));  //cr�er une image, qui sera le point

        gameobject.transform.SetParent(graphContainer,false);
        gameobject.GetComponent<Image>().sprite = circleSprite; //choix de l'image du point, permet de la choisir
        //on r�cup�re les donn�es type, taille, position et tt du points pour les modifier
        RectTransform rectTransform = gameobject.GetComponent<RectTransform>(); 
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameobject;
    }

    private void ShowGraph(List<int> valueList, List<string> xValues) //affiche la liste donn� sous forme de graph,  avec en valeur de X xValues
    {
        //cr�er les lignes horizontales
        int nbrSeperator = 8;
        for (int i = 0; i <= nbrSeperator; i++) //cr�er les valeurs Y, les lignes
        {
            float heightInScale = i * 1f / nbrSeperator;

            //creer le texte de la ligne
            TextMeshProUGUI labelY = Instantiate(labelTemplateY, graphContainer, false);
            labelY.gameObject.SetActive(true);
            labelY.rectTransform.anchoredPosition = new Vector2(0f,yMin + heightInScale * graphHeight);
            labelY.GetComponent<TextMeshProUGUI>().text = ((int)math.round(heightInScale * yMaximum)).ToString();


            //creer la ligne
            RectTransform dashY = Instantiate(dashTemplateY, graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2((dashTemplateY.sizeDelta.x / 2), yMin+ heightInScale * graphHeight);
        }



        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) //boucle pour chaque valeur, cr�er un point, et les relies
        {
            float xPosition = xSize + i * xSize;
            float yPosition = yMin + (valueList[i]/ yMaximum) * graphHeight;
            //on r�cup�re les donn�es de type taille, position et tt du points pour les modifier
            
            //creation du la valeur associ� au X en abssice
            if ((numberOfDays +i) % 5 == 0)
            {
                ///valeur
                TextMeshProUGUI labelX = Instantiate(labelTemplateX, graphContainer, false);
                labelX.gameObject.SetActive(true);
                labelX.rectTransform.anchoredPosition = new Vector2(xPosition, -20f);
                int monthToDisplay = ((numberOfDays + i) / 5) % 12; //calcul complique, mais donne le mois 
                labelX.GetComponent<TextMeshProUGUI>().text = xValues[monthToDisplay];


                //trait
                RectTransform dashX = Instantiate(dashTemplateX, graphContainer, false);
                dashX.gameObject.SetActive(true);
                dashX.anchoredPosition = new Vector2(xPosition, (dashTemplateX.sizeDelta.x / 2));
            }

            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if(lastCircleGameObject != null) //si pas le premier point
            {
                //cr�er une ligne entre les deux points
                CreateDotConnection(circleGameObject.GetComponent<RectTransform>().anchoredPosition, lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject; //enregistre le point, pour permettre la connexion entre les points 
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) //cr�er une ligne entre les deux points donn�s
    {
        //creation d'une ligne
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>(); 
        Vector2 dir = (dotPositionA - dotPositionB).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        float degres = AngleBetweenVector2(dotPositionB, dotPositionA); //calcul des degr� entre les deux points

        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionB + dir*distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0,degres);
    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2) //renvoie l'angle entre les deux points donn�s
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

}
