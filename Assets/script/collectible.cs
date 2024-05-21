using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType { Collectible1, Collectible2, Collectible3, Collectible4 };
    public CollectibleType collectibleType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerInfo component from the player GameObject
            PlayerInfo player = other.GetComponent<PlayerInfo>();
            if (player != null)
            {
                // Update the collectible status based on its type
                switch (collectibleType)
                {
                    case CollectibleType.Collectible1:
                        player.CollectCollectible1();
                        break;
                    case CollectibleType.Collectible2:
                        player.CollectCollectible2();
                        break;
                    case CollectibleType.Collectible3:
                        player.CollectCollectible3();
                        break;
                    case CollectibleType.Collectible4:
                        player.CollectCollectible4();
                        break;
                    default:
                        break;
                }

                // Optionally, destroy or disable the collectible GameObject
                Destroy(gameObject);
            }
        }
    }
}