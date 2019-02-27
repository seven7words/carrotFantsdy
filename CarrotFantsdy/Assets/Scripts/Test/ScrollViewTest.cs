using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewTest : MonoBehaviour,IScrollHandler,IBeginDragHandler,IEndDragHandler
{

	private ScrollRect _scrollRect;

	private RectTransform contentRectTransform;
	// Use this for initialization
	void Start ()
	{
		_scrollRect = GetComponent<ScrollRect>();
		//关于Recttransform的探究
		contentRectTransform = _scrollRect.content;
		//当前UI的世界坐标
		Debug.Log("当前Ui的世界坐标"+contentRectTransform.position);
		//当前Ui的局部坐标
		Debug.Log("当前Ui的局部坐标"+ contentRectTransform.localPosition);
		//当前UI的宽度(从左到右的长度)
		Debug.Log(contentRectTransform.rect.width);
		Debug.Log(contentRectTransform.rect.xMax);
		//当前UI的左坐标
		Debug.Log("左坐标"+contentRectTransform.rect.xMin);
		//不是localposition
		Debug.Log("左坐标"+contentRectTransform.rect.x);
		//高度
		Debug.Log("高度"+contentRectTransform.rect.height);
		//这个是要注意的，他只是当前tranform的x轴向的方向，自身方向的右方
		Debug.Log("高度"+contentRectTransform.right);
		//相对坐标，UI底部相对于顶部的相对长度，负数为向下延伸
		Debug.Log("y"+contentRectTransform.rect.y);
		
		
		//当前UI的宽高
		Debug.Log(contentRectTransform.sizeDelta);
		
		
//		Debug.Log(contentRectTransform.rect.right);
//		Debug.Log(contentRectTransform.rect.height);
		//宽度是相对的，差值，高度是总值
		contentRectTransform.sizeDelta = new Vector2(300, 0);

		//书翻页的需求， 水平滚动位置为0到1的值，0表示左侧，1表示右侧
		_scrollRect.horizontalNormalizedPosition = 0.2f;
		_scrollRect.onValueChanged.AddListener(printValue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnScroll(PointerEventData eventData)
	{
		Debug.Log(eventData);
		throw new System.NotImplementedException();
	}

	private void printValue(Vector2 vector2)
	{
//		Debug.Log("传递近来的参数值"+vector2);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("开始拖拽");
		throw new System.NotImplementedException();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("结束拖拽");
		throw new System.NotImplementedException();
	}
}
