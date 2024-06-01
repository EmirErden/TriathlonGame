using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class cameraScript : MonoBehaviour
{
    public GameObject player;
    private float distanceY = 2.23f;
    private float distanceZ = 2.8f;
    characterMovement move;
    
    void Start(){
        move = player.GetComponent<characterMovement>();
    }
    void Update(){
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y + distanceY, playerPos.z + distanceZ);

        bool inCycle = move.returnCycle();

        if(inCycle){
            transform.rotation = Quaternion.Euler(9.219f, 180.0f, 0.0f);
        }
    }
}
