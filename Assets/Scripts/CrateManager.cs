using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject crate;
    public void PushBox()
    {
        Debug.Log("PushBox");
        crate.transform.parent = player.transform;
    }

    public void DoNotPushBox()
    {
        crate.transform.parent = player.transform;
    }
}
