using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DotweenTest : MonoBehaviour
{

    private Image maskImage;

    private Tween maskTween;
	// Use this for initialization
	void Start ()
	{
	    maskImage = GetComponent<Image>();
        //1.doTween静态方法
	    //DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 0), 2f);
        //doTween 直接作用于Transform的方法
	    //Tween tween= transform.DOLocalMoveX(100, 2);
	    //tween.Play();
     //   //tween.PlayForward();
     //   tween.PlayBackwards();
        //结论，不管是直接倒着播放，还是先正播，再导播都不行
        //3.动画的循环使用
        maskTween = transform.DOLocalMoveX(100, 2);
	    maskTween.SetAutoKill(false);
	    maskTween.Pause();
        //4.动画的事件回调
        Tween tween = transform.DOLocalMoveX(100, 2);
	    tween.OnComplete(CompleteMethod);

        //5.设置动画的缓动函数以及循环状态跟次数
	    tween.SetEase(Ease.InOutBounce);
        //动画无穷次
	    tween.SetLoops(-1,LoopType.Incremental);
	}

    private void CompleteMethod()
    {
        DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 0), 2f);
    }
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
            //Tween对象的Play方法只能播一次（相对于倒播），不能倒播
	        maskTween.PlayForward();
	    }else if (Input.GetMouseButtonDown(1))
	    {
            maskTween.PlayBackwards();
	    }
	}
}
