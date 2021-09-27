
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpController : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Weapon attackController;
    [SerializeField] private PlayerControl_v2 playerControlV2;
    private bool _isSwipe;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.y > 0)
        {
            playerControlV2.Jump();
            _isSwipe = true;
        }
        else if (eventData.delta.y < 0 )
        {
            playerControlV2.DownJump();
            _isSwipe = true;
        }
        else
        {
            _isSwipe = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isSwipe)
        {
            attackController.Shoot();
        }

        _isSwipe = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
