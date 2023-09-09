using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>(); // bu sekilde scripte ulasmak daha iyi
        xSpeed = player.transform.localScale.x * bulletSpeed; //player ne tarafa bakiyorsa o tarafa ateslemesi icin yazilmis code

    }


    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") //dusmana caprptiginda yok olmasini saglar 
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision) // herhangi bir seye mermi carptiginda yok olur 
    {
        Destroy(gameObject);
    }
}
