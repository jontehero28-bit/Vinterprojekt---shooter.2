using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieController : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    private GameObject _player;

    float Randomspeed;    //ska göra en randomizer för att hastigheten skulle varieras.

    [SerializeField]
    float Zombiespeed = 5;  //bas hastighet.
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Randomspeed = Zombiespeed * (1 + Random.Range(-0.1f, 0.1f)); // bas hastighet * belopp mellan -0.1 och 0.1. Vilket betyder hastighet varierar inom 10% här källa https://gamedevbeginner.com/how-to-use-random-values-in-unity-with-examples/
        _player = GameObject.FindGameObjectWithTag("Player");  //dåligt att använda ifall jag har flera GameObject. Men tror det funkar utan problem? behövs för att ge referens till player
    }

    void Update()
    {
        if (_player != null)//ifall player gör så att enemies fortsätter röra på sig. samt tar bort errors
        {
            transform.up = (_player.transform.position - transform.position).normalized; // samma sak som transform.up = (LookAtMouse.GetMousePosition2d() - (Vector2)transform.position).normalized;
            _rigidbody.velocity = transform.up * Zombiespeed;  //samma sak som _rigidbody.velocity = _input.normalized * Speed; så återanvänder kod

        }

    }

    public void Death()//ta bort objekten
    {
        Destroy(gameObject);
    }
}
