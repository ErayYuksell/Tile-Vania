using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    void Start()
    {

    }


    void Update()
    {

    }
    void OnMove(InputValue value)
    //Klavyemde herhangi bir seye bastigimi algiliyor ve o girisi direkt olarak yakaliyor value icinde bu deger tutuluyor bir kere a ya basarsam 1 0 vectorunu moveInputa aktarmis olurum mesala 
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
}
