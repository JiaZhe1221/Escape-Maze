/*
* Author: Leong Jia Zhe
* Date:11-05-2024
* Description: code for bullet
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public PlayerInfo player;
    public Shooting shooting;
    public GUI gui; // Reference to the GUI script for displaying error messages

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.hasGun)
            {
                if (shooting.GetCurrentAmmo() <= 20)
                {
                    shooting.IncreaseBullet();
                    Destroy(gameObject);
                }
                else
                {
                    gui.DisplayErrorMessage("Your bullet count is already at maximum!", 2f);
                }
            }
            else
            {
                gui.DisplayErrorMessage("You need a gun to pick up bullets!", 2f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
