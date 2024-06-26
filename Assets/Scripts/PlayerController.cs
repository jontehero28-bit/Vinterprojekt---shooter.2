using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject LevelUpObject;
    [SerializeField]
    GameObject SpawnerObject;
    LevelUpController LevelUpScript;

    SpawnerController SpawnScript;

    Rigidbody2D _rigidbody;

    //jag märkte att göra en variabel public gör samma sak som serialize field!
    public float Speed = 5;

    public float currentXP = 0;
    public float requiredXP = 10;
    public int currentlevel = 1;

    public float PlayerDamage = 10;

    public float GunCooldown;

    public float GunCooldownTime = 1;


    [SerializeField]
    public GameObject BulletPrefab;

    [SerializeField]
    Transform Gun;    //behöver bara transform för att behöver bara position dvs. inte som objekt.


      Vector2 _input;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //vilken typ av komponent man vill ta up

        LevelUpScript = LevelUpObject.GetComponent<LevelUpController>();
        SpawnScript = SpawnerObject.GetComponent<SpawnerController>();

    }

    
    void Update()
    {
        transform.up = (LookAtMouse.GetMousePosition2d() - (Vector2)transform.position).normalized; //gör så att topen av spriten (där karaktären håller pistol) alltid kollar up. Där musen är destination och position är startpunkt.Noramlized gör den alltid till 1

        //----- På grund av att jag fuckar med transform.up InputAxisRaw fungerar konstigt så jag baserade två rader kod här https://discussions.unity.com/t/why-are-my-controls-laggy/226089 Det är inte exakt samma men inte mina:=)

        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //Tar kontrollerna
        _rigidbody.velocity = _input.normalized * Speed;  //gör så att karaktären rör sig. Med speed.
        

        if (Input.GetKeyDown(KeyCode.Mouse0))//trycks då körs klassen
        {
          Shooting();
        }
        

        if (currentXP >= requiredXP) //ifall tillräcklig med xp så level up
        {
          NextLevel();
          
        }
        GunCooldown -= Time.deltaTime;
        
        
    }

    public void Shooting()
    {
      if (GunCooldown <= 0)
      {
      Instantiate(BulletPrefab, Gun.position, transform.rotation);//Instantiate spawnar objekten (bulletPrefab) på en specifik position (Gun.position)
      GunCooldown = GunCooldownTime;
      }
    }

    public void Death()
    {
      Destroy(gameObject);
      FindObjectOfType<TMP_Text>().enabled = true;
    }

    private void  OnCollisionEnter2D(Collision2D other)
    {
      var enemy = other.collider.GetComponent<ZombieController>();
        if (other.gameObject.tag == "Enemy") //specifierar att dne ska kollidera just med tag enemy. alltså att other är enemy.
        {
            
            Death(); //game over.
            
        }
    }

    public void NextLevel() //levla up spelaren
    {
      currentlevel++;
      currentXP -= requiredXP;
      requiredXP *= 1.4f;
      SpawnScript.SpawningSpeed *= 0.95f;
      LevelUpScript.ShowLevelScreen();//visa level up skärmen
    }


}
