using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainPanel : BasePanel
{

	private Animator carrotAnimator;

	private Transform monsterTrans;

	private Transform cloudTrans;
	public Tween[] mainPanelTween; // 0 右移，1左移
	private Tween ExitTween;//离开页面运行动画
	protected override void Awake()
	{
		
		base.Awake();
		//获取成员变量
		transform.SetSiblingIndex(8);
		carrotAnimator = transform.Find("Emp_Carrot").GetComponent<Animator>();
		carrotAnimator.Play("CarrotGrow");
		mainPanelTween = new Tween[2];
		monsterTrans = transform.Find("Img_Monster");
		cloudTrans = transform.Find("Img_Cloud");

		mainPanelTween[0] = transform.DOLocalMoveX(1920, 0.5f);
		mainPanelTween[0].SetAutoKill(false);
		mainPanelTween[0].Pause();
		mainPanelTween[1] = transform.DOLocalMoveX(-1920, 0.5f);
		mainPanelTween[1].SetAutoKill(false);
		mainPanelTween[1].Pause();
		
		PlayUITweem();
	}

	public override void EnterPanel()
	{
		transform.SetSiblingIndex(8);
		carrotAnimator.Play("CarrotGrow");
		if (ExitTween != null)
		{
			ExitTween.PlayBackwards();
			
		}
		cloudTrans.gameObject.SetActive(true);
		
	}

	public override void ExitPanel()
	{
		ExitTween.PlayForward();
		cloudTrans.gameObject.SetActive(false);
	}

	/// <summary>
	/// UI动画播放
	/// </summary>
	private void PlayUITweem()
	{
		monsterTrans.DOLocalMoveY(550, 2f).SetLoops(-1, LoopType.Yoyo);
		cloudTrans.DOLocalMoveX(1300, 8f).SetLoops(-1, LoopType.Restart);
	}
	/// <summary>
	/// 场景状态切换的方法
	/// </summary>
	public void ToNormalModelScene()
	{
		mUIFacade.currentScenePanelDict[StringManager.GameLoadPanel].EnterPanel();
		mUIFacade.ChangeSceneState(new NormalGameOptionSceneState(mUIFacade));
		
	}

	public void ToBossModelScene()
	{
		mUIFacade.currentScenePanelDict[StringManager.GameLoadPanel].EnterPanel();
		mUIFacade.ChangeSceneState(new BossModelSceneState(mUIFacade));

	}

	public void ToMonsterNest()
	{
		mUIFacade.currentScenePanelDict[StringManager.GameLoadPanel].EnterPanel();
		mUIFacade.ChangeSceneState(new MonsterNestSceneState(mUIFacade));

	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void MoveToRight()
	{
		ExitTween = mainPanelTween[0];
		mUIFacade.currentScenePanelDict[StringManager.SetPanel].EnterPanel();
	}

	public void MoveToLeft()
	{
		ExitTween = mainPanelTween[1];
		mUIFacade.currentScenePanelDict[StringManager.HelpPanel].EnterPanel();
	}
}
