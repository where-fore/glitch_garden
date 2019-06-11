using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingZoom : MonoBehaviour
{
    float startingSize = 0;
    float zoomedSize = 1f;
    float sizeSmooth = 15f;

    Vector3 startingPos = new Vector3(0,0,0);
    Vector3 zoomedPosOffset = new Vector3(0.8f, 0, 0); // currently only uses x coordinate
    Vector3 zoomTargetPos = new Vector3(0,0,0);
    float zoomPosZCoordinate = -4;
    float zPosSmooth = 7f;
    float posSmooth = 15f;

    float zoomTimeScaleInstant = 0.1f;
    float zoomTimeScaleAfter = 0.5f;
    float timeScaleSmooth = 2f;

    private Camera myCamera = null;

    private bool shouldZoom = false;

    private void Start()
    {
        myCamera = GetComponent<Camera>();

        startingSize = myCamera.orthographicSize;
        startingPos = transform.position;
    }

    void Update()
    {
        if (shouldZoom)
        {
            myCamera.orthographicSize = Mathf.Lerp(myCamera.orthographicSize, zoomedSize, Time.deltaTime * sizeSmooth);

            float currentX = Mathf.Lerp(transform.position.x, zoomTargetPos.x, Time.deltaTime * posSmooth);
            float currentY = Mathf.Lerp(transform.position.y, zoomTargetPos.y, Time.deltaTime * posSmooth);
            float currentZ = Mathf.Lerp(transform.position.z, zoomPosZCoordinate, Time.deltaTime * zPosSmooth);
            transform.position = new Vector3(currentX, currentY, currentZ);

            Time.timeScale = Mathf.Lerp(Time.timeScale, zoomTimeScaleAfter, Time.deltaTime * timeScaleSmooth);
        }
        
    }

    
    public void Zoom(Vector3 zoomTarget) //currently only uses y coordinate
    {
        zoomTargetPos = new Vector3(zoomedPosOffset.x, zoomTarget.y, startingPos.z);

        shouldZoom = true;

        Time.timeScale = zoomTimeScaleInstant;
    }

    private void Reset()
    {
        myCamera.orthographicSize = startingSize;
        transform.position = startingPos;
        Time.timeScale = 1f;
    }
}
