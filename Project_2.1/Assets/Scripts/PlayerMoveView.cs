using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveView : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private PlayerControl_v2 playerControlV2;
    private Vector2 _startPos;
    private bool _swipeRight;
    private const float _swipeRange = 50;


    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.x > 0 && eventData.position.x > _startPos.x + _swipeRange)
        {
            _startPos.x = eventData.position.x;
            playerControlV2.Walk(1);
            playerControlV2.SetWalkAnim();
            if (!playerControlV2.faceRight)
            {
                playerControlV2.Reflect();
            }
            
        }
        else if (eventData.delta.x < 0 && eventData.position.x < _startPos.x - _swipeRange)
        {
            _startPos.x = eventData.position.x;
            playerControlV2.SetWalkAnim();
            playerControlV2.Walk(-1);
            if (playerControlV2.faceRight)
            {
                playerControlV2.Reflect();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerControlV2.IdleState();
        playerControlV2.Walk(0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
