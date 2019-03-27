using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI中介，上层与管理者左交互，下层与ui面板左交互
/// </summary>
public class UIFacade
{

	private UIManger uiManger;
	private GameManager gameManager;
	private AudioSourceManager audioSourceManager;
	public PlayerManager playerManager;
	//场景状态
	public IBaseSceneState currentSceneState;

	public IBaseSceneState lastSceneState;
	//UI面板
	public Dictionary<string, IBasePanel> currentScenePanelDict = new Dictionary<string, IBasePanel>();

	//其他成员变量
	private GameObject mask;
	private Image maskImage;
	public Transform canvasTransform;

	public UIFacade(UIManger uiManager)
	{
		this.uiManger = uiManager;
		gameManager = GameManager.Instance;
		playerManager = GameManager.Instance.playerManager;
		audioSourceManager = GameManager.Instance.audioSourceManager;
		InitMask();
	}

	/// <summary>
	/// 初始化遮照
	/// </summary>
	public void InitMask()
	{
		canvasTransform = GameObject.Find("Canvas").transform;
//		mask = gameManager.factoryManager.factoryDict[FactoryType.UIFactory].GetItem("Img_Mask");
		mask = GetGameObjectResource(FactoryType.UIFactory, "Img_Mask");

		mask = CreateUIAndSetUIPosition("Img_Mask");
		maskImage = mask.GetComponent<Image>();

	}


	public void ChangeSceneState(IBaseSceneState baseSceneState)
	{
		lastSceneState = currentSceneState;
		ShowMask();
		currentSceneState = baseSceneState;
	}
	/// <summary>
	/// 显示遮照
	/// </summary>
	public void ShowMask()
	{
		mask.transform.SetSiblingIndex(10);
		Tween t = DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0,0,0,1),2f );
		t.OnComplete(ExitSceneComplete);

	}
	/// <summary>
	/// 离开当前场景
	/// </summary>
	private void ExitSceneComplete()
	{
		lastSceneState.ExitScene();
		currentSceneState.EnterScene();
		HideMask();
	}
	/// <summary>
	/// 隐藏遮照
	/// </summary>
	public void HideMask()
	{
		mask.transform.SetSiblingIndex(10);
		DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0,0,0,0),2f );

	}

	//获取资源的方法
	public Sprite GetSprite(string resourcePath)
	{
		return gameManager.GetSprite(resourcePath);

	}

	public AudioClip GetAudioSource(string resourcePath)
	{
		return gameManager.GetAudioClip(resourcePath);
	}

	public RuntimeAnimatorController GetRuntimeAnimatorController(string resourcePath)
	{
		return gameManager.GetRuntimeAnimatorController(resourcePath);
	}

	public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath)
	{
		return gameManager.GetGameObjectResource(factoryType, resourcePath);
	}

	public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
	{
		gameManager.PushGameObjectToFactory(factoryType, resourcePath, itemGo);
	}

	/// <summary>
	/// 实例化UI
	/// </summary>
	/// <returns></returns>
	public GameObject CreateUIAndSetUIPosition(string uiName)
	{
		GameObject itemGo = GetGameObjectResource(FactoryType.UIFactory, uiName);
		itemGo.transform.SetParent(canvasTransform);
		itemGo.transform.localPosition = Vector3.zero;
		itemGo.transform.localScale = Vector3.one;
		return itemGo;
	}

	/// <summary>
	/// 添加UIPanel到UIManager的字典
	/// </summary>
	/// <param name="uiPanelName"></param>
	public void AddPanelToDict(string uiPanelName)
	{
		uiManger.currentScenePanelDict.Add(uiPanelName, GetGameObjectResource(FactoryType.UIPanelFactory, uiPanelName));

	}

	/// <summary>
	/// 实例化当前场景所有面板，并存入字典
	/// </summary>
	public void InitDict()
	{
		foreach (var gameObject in uiManger.currentScenePanelDict)
		{
			gameObject.Value.transform.SetParent(canvasTransform);
			gameObject.Value.transform.localPosition = Vector3.zero;
			gameObject.Value.transform.localScale = Vector3.one;
			IBasePanel basePanel = gameObject.Value.GetComponent<IBasePanel>();
			if (basePanel == null)
			{
				Debug.Log("获取面板脚本失败");
			}
			else
			{
				basePanel.InitPanel();
				currentScenePanelDict.Add(gameObject.Key, basePanel);

			}
		}
	}

	/// <summary>
	/// 清空当前字典
	/// </summary>
	public void ClearDict()
	{
		currentScenePanelDict.Clear();
		uiManger.ClearDict();
	}
	//开关音乐
	public void CloseOrOpenBGMusic()
	{
		audioSourceManager.CloseBGMusic();
	}

	public void CloseOrOpenEffectMusic()
	{
		audioSourceManager.CloseOrOpenEffectMusic();
	}
}
	
	