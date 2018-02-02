using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraPivot;
    public GameObject player;


    // Use this for initialization
    void Start()
    {
        setCameraChildOfPivot();
        this.transform.LookAt(cameraPivot);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
			updateCameraPivotPosition();
        }
        catch
        {
			//Acessando gameobject inexistente
        }
        
    }

    void updateCameraPivotPosition()
    {
        cameraPivot.position = player.transform.position;
    }

    void setCameraChildOfPivot()
    {
        this.transform.SetParent(cameraPivot);
    }
}
