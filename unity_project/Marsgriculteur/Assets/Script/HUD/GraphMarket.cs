using game;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



namespace game
{
    /// <summary>
    /// La classe <c>GraphMarket</c> s'occupe du graphique du marché.
    /// Elle possède les attributs suivant : circleSprite, graphContainer, labelTemplateY, dashTemplateY, dashTemplateX, market,
    /// titre, lastValueText, yMaximum, xSize, xMaximum, graphHeight, yMin, numberOfDays, monthList, mutlInvGraph,
    /// plantAct, cam, camZoom, allChildsToSuppr.
    /// </summary>
    public class GraphMarket : MonoBehaviour
    {
        [SerializeField] private Sprite circleSprite;
        public RectTransform graphContainer;
        public TextMeshProUGUI labelTemplateY;
        public TextMeshProUGUI labelTemplateX;
        public RectTransform dashTemplateY;
        public RectTransform dashTemplateX;
        [SerializeField] public Market market;
        public TextMeshProUGUI titre;
        public TextMeshProUGUI lastValueText;


        private float yMaximum; //maximum de la hauteur, pour équilibrer l'affichage
        private float xSize; //maximum de la longueur, pour équilibrer l'affichage
        private float xMaximum;
        private float graphHeight; //hauteur de container, calculé en amont pour permettre certaines modifications
        private float yMin;
        private int numberOfDays;
        private List<string> monthList;
        const float mutlInvGraph = 2f;
        private EnumTypePlant plantAct = EnumTypePlant.ELB;
        public CameraMovement cam;
        public Zoom camZoom;
        //truc
        //truc

        private List<GameObject> allChildsToSuppr = new List<GameObject>();

        /// <summary>
        /// La méthode <c>Awake</c> est appelée lorsque l'instance de script est en cours de chargement.
        /// Elle crée la liste des mois.
        /// </summary>
        private void Awake()
        {
            monthList = new List<string>() { "Janv", "Fev", "Mars", "Avril", "Mai", "Juin", "Juil", "Aout", "Sept", "Oct", "Nov", "Dec" };
            yMin = 10f; //pour rendre le graph plus beau
        }

        /// <summary>
        /// La méthode <c>affiche</c> permt d'afficher le graphique
        /// </summary>
        public void affiche()
        {
            List<int> graphList = market.last60Days(plantAct);
            titre.text = "Cours du " + plantAct;

            yMaximum = graphList.Max(); //Y maximum pour l'affichage
            xMaximum = graphContainer.rect.width; //largeur du graph
            graphHeight = graphContainer.rect.height * 0.9f; //hauteur du graph
            xSize = (float)(xMaximum / (graphList.Count * 1.05)); //espace entre les points en X

            numberOfDays = market.getDays();

            if (graphList == null)
            {
                Debug.Log("????");
                return;
            }


            ShowGraph(graphList); //affiche le graph
        }

        /// <summary>
        /// La méthode <c>Update</c> est appelée une fois par fenêtre (frame). Elle ne laisse pas la possibilté au joueur de bouger la caméra.
        /// </summary>
        public void Update()
        {
            if (graphContainer.GameObject().activeInHierarchy)
            {
                cam.playerCanMoove(false);
                camZoom.playerCanZoom(false);
            }
        }

        /// <summary>
        /// La méthode <c>changePlant</c> permet d'afficher le changement de plante
        /// </summary>
        /// <param name="pl">la nouvelle plante</param>
        public void changePlant(EnumTypePlant pl)
        {
            plantAct = pl;
            affiche();
        }

        /// <summary>
        /// La méthode <c>CreateCircle</c> permet de créer un cerle qui va représenter un point pour le graphique.
        /// </summary>
        /// <param name="anchoredPosition">la position du point</param>
        /// <returns>Elle retourne le point créé</returns>
        private GameObject CreateCircle(Vector2 anchoredPosition) //créer un cercle et le renvoie
        {
            GameObject gameobject = new GameObject("circle", typeof(Image));  //créer une image, qui sera le point

            gameobject.transform.SetParent(graphContainer, false);
            gameobject.GetComponent<Image>().sprite = circleSprite; //choix de l'image du point, permet de la choisir
                                                                    //on récupère les données type, taille, position et tt du points pour les modifier
            RectTransform rectTransform = gameobject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.localScale = new Vector2(mutlInvGraph, 1);
            allChildsToSuppr.Add(gameobject);
            return gameobject;
        }

