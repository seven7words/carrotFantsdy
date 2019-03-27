 using System.Collections;
using System.Collections.Generic;
 using System.Net;
 using DG.Tweening;
 using UnityEditor;
 using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;

public class SlideCanCoverScrollView : MonoBehaviour, IBeginDragHandler,IEndDragHandler
{

	/// <summary>
	/// 容器长度
	/// </summary>
	private float contentLength;
	
	private float beginMousePosX;

	private float endMousePosX;

	public ScrollRect _scrollRect;
	/// <summary>
	/// 上一个位置比例
	/// </summary>
	private float lastProportion;
	
	public int cellLength;
	/// <summary>
	/// 间隙
	/// </summary>
	public int spacing;
	/// <summary>
	/// 左偏移量
	/// </summary>
	public int leftOffset;
	/// <summary>
	/// 上限值
	/// </summary>
	private float upperLimit;
	/// <summary>
	/// 下限值
	/// </summary>
	private float lowerLimit;
	/// <summary>
	/// 移动第一个单元格的距离
	/// </summary>
	private float firstItemLength;
	/// <summary>
	/// 滑动一个单元格需要的距离
	/// </summary>
	private float oneItemLength;
	/// <summary>
	/// 滑动一个单元格所占比例
	/// </summary>
	private float oneItemProportion;
	/// <summary>
	/// 共有几个单元格
	/// </summary>
	public int totalItemNum;
	/// <summary>
	/// 当前单元格索引
	/// </summary>
	private int currentIndex;

	public Text pageText;

	private void Awake()
	{
		
		_scrollRect = GetComponent<ScrollRect>();
		contentLength = _scrollRect.content.rect.xMax - cellLength;
		firstItemLength = cellLength / 2 + leftOffset;
		oneItemLength = cellLength + spacing;
		oneItemProportion = oneItemLength / contentLength;
		upperLimit = 1 - firstItemLength / contentLength;
		lowerLimit = firstItemLength / contentLength;
		currentIndex = 1;
		_scrollRect.horizontalNormalizedPosition = 0;
		if (pageText != null)
		{
			pageText.text = currentIndex.ToString() + "/" + totalItemNum;
		}
//		Debug.Log(contentLength);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		beginMousePosX = Input.mousePosition.x;
		
	}

	public void OnEndDrag(PointerEventData eventData)
    {
        float offSetX = 0;
        endMousePosX = Input.mousePosition.x;
        offSetX = (beginMousePosX - endMousePosX)*2;
        if (Mathf.Abs(offSetX)>firstItemLength)//执行滑动动作的前提是要大于第一个需要滑动的距离
        {
            if (offSetX>0)//右滑
            {
                if (currentIndex>=totalItemNum)
                {
                    return;
                }
                int moveCount = 
                    (int)((offSetX - firstItemLength) / oneItemLength) + 1;//当次可以移动的格子数目
                currentIndex += moveCount;
                if (currentIndex>=totalItemNum)
                {
                    currentIndex = totalItemNum;
                }
                //当次需要移动的比例:上一次已经存在的单元格位置
                //的比例加上这一次需要去移动的比例
                lastProportion += oneItemProportion * moveCount;
                if (lastProportion>=upperLimit)
                {
                    lastProportion = 1;
                }
            }
            else //左滑
            {
                if (currentIndex <=1)
                {
                    return;
                }
                int moveCount =
                    (int)((offSetX + firstItemLength) / oneItemLength) - 1;//当次可以移动的格子数目
                currentIndex += moveCount;
                if (currentIndex <=1)
                {
                    currentIndex = 1;
                }
                //当次需要移动的比例:上一次已经存在的单元格位置
                //的比例加上这一次需要去移动的比例
                lastProportion += oneItemProportion * moveCount;
                if (lastProportion <= lowerLimit)
                {
                    lastProportion = 0;
                }
            }

            
        }
        DOTween.To(() => _scrollRect.horizontalNormalizedPosition, lerpValue => _scrollRect.horizontalNormalizedPosition = lerpValue, lastProportion, 0.5f).SetEase(Ease.OutQuint);
        if (pageText != null)
        {
			pageText.text = currentIndex.ToString() + "/" + totalItemNum;
            
        }

    }

	public void Init()
	{
		lastProportion = 0;
		currentIndex = 1;
		if (_scrollRect != null)
		{
			_scrollRect.horizontalNormalizedPosition = 0;
			if (pageText != null)
			{
				pageText.text = currentIndex.ToString() + "/" + totalItemNum;
            
			}
		}
	}
}
