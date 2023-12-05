using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   Rigidbody2D Bulletrigidbody;

   [SerializeField]
   float Bulletspeed;
    void Start()
    {
        Bulletrigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Bulletrigidbody.velocity = (transform.up * Bulletspeed); // Jag säger att bullet ska röra sig med riktningen uppåt det vil säga spritens up.
    }
}
