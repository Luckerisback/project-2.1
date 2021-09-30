
using UnityEngine;

public class EnemyGetHit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidbody2D;
    [SerializeField] private float forceSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (PlayerParametersInGame.PlayerTransform.position.x < transform.position.x)
            {
                enemyRigidbody2D.velocity = new Vector2(forceSpeed, 0);
            }
            else
            {
                enemyRigidbody2D.velocity = new Vector2(-forceSpeed, 0);
            }
        }
    }
}
