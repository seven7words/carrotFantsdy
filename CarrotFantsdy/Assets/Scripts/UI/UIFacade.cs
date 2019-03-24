using System.Collections;
using System.Collections.Generic;
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
	private PlayerManager playerManager;
	
	
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
		
	}
	/// <summary>
	/// 初始化遮照
	/// </summary>
	public void InitMask()
	{
		canvasTransform = GameObject.Find("Canvas").transform;
//		mask = gameManager.factoryManager.factoryDict[FactoryType.UIFactory].GetItem("Img_Mask");
		mask = GetGameObjectResource(FactoryType.UIFactory, "Img_Mask");
		
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

}
