using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float runSpeed = 10f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    float climbSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravitySlaceAtStart;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravitySlaceAtStart = myRigidbody.gravityScale;
    }


    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    void OnMove(InputValue value) //????
    //Klavyemde herhangi bir seye bastigimi algiliyor ve o girisi direkt olarak yakaliyor value icinde bu deger tutuluyor bir kere a ya basarsam 1 0 vectorunu moveInputa aktarmis olurum mesala 
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnJump(InputValue value) //ziplamayi saglar 
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //platformTileMap e bir layer verdik Ground platforma deyip degmedigine bu kod sayesinde alabiliyoruz 
                                                                              //eger Ground a degiyorsa buraya girmez ve ziplama calisir 
        {
            return; // eger buraya girerse burdan sonrasina devam etmek demek bu
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y); //eger y ye 0 verirsem y deki hizini yinede degistirmeye calisiyorum anlamina geliyor ve duzensiz hareket ediyor 
        // burdaki mantik y deki mevcut hizin neyse onu koru anlamina geliyor, her karede yeni bir hiz ekliyoruz sadece x e ama 
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed); // eger hiz 0 dan buyukse yani true donuyorsa bu da true donucek ve kosma animasyonu calisacak

    }
    void FlipSprite() // saga sola donerken karakterin o tarafa bakmasi icin scale ile oynadik 
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; //burada velecity nin x degeri  - de + da olabilir o yuzden mutlak deger icine aldik 
        //Epsilonda bir floatin 0 dan farkli alabilecegi en kucuk degerdir yani 0 dan buyuk demekten daha duzgun bir hesaplama sagliyor 
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f); //sign dan cikan deger 0 veya pozitifse 1 dondurur negatifse -1 dondurur 
            //transformdaki degerleri degistirmek icin vektore ihtiyacim var scale x ine 1 veya - 1 seklinda deger vermis oldum 
        }
    }
    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravitySlaceAtStart; //merdivene degmiyorsa gravity basta neyse o diyorum 
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f; //merdiven ustundeyken gravity 0 liyoruz merdivende sabit kalabilsin diye yoksa gravityden dolayi asagi kayiyor 
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon; //merdivende tirmanmadan durursa hiz 0 olacagi icin false doner ve tirmanma animasyonu durdururuz  
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed); 
    }
}
