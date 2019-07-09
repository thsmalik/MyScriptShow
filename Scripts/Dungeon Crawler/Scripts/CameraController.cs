using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Tilemap theMap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public CinemachineVirtualCamera vcam;

    private float halfHeight;
    private float halfWidght;
    void Start()
    {
        halfHeight = vcam.m_Lens.OrthographicSize;
        halfWidght = halfHeight * vcam.m_Lens.Aspect;
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidght,halfHeight,0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidght,-halfHeight,0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
