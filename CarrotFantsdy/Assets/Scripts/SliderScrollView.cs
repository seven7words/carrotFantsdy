using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScrollView : MonoBehaviour,IBeginDragHandler, IEndDragHandler
{
	private RectTransform contentTrans;
	private float beginMousePosX;
	private float endMousePosX;
	private ScrollRect _scrollRect;
	public int cellLength;
	public int spacing;
	public int leftOffset;
	private float moveOneItemLength;
	private int currentIndex;
	private Vector3 currentContentLocalPos;

	public int totalItemNum;

	private void Awake()
	{
		_scrollRect = GetComponent<ScrollRect>();
		contentTrans = _scrollRect.content;
		moveOneItemLength = cellLength + spacing;
		currentContentLocalPos = contentTrans.localPosition;
		currentIndex = 1;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		beginMousePosX = Input.mousePosition.x;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		endMousePosX = Input.mousePosition.x;
		float offSet = 0;
		float moveDistance = 0;//当次需要滑动的距离
		offSet = beginMousePosX - endMousePosX;
		if (offSet > 0)
		{
			//右滑
			if (currentIndex >= totalItemNum)
			{
				return;
			}

			moveDistance = -moveOneItemLength;
			currentIndex++;
			
		}
		else
		{
			//作滑
			if (currentIndex <= 1)
			{
				return;
			}

			moveDistance = moveOneItemLength;
			currentIndex--;
			
		}

		DOTween.To(() => contentTrans.localPosition, lerpValue => contentTrans.localPosition = lerpValue,
			currentContentLocalPos + new Vector3(moveDistance, 0, 0), 0.5f).SetEase(Ease.InOutQuint);
		Debug.Log("TRets");
		currentContentLocalPos +=new Vector3(moveDistance, 0,0);
	}
}
