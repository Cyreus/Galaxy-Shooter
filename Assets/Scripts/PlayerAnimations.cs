using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator _anim;
    private Player _player;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

   
    void Update()
    {
        if (_player.isPlayerOne == true)
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", false);

            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _anim.SetBool("PlayerTurnLeft", true);
                _anim.SetBool("PlayerTurnRight", false);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", true);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", false);
            }

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", false);

            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                _anim.SetBool("PlayerTurnLeft", true);
                _anim.SetBool("PlayerTurnRight", false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", true);
            }
            else if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                _anim.SetBool("PlayerTurnLeft", false);
                _anim.SetBool("PlayerTurnRight", false);
            }
        }
        

    }
}
