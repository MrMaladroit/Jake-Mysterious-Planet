using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isCollected = false;
    private SpriteRenderer renderer;
    private CircleCollider2D collider;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void Show()
    {
        renderer.enabled = true;
        collider.enabled = true;
    }

    private void Hide()
    {
        renderer.enabled = false;
        collider.enabled = false;
    }

    private void Collect()
    {
        isCollected = true;
        Hide();
        GameManager.instance.CollectedCoin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
}