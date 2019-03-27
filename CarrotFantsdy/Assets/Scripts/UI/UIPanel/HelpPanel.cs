using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HelpPanel : BasePanel
{

	private GameObject helpPageGo;
	private GameObject monsterPageGo;
	private GameObject towerPageGo;
	private SliderScrollView sliderScrollView;
	private SlideCanCoverScrollView sliderCanCoverScrollView;
	private Tween helpPanelTween;
	protected override void Awake()
	{
		base.Awake();
		helpPageGo = transform.Find("HelpPage").gameObject;
		monsterPageGo = transform.Find("MonsterPage").gameObject;
		towerPageGo = transform.Find("TowerPage").gameObject;
		sliderCanCoverScrollView =
			transform.Find("HelpPage").Find("Scroll View").GetComponent<SlideCanCoverScrollView>();
		sliderScrollView = transform.Find("TowerPage").Find("Scroll View").GetComponent<SliderScrollView>();
		helpPanelTween = transform.DOLocalMoveX(0, 0.5f);
		helpPanelTween.SetAutoKill(false);
		helpPanelTween.Pause();
		
	}
	
	//显示页面的方法
	public void ShowHelpPage()
	{
		helpPageGo.SetActive(true);
		monsterPageGo.SetActive(false);
		towerPageGo.SetActive(false);
	}
	
	public void ShowMonsterPage()
	{
		helpPageGo.SetActive(false);
		monsterPageGo.SetActive(true);
		towerPageGo.SetActive(false);
	}
	
	public void ShowTowerPage()
	{
		helpPageGo.SetActive(false);
		monsterPageGo.SetActive(false);
		towerPageGo.SetActive(true);
	}
	
	//处理面板的方法
	public override void InitPanel()
	{
		base.InitPanel();
		transform.localPosition = new Vector3(1920,0,0);
		transform.SetSiblingIndex(5);
		sliderScrollView.Init();
		sliderCanCoverScrollView.Init();
		ShowHelpPage();
		//TODO:其他处理
	}

	public override void EnterPanel()
	{
		base.EnterPanel();
		gameObject.SetActive(true);
		sliderScrollView.Init();
		sliderCanCoverScrollView.Init();
		MoveToCenter();
	}

	public override void ExitPanel()
	{
		base.ExitPanel();
		helpPanelTween.PlayBackwards();
		mUIFacade.currentScenePanelDict[StringManager.MainPanel].EnterPanel();
		
	}

	public void MoveToCenter()
	{
		helpPanelTween.PlayForward();
		
	}
}
