/*
* Author: Leong Jia Zhe
* Date:05-05-2024
* Description: code for gun collect
*/


using UnityEngine;

public class Gun : MonoBehaviour
{
    // Collect the gun when user enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInfo player = other.GetComponent<PlayerInfo>();
            if (player != null)
            {
                player.CollectGun();
                Destroy(gameObject);
            }
        }
    }
}
