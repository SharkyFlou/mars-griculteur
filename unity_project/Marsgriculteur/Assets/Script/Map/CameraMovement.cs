using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Serialization is the automatic process of transforming data structures or object states into a format that Unity can store and reconstruct later.
    [SerializeField]
    private Camera cam;
    
    //permet de bouger la camera
    private Vector3 dragOrigin;

    [SerializeField]
    private float zoom, minCamSize, maxCamSize;


    //determine comment le sprite est affiché/info sur celui ci
    [SerializeField]
    private SpriteRenderer tilemapRenderer;

    //on doit sauvegarder les positions aux 4 limites de la map pour ne pas permettre à la camera de bouger plus loin que celle ci
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    //get all positions pour limiter la camera, doit soustraire .bounds.size vu que la taille est mesuree depuis le centre du sprite
    //on divise par 2f pour trouver la position a la limite centrale du map


    private bool canMoove = true; // to lock the cam

    //fonction AWAKE IMPORTANT --- NE PAS NOMMER UN AUTRE TRUC sinon le truc ne s'autoupdate pas tout seul
    private void Awake(){
        mapMinX = tilemapRenderer.transform.position.x - tilemapRenderer.bounds.size.x/2f;
        mapMaxX = tilemapRenderer.transform.position.x + tilemapRenderer.bounds.size.x/2f;

        mapMinY = tilemapRenderer.transform.position.y - tilemapRenderer.bounds.size.y/2f;
        mapMaxY = tilemapRenderer.transform.position.y + tilemapRenderer.bounds.size.y/2f;
    }

    public void playerCanMoove(bool state)
    {
        canMoove = state;
    }


    private void Update(){
        PanCamera();
    }

    private void PanCamera(){
        //garde la position intiale du mouse
        if (!canMoove)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        //garde la nouvelle position à laquelle le mouse se trouve 
        if(Input.GetMouseButton(0)){
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = ClampCamera(cam.transform.position + difference);

        }
        

    } 

    public void ZoomIn(){
        //camOrtographicSize = hauteur de la camera depuis le centre de celle-ci
        float newSize = cam.orthographicSize - zoom;
        //clamp = limite la valeur aux deux parametres donnes
        cam.orthographicSize =Mathf.Clamp(newSize, minCamSize, maxCamSize);


        cam.transform.position = ClampCamera(cam.transform.position);
    }

    public void ZoomOut(){
        //camOrtographicSize = hauteur de la camera depuis le centre de celle-ci
        float newSize = cam.orthographicSize + zoom;
        //clamp = limite la valeur aux deux parametres donnes
        cam.orthographicSize =Mathf.Clamp(newSize, minCamSize, maxCamSize); 

        cam.transform.position = ClampCamera(cam.transform.position);

    }

    private Vector3 ClampCamera(Vector3 targetPosition){
        //camOrtographicSize = hauteur de la camera depuis le centre de celle-ci
        //cam.aspect permet de trouver le width en multipliant par la hauteur
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize*cam.aspect;

        float minCamX = mapMinX + camWidth;
        float maxCamX = mapMaxX - camWidth;
        float minCamY = mapMinY + camHeight;
        float maxCamY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minCamX, maxCamX);
        float newY = Mathf.Clamp(targetPosition.y, minCamY, maxCamY);

        //on retourne un .z vu que tout vector3 utilise 3 coordonnees
        return new Vector3(newX, newY, targetPosition.z);

    }

}
