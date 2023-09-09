using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        moveSpeed = -moveSpeed; //duvarla carpistiginda tam tersi yone gitmesi icin hizi - ile carptik  
        FlipEnemyFacing();
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f); // - ile neden carpiyoruz ???
    }
}
