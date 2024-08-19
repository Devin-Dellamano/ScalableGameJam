using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_Scale : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Player.GetComponent<PlayerMovement>().NoScale = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Player.GetComponent<PlayerMovement>().NoScale = false;
        }
    }
}
