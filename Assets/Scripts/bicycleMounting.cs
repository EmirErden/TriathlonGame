using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bicycleMounting : MonoBehaviour
{
    public GameObject bicyle;
    public GameObject camera;
    // Start is called before the first frame update
   
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            var camposn = camera.transform.position;
            camera.transform.position = new Vector3(camposn.x,camposn.y-3.5f,camposn.z);
        
            var posn = bicyle.transform.position;
            other.transform.position = new Vector3(posn.x,posn.y+0.1f,posn.z+0.9f);
            
            other.transform.eulerAngles = new Vector3(
            other.transform.eulerAngles.x + 60,
            other.transform.eulerAngles.y,
            other.transform.eulerAngles.z
            );
            camera.transform.eulerAngles = new Vector3(
            camera.transform.eulerAngles.x - 60,
            camera.transform.eulerAngles.y,
            camera.transform.eulerAngles.z
            );

            bicyle.transform.parent = other.transform;
            
                   
        }
    }
}
