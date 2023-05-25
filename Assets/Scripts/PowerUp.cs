using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _hiz = 3.5f;
    [SerializeField]
    private float _powerUpsID;
    [SerializeField]
    private AudioClip _audioClip;
    
    void Update()
    {
        transform.Translate(Vector3.down * _hiz * Time.deltaTime);

        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D diger)
    {
        if(diger.tag == "Playerr")
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position,100f);
           
            Player player = diger.transform.GetComponent<Player>();
            if(player != null)
            {
                switch (_powerUpsID)
                {
                   case 0:
                        player.tripleShotActive();
                        break;
                   case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldUpActive();
                        break;
                   default:
                        Debug.Log("default");
                        break;
                }
            }
            

            Destroy(this.gameObject);
        }
        
    }
}
