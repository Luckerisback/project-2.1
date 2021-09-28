
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpController : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Weapon attackController;
    [SerializeField] private PlayerControl_v2 playerControlV2;
    private bool _isSwipe;
    private bool _isAttack;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (eventData.delta.y > 8)
        {
            playerControlV2.Jump();
            _isSwipe = true;
        }
        else if (eventData.delta.y < -8 )
        {
            playerControlV2.DownJump();
            _isSwipe = true;
        }
        else
        {
            _isSwipe = false;
        }
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
