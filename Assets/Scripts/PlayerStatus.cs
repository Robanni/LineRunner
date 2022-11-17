using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _playerRidgedbodys;

    private bool _isDead = false;

    private void Awake()
    {
        EnableRidgedbodyKinematic(true);
    }

    private void Update()
    {
        DeathCheck();
    }
    private void EnableRidgedbodyKinematic(bool status)
    {
        for (int i = 0; i < _playerRidgedbodys.Length; i++)
        {
            _playerRidgedbodys[i].isKinematic = status;
        }
    }

    private void DeathCheck()
    {
        if (_isDead)
        {
            EnableRidgedbodyKinematic(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            _isDead = true;
        }
    }
   
}
