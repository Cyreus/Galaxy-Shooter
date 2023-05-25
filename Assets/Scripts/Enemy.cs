using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _hiz = 6f;
    [SerializeField]
    private GameObject _laserPrefab;
    private Player _player;
    private Animator Anim;
    private float fireRate = 3.0f;
    private float canFire;
    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        CalculateMovement();

        if (Time.time > canFire)
        {
            fireRate = Random.Range(3f, 7f);
            canFire = Time.time + fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].assignEnemyLaser();
            }
        }

    }

    void CalculateMovement()
    {

        transform.Translate(Vector3.down * _hiz * Time.deltaTime);
        if (transform.position.y < -8f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 10, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Playerr")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.hasar();

            }

            Anim.SetTrigger("EnemyDestroy");
            _hiz = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 1.8f);

        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            Anim.SetTrigger("EnemyDestroy");
            _hiz = 0;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 1.8f);

        }

    }

}
