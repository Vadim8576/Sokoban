using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();
        if (playerMove)
        {
            Debug.Log("Tолкать");
            playerMove._push = true;
            playerMove._animator.SetBool("Run", false);
            playerMove._animator.SetBool("Push", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMove playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();
        if (playerMove)
        {
            Debug.Log("Не толкать");
            playerMove._push = false;
            playerMove._animator.SetBool("Run", true);
            playerMove._animator.SetBool("Push", false);
        }

    }
}
