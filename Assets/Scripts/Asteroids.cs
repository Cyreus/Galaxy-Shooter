using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField]
    private float _Hiz = 1.0f;
    [SerializeField]
    private GameObject _exploisonPrefab;
    void Update()
    {       
        transform.Rotate(Vector3.forward * _Hiz * Time.deltaTime);
        transform.Translate(Vector3.down * _Hiz * Time.deltaTime);      
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag =="Laser")
        {
            Instantiate(_exploisonPrefab,transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
            Destroy(this.gameObject);
        }
         Player player = Other.transform.GetComponent<Player>();
        if (Other.tag == "Playerr")
        {
            player.hasar();
            Instantiate(_exploisonPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
}
