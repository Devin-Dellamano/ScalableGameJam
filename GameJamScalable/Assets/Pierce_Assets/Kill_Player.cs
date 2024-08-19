using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Player : MonoBehaviour
{

    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Player.GetComponent<PlayerMovement>().Kill = true;
        }
    }
}
