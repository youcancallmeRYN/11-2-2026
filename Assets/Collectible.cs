using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.AddCollectible();
            Destroy (gameObject);
        }
    }
}
