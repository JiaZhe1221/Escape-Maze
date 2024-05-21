using UnityEngine;
using System.Collections;

public class EndDoor : MonoBehaviour
{
    public PlayerInfo player; // Reference to the PlayerInfo component of the player
    public float openSpeed = 2f; // Speed at which the door opens
    public float slideDistance = 5f; // Distance to slide the door

    private bool isOpening = false; // Flag to track if the door is currently opening

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is player
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the player has the key
            if (player.hasKey)
            {
                // Open door
                if (!isOpening)
                {
                    isOpening = true;
                    StartCoroutine(OpenDoor());
                }
            }
            else
            {
                // Display error message if the player doesn't have the key
                GUI.Instance.DisplayErrorMessage("You need a key to open this door!", 3f);
            }
        }
    }

    IEnumerator OpenDoor()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.right * slideDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isOpening = false;
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
