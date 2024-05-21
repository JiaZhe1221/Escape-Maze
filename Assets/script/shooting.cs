/*
* Author: Leong Jia Zhe
* Date:12-05-2024
* Description: code for gun for player to shoot
*/

using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerInfo player; // Reference to the PlayerInfo component
    public LineRenderer bulletTrail;
    public GUI gui; // Reference to the GUI script
    public int maxAmmo = 10; // Maximum ammunition count
    public int ammoPerShot = 1; // Ammunition count consumed per shot
    private int currentAmmo; // Current ammunition count

    private void Start()
    {
        player = GetComponent<PlayerInfo>();
        currentAmmo = maxAmmo;
        bulletTrail.enabled = false;

        // Ensure that gui is properly assigned
        gui = FindObjectOfType<GUI>();
    }

    private void Update()
    {
        // Check for left mouse button click and available ammo
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            // Call the Shoot function
            Shoot();
        }
    }

    public void IncreaseBullet()
    {
        currentAmmo += 2;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        gui.UpdateGUI(currentAmmo); // Update GUI with new ammunition count
    }

    public int GetCurrentAmmo() // Method to get the current ammunition count
    {
        return currentAmmo;
    }

    // Function to handle shooting
    public void Shoot()
    {
        if (player.hasGun) // Check if the player has a gun
        {
            RaycastHit hit;
            Vector3 raycastOrigin = transform.position + transform.forward * 0.5f;
            // Decrement ammo count
            currentAmmo -= ammoPerShot;
            gui.UpdateGUI(currentAmmo); // Update GUI with new ammunition count

            // Perform the raycast
            if (Physics.Raycast(raycastOrigin, transform.forward, out hit))
            {
                Debug.Log(hit.collider.name);
                // Check if the raycast hits a creature
                if (hit.collider.CompareTag("Creature"))
                {
                    CreatureHealth creature = hit.collider.GetComponent<CreatureHealth>();
                    creature.TakeDamage(50); // Decrease creature's health
                }
                // Set line renderer positions
                bulletTrail.SetPosition(0, transform.position);
                bulletTrail.SetPosition(1, hit.point);
                // Enable the line renderer
                bulletTrail.enabled = true;
            }
            else
            {
                // If the raycast didn't hit anything, set line renderer to extend to maximum distance
                bulletTrail.SetPosition(0, transform.position);
                bulletTrail.SetPosition(1, transform.position + transform.forward * 100); // Extend the line renderer to a distant point
                bulletTrail.enabled = true;
            }
        }
        else
        {
        }
    }
}