using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _hiz = 3.4f;
    
    private float _hizKatlayici = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _vurmaTemposu = 0.5f;
    private float _vurusBeklemesi = -1f;
    [SerializeField]
    private int _can = 3;
    [SerializeField]
    private GameObject shieldVisualizer;
    [SerializeField]
    private GameObject _leftEngine, _rightEngine;
    [SerializeField]
    private bool _isSingleMod=false;

    private bool isTripleshotActive = false;
    private bool isSpeedPowerActive = false;
    private bool isShieldPowerActive = false;
    [SerializeField]
    public bool isPlayerOne=false;
    [SerializeField]
    private bool isPlayerTwo=false;


    private Spawn_Manager spawnManager;

    [SerializeField]
    private int score,bestScore;
    public Text bestScores;
    
    

    private UI_Manager uýManager;
    [SerializeField]
    private AudioClip _laserAudio;
    [SerializeField]
    private AudioSource _laserAudioSource;
    [SerializeField]
    private bool _isCoopMode = false;
    public UI_Manager _uýManager;

    void Start()
    {
        if(_isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        uýManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _uýManager = GetComponent<UI_Manager>();

        _laserAudioSource = GetComponent<AudioSource>();
        if (_laserAudioSource == null)
        {
            Debug.Log("audio error");
        }
        else
        {
            _laserAudioSource.clip = _laserAudio;
        }


    }


    void Update()
    {
        if(_isSingleMod ==true)
        {
            hareketYonetimiPlayer1();
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _vurusBeklemesi)
            {
                atisPlayer1();
            }
        }
        
        if(isPlayerOne == true)
        {
            hareketYonetimiPlayer1();
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _vurusBeklemesi && isPlayerOne == true)
            {
                atisPlayer1();
            }
        }
        if(isPlayerTwo == true)
        {
            hareketYonetimiPlayer2();
            if (Input.GetKeyDown(KeyCode.KeypadPlus) && Time.time > _vurusBeklemesi && isPlayerTwo == true)
            {
                atisPlayer1();
            }

        }


    }

    #region Player1 Move
    public void hareketYonetimiPlayer1()
    {
        float dikeyHareket = Input.GetAxis("Horizontal");
        float yatayHareket = Input.GetAxis("Vertical");
       

        Vector3 Hareket = new Vector3(dikeyHareket, yatayHareket, 0);

        if(isSpeedPowerActive ==false)
        {

            transform.Translate(Hareket * _hiz * Time.deltaTime);
        }
        else
        {
            transform.Translate(Hareket * _hiz * _hizKatlayici * Time.deltaTime);

        }


        if (transform.position.y >= 10f)
        {
            transform.position = new Vector3(transform.position.x, 10f, 0);

        }
        else if (transform.position.y < -7.1f)
        {
            transform.position = new Vector3(transform.position.x, -7.1f, 0);

        }

        if (transform.position.x >= 16.2f)
        {
            transform.position = new Vector3(-16.2f, transform.position.y, 0);

        }
        else if (transform.position.x < -16.2f)
        {
            transform.position = new Vector3(16.2f, transform.position.y, 0);

        }
    }
    #endregion

    #region Player2 Move
    public void hareketYonetimiPlayer2()
    {
       

        if(Input.GetKey(KeyCode.Keypad8))
        {
            transform.Translate(Vector3.up * _hiz * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Keypad5))
        {
            transform.Translate(Vector3.down * _hiz * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Translate(Vector3.right * _hiz * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Translate(Vector3.left * _hiz * Time.deltaTime);
        }

        if (isSpeedPowerActive == false)
        {

            transform.Translate(Vector3.up * _hiz * Time.deltaTime);
            transform.Translate(Vector3.down * _hiz * Time.deltaTime);
            transform.Translate(Vector3.right * _hiz * Time.deltaTime);
            transform.Translate(Vector3.left * _hiz* Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * _hiz * _hizKatlayici * Time.deltaTime);
            transform.Translate(Vector3.down * _hiz * _hizKatlayici*Time.deltaTime);
            transform.Translate(Vector3.right * _hiz * _hizKatlayici* Time.deltaTime);
            transform.Translate(Vector3.left * _hiz * _hizKatlayici * Time.deltaTime);

        }





        if (transform.position.y >= 10f)
        {
            transform.position = new Vector3(transform.position.x, 10f, 0);

        }
        else if (transform.position.y < -7.1f)
        {
            transform.position = new Vector3(transform.position.x, -7.1f, 0);

        }

        if (transform.position.x >= 16.2f)
        {
            transform.position = new Vector3(-16.2f, transform.position.y, 0);

        }
        else if (transform.position.x < -16.2f)
        {
            transform.position = new Vector3(16.2f, transform.position.y, 0);

        }
    }
    #endregion

    #region AtisPlayer1
    void atisPlayer1()
    {
        _vurusBeklemesi = Time.time + _vurmaTemposu;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 2.14f, 0), Quaternion.identity);
        if (isTripleshotActive == true)
        {

            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 2.14f, 0), Quaternion.identity);
        }

        _laserAudioSource.Play();   
    }
    #endregion

    #region AtisPlayer2
    void atisPlayer2()
    {
        _vurusBeklemesi = Time.time + _vurmaTemposu;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 2.14f, 0), Quaternion.identity);
        if (isTripleshotActive == true)
        {

            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 2.14f, 0), Quaternion.identity);
        }

        _laserAudioSource.Play();


    }
    #endregion


    public void hasar()
    {
        if(isShieldPowerActive == true)
        {
            isShieldPowerActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        _can -= 1;

        if(_can == 2)
        {
            _leftEngine.SetActive(true);
        }
        else if(_can == 1)
        {
            _rightEngine.SetActive(true);
        }

         uýManager.UpdateLives(_can);

        if (_can < 1)
        {
            
            Destroy(this.gameObject);
            spawnManager.PlayerDeath();
        }
    }
    public void tripleShotActive()
    {
        isTripleshotActive = true;
        StartCoroutine(TripleShotDownRoutine());

    }
    public void SpeedBoostActive()
    {
        isSpeedPowerActive = true;
        StartCoroutine(SpeedBoostRoutine());

    }
    public void ShieldUpActive()
    {
        isShieldPowerActive = true;
        shieldVisualizer.SetActive(true);

    }
   
    IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(8.0f);
        isSpeedPowerActive = false;
    }
    IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleshotActive=false;

    }

    public void AddScore(int point)
    {
        score += point;
        uýManager.UpdateScore(score);
    }
    

}
