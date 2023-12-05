using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
      Rigidbody2D _rigidbody;

    [SerializeField] //jag märkte att göra en variabel public gör samma sak som serialize field!
    float Speed;

      Vector2 _input;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //vilken typ av komponent man vill ta up
    }

    
    void Update()
    {
        transform.up = (LookAtMouse.GetMousePosition2d() - (Vector2)transform.position).normalized; //gör så att topen av spriten (där karaktären håller pistol) alltid kollar up. Där musen är destination och position är startpunkt.Noramlized gör den alltid till 1

        //----- På grund av att jag fuckar med transform.up InputAxisRaw fungerar konstigt så jag baserade två rader kod här https://discussions.unity.com/t/why-are-my-controls-laggy/226089 Det är inte exakt samma men inte mina:=)

        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //Tar kontrollerna
        _rigidbody.velocity = _input.normalized * Speed;  //gör så att karaktären rör sig. Med speed.
        
    }
}
