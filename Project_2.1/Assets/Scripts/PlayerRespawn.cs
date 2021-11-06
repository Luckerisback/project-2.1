using Photon.Pun;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Realtime;

public class PlayerRespawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform arrowImage;
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    private Vector3 _min;
    private Vector3 _max;
    public GameObject PlayerPrefab;

    private void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);

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

   public override void OnPlayerEnteredRoom(Player newPlayer)
   {
       Debug.LogFormat($"Player {newPlayer.NickName} entered the room.");
   }

   public override void OnPlayerLeftRoom(Player otherPlayer)
   {
       Debug.LogFormat($"Player {otherPlayer.NickName} left the room.");
   }

}
