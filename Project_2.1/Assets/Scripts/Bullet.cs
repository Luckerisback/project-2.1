using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        if (PlayerParametersInGame.IsFaceRight)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }

        StartCoroutine(DestroyCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
