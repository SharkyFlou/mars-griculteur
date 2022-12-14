using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// La classe <c>Zoom</c> permet, comme son nom l'indique, de g�rer le zoom de la cam�ra.
/// Elle poss�de 10 attributs : cam (pour la cam�ra), tilemapRenderer, zoom, minCamSize, maxCamsize, mapMinX, mapMaxX, mapMinY, mapMaxY, canZoom.
/// </summary>
public class Zoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] private SpriteRenderer tilemapRenderer;

    [SerializeField] private float zoom;
    [SerializeField] private float minCamSize;
    [SerializeField] private float maxCamSize;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private bool canZoom = true; // to lock the cam

    //get all positions pour limiter la camera, doit soustraire .bounds.size vu que la taille est mesuree depuis le centre du sprite
    //on divise par 2f pour trouver la position a la limite centrale du map

    //fonction AWAKE IMPORTANT --- NE PAS NOMMER UN AUTRE TRUC sinon le truc ne s'autoupdate pas tout seul
    /// <summary>
    /// La m�thode <c>Awake</c> est appel�e lorsque l'instance de script est en cours de chargement.
    /// Elle positionne la cam�ra avec le bon zoom.
    /// </summary>
    private void Awake()
    {
        mapMinX = tilemapRenderer.transform.position.x - tilemapRenderer.bounds.size.x / 2f;
        mapMaxX = tilemapRenderer.transform.position.x + tilemapRenderer.bounds.size.x / 2f;

        mapMinY = tilemapRenderer.transform.position.y - tilemapRenderer.bounds.size.y / 2f;
        mapMaxY = tilemapRenderer.transform.position.y + tilemapRenderer.bounds.size.y / 2f;

    }

    // Update is called once per frame
    /// <summary>
    /// La m�thode <c>Update</c> est appel�e une fois par fen�tre (frame). Elle g�re la cam�ra
    /// </summary>
    void Update()
    {
        if (!canZoom)
        {
            return;
        }

        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        if (cam.orthographicSize < minCamSize) { cam.orthographicSize = minCamSize; } //max of zoom
        if (cam.orthographicSize > maxCamSize) { cam.orthographicSize = maxCamSize; } //max of dezoom
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    /// <summary>
    /// La m�thode <c>playerCanZoom</c> autorise au joueur de zoomer ou non.
    /// </summary>
    /// <param name="state">bool�en qui indique si le joueur peut zoomer ou non</param>
    public void playerCanZoom(bool state)
    {
        canZoom = state;
    }

    /// <summary>
    /// La m�thode <c>ClampCamera</c> sert a bouger la camera a la nouvelle position desir�e
    /// </summary>
    /// <param name="targetPosition">la position d�sir�e</param>
    /// <returns>Elle retourne la position de la cam�ra</returns>
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        //camOrtographicSize = hauteur de la camera depuis le centre de celle-ci
        //cam.aspect permet de trouver le width en multipliant par la hauteur
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

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