        /// <summary>
        /// La méthode <c>ShowGraph</c> affiche la liste donné sous forme de graph,  avec en valeur de X les month
        /// </summary>
        /// <param name="valueList">la liste des points</param>
        private void ShowGraph(List<int> valueList)
        {
            clearGraph();
            //créer les lignes horizontales
            int nbrSeperator = 8;
            for (int i = 0; i <= nbrSeperator; i++) //créer les valeurs Y, les lignes
            {
                float heightInScale = i * 1f / nbrSeperator;

                //creer le texte de la ligne
                TextMeshProUGUI labelY = Instantiate(labelTemplateY, graphContainer, false);
                labelY.gameObject.SetActive(true);
                labelY.rectTransform.anchoredPosition = new Vector2(0f, yMin + heightInScale * graphHeight);
                labelY.rectTransform.localScale = new Vector2(mutlInvGraph, 1);
                allChildsToSuppr.Add(labelY.gameObject);
                labelY.GetComponent<TextMeshProUGUI>().text = ((int)math.round(heightInScale * yMaximum)).ToString();


                //creer la ligne
                RectTransform dashY = Instantiate(dashTemplateY, graphContainer, false);
                dashY.gameObject.SetActive(true);
                dashY.sizeDelta = new Vector2(xMaximum, dashY.sizeDelta.y); //change la taille selon la taille du graph container
                dashY.anchoredPosition = new Vector2(dashY.sizeDelta.x / 2, yMin + (heightInScale * graphHeight));
                allChildsToSuppr.Add(dashY.gameObject);
            }



            GameObject lastCircleGameObject = null;
            for (int i = 0; i < valueList.Count; i++) //boucle pour chaque valeur, créer un point, et les relies
            {
                float xPosition = xSize + i * xSize;
                float yPosition = yMin + (valueList[i] / yMaximum) * graphHeight;
                //on récupère les données de type taille, position et tt du points pour les modifier

                //creation du la valeur associé au X en abssice
                if ((numberOfDays + i) % 5 == 0)
                {
                    ///valeur
                    TextMeshProUGUI labelX = Instantiate(labelTemplateX, graphContainer, false);
                    labelX.gameObject.SetActive(true);
                    labelX.rectTransform.anchoredPosition = new Vector2(xPosition, -20f);
                    labelX.rectTransform.localScale = new Vector2(mutlInvGraph, 1);
                    int monthToDisplay = ((numberOfDays + i) / 5) % 12; //calcul complique, mais donne le mois 
                    labelX.GetComponent<TextMeshProUGUI>().text = monthList[monthToDisplay];
                    allChildsToSuppr.Add(labelX.gameObject);


                    //trait
                    RectTransform dashX = Instantiate(dashTemplateX, graphContainer, false);
                    dashX.gameObject.SetActive(true);
                    dashX.sizeDelta = new Vector2(graphHeight * 1.1f, dashX.sizeDelta.y * mutlInvGraph); //change la taille selon la taille du graph container
                    dashX.anchoredPosition = new Vector2(xPosition, (dashX.sizeDelta.x / 2));
                    allChildsToSuppr.Add(dashX.gameObject);
                }

                GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
                if (lastCircleGameObject != null) //si pas le premier point
                {
                    //créer une ligne entre les deux points
                    CreateDotConnection(circleGameObject.GetComponent<RectTransform>().anchoredPosition, lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition);
                }
                lastCircleGameObject = circleGameObject; //enregistre le point, pour permettre la connexion entre les points 

                if (i == valueList.Count - 1)
                {
                    lastValueText.rectTransform.anchoredPosition = new Vector2(xPosition, yPosition);
                    lastValueText.text = valueList[i].ToString() + "$";
                    lastValueText.gameObject.SetActive(true);
                }
            }
        }

        /// <summary>
        /// La méthode permet de créer une ligne entre les deux points donnés
        /// </summary>
        /// <param name="dotPositionA">le point de départ</param>
        /// <param name="dotPositionB">le point d'arriver</param>
        private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            //creation d'une ligne
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            allChildsToSuppr.Add(gameObject);

            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            Vector2 dir = (dotPositionA - dotPositionB).normalized;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            float degres = AngleBetweenVector2(dotPositionB, dotPositionA); //calcul des degré entre les deux points

            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.localScale = new Vector2(1, mutlInvGraph);
            rectTransform.anchoredPosition = dotPositionB + dir * distance * 0.5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, degres);

        }

        /// <summary>
        /// La méthode <c>AngleBetweenVector2</c> renvoie l'angle entre les deux points donnés
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
        {
            Vector2 diference = vec2 - vec1;
            float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
            return Vector2.Angle(Vector2.right, diference) * sign;
        }

        /// <summary>
        /// La méthode <c>clearGraph</c> supprime le graph pour en reafficher un nouveau
        /// </summary>
        private void clearGraph()
        {
            for (int i = 0; i < allChildsToSuppr.Count; i++)
            {
                Destroy(allChildsToSuppr[i]);
            }
            allChildsToSuppr.Clear();

        }

    }
}
