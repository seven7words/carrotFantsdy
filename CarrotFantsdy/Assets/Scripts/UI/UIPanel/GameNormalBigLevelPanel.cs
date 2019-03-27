using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNormalBigLevelPanel : BasePanel
{

	public Transform bigLevelContentTrans;

	public int bigLevelPageCount;

	private SliderScrollView sliderScrollView;
	private PlayerManager playManager;

	private Transform[] bigLevelPage;
	private bool hasRigisterEvent;

}
