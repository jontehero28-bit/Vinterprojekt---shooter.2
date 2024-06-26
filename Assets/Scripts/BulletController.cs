using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D Bulletrigidbody;

    ZombieController ZombieScript;

    PlayerController PlayerScript;


    [SerializeField]
    float Bulletspeed;
    void Start()
    {
        Bulletrigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, t: 3f); //objekt raderas efter 4 sek. https://discussions.unity.com/t/destroy-object-after-a-delay/35759/5
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }

    void Update()
    {
        Bulletrigidbody.velocity = transform.up * Bulletspeed; // Jag säger att bullet ska röra sig med riktningen uppåt det vil säga spritens up.


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<ZombieController>();
        if (other.gameObject.tag == "Enemy") //specifierar att dne ska kollidera just med tag enemy. alltså att other är enemy.
        {
           
            Destroy(gameObject); //raderar bullet när den kollideras med något
            enemy.ZombieHealth -= PlayerScript.PlayerDamage;
            

            if (enemy.ZombieHealth <= 0)
            {
                enemy.Death();
                PlayerScript.currentXP += 10;
            }
            
        }


        

        //if (enemy != null) //när kolliderar med fiende då raderas spel objekt.



    }
}
