using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tолкать");
        _playerMove._push = true;
        _playerMove._animator.SetBool("Run", false);
        _playerMove._animator.SetBool("Push", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Не толкать");
        _playerMove._push = false;
        _playerMove._animator.SetBool("Run", true);
        _playerMove._animator.SetBool("Push", false);
    }
}
