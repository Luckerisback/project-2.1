using Photon.Pun;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Realtime;

public class PlayerRespawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private Vector3 spawnPoint;
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
            transform.position = spawnPoint;
            ArrowActivate();
        }
    }

   private async void ArrowActivate()
   {
       playerRigidbody2D.velocity = new Vector2(0, 0);
       while (transform.position.y > _max.y)
       {
           PlayerParametersInGame.RespawnArrow.gameObject.SetActive(true);
           PlayerParametersInGame.RespawnArrow.transform.position = new Vector3(transform.position.x,  PlayerParametersInGame.RespawnArrow.transform.position.y);
           await Task.Yield();
       }
       PlayerParametersInGame.RespawnArrow.gameObject.SetActive(false);
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
