using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _hiz= 8.0f;
    private bool _isEnemyLaser = false;

   
    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
        
    }
    void MoveUp()
    {
        transform.Translate(Vector3.up * _hiz * Time.deltaTime);
        if (transform.position.y > 9.6f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * _hiz * Time.deltaTime);
        if (transform.position.y < -9.6f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }

    }
    public void assignEnemyLaser()
    {
        _isEnemyLaser = true;  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Playerr" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();

            player.hasar();
        }
    }
}
