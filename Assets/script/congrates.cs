/*
* Author: Leong Jia Zhe
* Date:14-05-2024
* Description: code for congratulations message 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class congrates : MonoBehaviour
{
    public GameObject endText;

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endText.SetActive(true);
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
