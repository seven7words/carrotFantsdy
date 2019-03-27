using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour, IBasePanel
{

	protected UIFacade mUIFacade;

	protected virtual void Awake()
	{
		mUIFacade = GameManager.Instance.uiManger.mUIFacade;
	}

	public virtual void InitPanel()
	{
	}

	public virtual void EnterPanel()
	{
	}

	public virtual void ExitPanel()
	{
	}
}
