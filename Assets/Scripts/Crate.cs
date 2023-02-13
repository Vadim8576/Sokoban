using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        //Debug.Log("Tолкать");
        //_playerMove = other.GetComponent<PlayerMove>();


        PlayerMove _playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();
     
        if (_playerMove)
        {
            Debug.Log("Tолкать");
            _playerMove._push = true;
            _playerMove._animator.SetBool("Run", false);
            _playerMove._animator.SetBool("Push", true);
            //this.transform.parent = other.transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMove _playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();
        if (_playerMove)
        {
            Debug.Log("Не толкать");
            _playerMove._push = false;
            _playerMove._animator.SetBool("Run", true);
            _playerMove._animator.SetBool("Push", false);
        }

    }

    */
}
