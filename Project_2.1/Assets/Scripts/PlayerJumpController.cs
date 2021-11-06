
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private PlayerControl_v2 playerControlV2;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    private bool _isSwipe;

    private void Start()
    {
        playerControlV2 = PlayerParametersInGame.PlayerControlV2;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.y > 8)
        {
            playerControlV2.Jump();
            upArrow.SetActive(true);
            downArrow.SetActive(false);
            _isSwipe = true;
        }
        else if (eventData.delta.y < -8 )
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            playerControlV2.DownJump();
            _isSwipe = true;
        }
        else
        {
            _isSwipe = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
    }
}
