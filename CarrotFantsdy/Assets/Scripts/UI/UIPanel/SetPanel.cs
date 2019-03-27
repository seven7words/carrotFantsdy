using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;
using Image = UnityEngine.UI.Image;

public class SetPanel : BasePanel
{

	private GameObject OptionPageGo;
	private GameObject statisticsPageGo;
	private GameObject producerPageGo;
	private GameObject panelResetGo;
	private Tween setPanelTween;
	private bool playBGMusic = true;
	private bool playEffectMusic = true;
	public Sprite[] btnSprites;//0是音效开，1是音效管3，背景开4，背景关
	private Image imgBtnEffectAduio;
	private Image imgBtnBgAudio;
	public Text[] statisticesTexts;

	protected override void Awake()
	{
		base.Awake();
		setPanelTween = transform.DOLocalMoveX(0, 0.5f);
		setPanelTween.SetAutoKill(false);
		setPanelTween.Pause();
		OptionPageGo = transform.Find("OptionPage").gameObject;
		statisticsPageGo = transform.Find("StatisticsPage").gameObject;
		producerPageGo = transform.Find("ProducerPage").gameObject;
		imgBtnEffectAduio = OptionPageGo.transform.Find("Btn_EffectAudio").GetComponent<Image>();
		imgBtnBgAudio = OptionPageGo.transform.Find("Btn_BGAudio").GetComponent<Image>();
		panelResetGo = transform.Find("Panel_Reset").gameObject;
		InitPanel();
	}

	public override void InitPanel()
	{
		transform.localPosition = new Vector3(-1920,0,0);
		transform.SetSiblingIndex(2);
	}
	/// <summary>
	/// 显示界面的方法
	/// </summary>
	public void ShowOptionPage()
	{
		OptionPageGo.SetActive(true);
		statisticsPageGo.SetActive(false);
		producerPageGo.SetActive(false);
	}
	public void ShowStatisticsPage()
	{
		ShowStatistics();
		OptionPageGo.SetActive(false);
		statisticsPageGo.SetActive(true);
		producerPageGo.SetActive(false);
	}
	public void ShowOProducerPage()
	{
		OptionPageGo.SetActive(false);
		statisticsPageGo.SetActive(false);
		producerPageGo.SetActive(true);
	}

	public override void EnterPanel()
	{
		ShowOptionPage();
		MoveToCenter();
	}

	public override void ExitPanel()
	{
		setPanelTween.PlayBackwards();
		mUIFacade.currentScenePanelDict[StringManager.MainPanel].EnterPanel();
		InitPanel();
	}

	public void MoveToCenter()
	{
		setPanelTween.PlayForward();
	}
	/// <summary>
	/// 音乐处理
	/// </summary>
	public void CloseOrOpenBGMusic()
	{
		playBGMusic = !playBGMusic;
		mUIFacade.CloseOrOpenBGMusic();
		//TODO:audioManager处理
		if (playBGMusic)
		{
			imgBtnBgAudio.sprite = btnSprites[2];
		}
		else
		{
			imgBtnBgAudio.sprite = btnSprites[3];
		}
	}
	
	public void CloseOrOpenEffectMusic()
	{
		playEffectMusic = !playEffectMusic;
		mUIFacade.CloseOrOpenEffectMusic();
		if (playEffectMusic)
		{
			imgBtnEffectAduio.sprite = btnSprites[0];
		}
		else
		{
			imgBtnEffectAduio.sprite = btnSprites[1];
		}
	}
	/// <summary>
	/// 数据显示
	/// </summary>
	public void ShowStatistics()
	{
		PlayerManager playerManager = mUIFacade.playerManager;
		statisticesTexts[0].text = playerManager.adventureModelNum.ToString();
		statisticesTexts[1].text = playerManager.burriedLevelNum.ToString();
		statisticesTexts[2].text = playerManager.bossModelNum.ToString();
		statisticesTexts[3].text = playerManager.coin.ToString();
		statisticesTexts[4].text = playerManager.killMonsterNum.ToString();
		statisticesTexts[5].text = playerManager.killBossNum.ToString();
		statisticesTexts[6].text = playerManager.clearItemNum.ToString();
	}
	
	//TODO:重置游戏

	public void ResetGame()
	{
		
	}

	public void ShowResetPanel()
	{
		panelResetGo.SetActive(true);
	}

	public void CloseResetPanel()
	{
		panelResetGo.SetActive(false);
	}
}
