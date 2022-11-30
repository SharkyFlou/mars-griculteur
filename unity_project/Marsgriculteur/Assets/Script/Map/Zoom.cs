using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    private void Awake()
    {
        mapMinX = tilemapRenderer.transform.position.x - tilemapRenderer.bounds.size.x / 2f;
        mapMaxX = tilemapRenderer.transform.position.x + tilemapRenderer.bounds.size.x / 2f;

        mapMinY = tilemapRenderer.transform.position.y - tilemapRenderer.bounds.size.y / 2f;
        mapMaxY = tilemapRenderer.transform.position.y + tilemapRenderer.bounds.size.y / 2f;

    }

    // Update is called once per frame
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

    public void playerCanZoom(bool state)
    {
        canZoom = state;
    }

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
