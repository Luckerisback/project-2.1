
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform arrowImage;
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    private Vector3 _min;
    private Vector3 _max;
   private void Start()
    {
        _min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        _max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
    }

    // Update is called once per frame
   private void Update()
    {
        if (transform.position.y < _min.y)
        {
            transform.position = spawnPoint.position;
            ArrowActivate();
        }
    }

   private async void ArrowActivate()
   {
       playerRigidbody2D.velocity = new Vector2(0, 0);
       while (transform.position.y > _max.y)
       {
           arrowImage.gameObject.SetActive(true);
           arrowImage.position = new Vector3(transform.position.x, arrowImage.position.y);
           await Task.Yield();
       }
       arrowImage.gameObject.SetActive(false);
   }
}
