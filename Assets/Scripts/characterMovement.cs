 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;


public class characterMovement : MonoBehaviour
{
    CharacterController characterController;
    private bool isJumping;
    private bool inCycle;
    private bool isSwimming = false;
    public int count = 0;
    public float timer = 0f;
    Vector3 currentJumpVelocity;
    public float speed = 8f;
    public gameOver gameOver;
    public ScoreManager scoreManager; 
    private Animator animator;

    public GameObject handlebar;
    public GameObject camera;
 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 moveVelocity = Vector3.zero;

       moveVelocity.x = Input.GetAxis("Horizontal");
       moveVelocity.z = Input.GetAxis("Vertical");

       Quaternion a = handlebar.transform.rotation;
       Quaternion d = handlebar.transform.rotation;

       if(moveVelocity != Vector3.zero){
        animator.SetBool("isRunning", true);
       } else{
        animator.SetBool("isRunning", false);
       }

       if(Input.GetKeyDown(KeyCode.Space)){
        if(!isJumping){
            isJumping = true;
            currentJumpVelocity = Vector3.up * 5;
        }
       } 

       if(isJumping){
        characterController.Move((moveVelocity * speed  + currentJumpVelocity) * Time.deltaTime);
        currentJumpVelocity += Physics.gravity * Time.deltaTime;
        animator.SetBool("isJumping", true);
        if(characterController.isGrounded){
            isJumping = false;
        }

       } else {
        characterController.SimpleMove(moveVelocity * speed);
        animator.SetBool("isJumping", false);
       }
        
        
        if(Input.GetKeyDown(KeyCode.X)){
            count++;
        }

        

        if(!inCycle & !isSwimming){
            if(Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A)){
                transform.rotation = Quaternion.Euler(0.0f, 150.0f, 0.0f);
            } else if(Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D)){
                transform.rotation = Quaternion.Euler(0.0f, 210.0f, 0.0f);
            } else {
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }

        if(isSwimming){
            if(Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.A)){
                transform.rotation = Quaternion.Euler(0.0f, 162.0f, 0.0f);
            } else if(Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D)){
                transform.rotation = Quaternion.Euler(0.0f, 198.0f, 0.0f);
            } else {
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }
        
        if(inCycle){
            timer += Time.deltaTime;
        if(timer >= 0.6f){
            speed = 8 + count * 2;
            timer = 0f;
            count = 0;
        }
            if(Input.GetKeyDown(KeyCode.A)){
                handlebar.transform.rotation = a * Quaternion.Euler(0.0f, -17.0f, 0.0f);              
            } else if(Input.GetKeyUp(KeyCode.A)){
                handlebar.transform.rotation = a * Quaternion.Euler(0.0f, 17.0f, 0.0f);
            }else if(Input.GetKeyDown(KeyCode.D)){ 
                handlebar.transform.rotation = d * Quaternion.Euler(0.0f, 17.0f, 0.0f);                
            } else if(Input.GetKeyUp(KeyCode.D)){ 
                handlebar.transform.rotation = d * Quaternion.Euler(0.0f, -17.0f, 0.0f);                
            } 
       }      
        
    }
    void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("swimTrigger")){
        animator.SetBool("isSwimming", true);
        speed = 5f;
        isSwimming = true;
    }
    else if (other.CompareTag("runTrigger")){
        animator.SetBool("isSwimming",false);
        speed = 8f;
        isSwimming = false;
        inCycle = true;
    }
    else if(other.CompareTag("Diamond")){
        scoreManager.addPoint();
        Destroy(other.gameObject);
    }
    else if (other.CompareTag("bicycleBox")){
        animator.SetBool("isCycling", true);
        inCycle = true;
    }
    else if (other.CompareTag("finishLine")){
        gameOver.Setup();         
    }
    }

    public bool returnCycle(){
        return inCycle;
    }
}