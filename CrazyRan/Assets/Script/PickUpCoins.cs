using UnityEngine;

public class PickUpCoins : MonoBehaviour
{
    [SerializeField] private Score _score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
            _score.coins += 1;
            _score.ScoreText();
        }
    }
}
