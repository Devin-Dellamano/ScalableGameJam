using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Player.GetComponent<PlayerMovement>().Win = true;
        }
    }
}
