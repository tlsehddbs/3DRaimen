using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
	[SerializeField]
	private	Scrollbar	scrollBar;					
	[SerializeField]
	private	GameObject[]	circleContents;
	[SerializeField]
	private	float		swipeTime = 0.2f;		
	[SerializeField]
	private	float		swipeDistance = 50.0f;		

	private	float[]		scrollPageValues;			
	private	float		valueDistance = 0;		
	private	int			currentPage = 0;			
	private	int			maxPage = 0;			
	private	float		startTouchX;			
	private	float		endTouchX;					
	private	bool		isSwipeMode = false;		
	private	float		circleContentScale = 1.6f;


	private RaimenExplain _explain;
	private void Awake()
	{
		
		circleContents = GameObject.FindGameObjectsWithTag("CircleObject");
		scrollPageValues = new float[transform.childCount];

		valueDistance = 1f / (scrollPageValues.Length - 1f);

	
		for (int i = 0; i < scrollPageValues.Length; ++ i )
		{
			scrollPageValues[i] = valueDistance * i;
		}

	
		maxPage = transform.childCount;
	}

	private void Start()
	{
	
		SetScrollBarValue(0);
	}

	public void SetScrollBarValue(int index)
	{
		currentPage		= index;
		scrollBar.value	= scrollPageValues[index];
	}

	private void Update()
	{
		UpdateInput();

	
		UpdateCircleContent();
	}

	private void UpdateInput()
	{
		//스와이프 가능할때 추가 작동 
		
		if ( isSwipeMode == true ) return;
		
		if ( Input.GetMouseButtonDown(0) )
		{
		
			startTouchX = Input.mousePosition.x;
		}
		else if ( Input.GetMouseButtonUp(0) )
		{
	
			endTouchX = Input.mousePosition.x;

			UpdateSwipe();
		}
		
	}

	private void UpdateSwipe()
	{
//스와이프 범위가 너무 작으면 움직이지 않음
		if ( Mathf.Abs(startTouchX-endTouchX) < swipeDistance )
		{
			StartCoroutine(OnSwipeOneStep(currentPage));
			return;
		}

		//마지막 터치값의 x값이 더 크다면 왼쪽으로 스와이핑 한것
		bool isLeft = startTouchX < endTouchX ? true : false;

		
		if ( isLeft == true )
		{
			
			if ( currentPage == 0 ) return;

		
			currentPage --;
		}
	
		else
		{
			
			if ( currentPage == maxPage - 1 ) return;

			
			currentPage ++;
		}
	
		
		StartCoroutine(OnSwipeOneStep(currentPage));
	}


	private IEnumerator OnSwipeOneStep(int index)
	{
		float start		= scrollBar.value;
		float current	= 0;
		float percent	= 0;

		isSwipeMode = true;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / swipeTime;

			scrollBar.value = Mathf.Lerp(start, scrollPageValues[index], percent);

			yield return null;
		}

		isSwipeMode = false;
	}

	private void UpdateCircleContent()
	{
		for (int i = 0; i < circleContents.Length; i++)
		{
			if (i >= transform.childCount)
			{
				circleContents[i].SetActive(false);
			}
		}
		
		for ( int i = 0; i < scrollPageValues.Length; ++ i )
		{
			circleContents[i].transform.localScale					= Vector2.one;
			circleContents[i].GetComponent<Image>().color	= Color.black;
			
			


			if ( scrollBar.value < scrollPageValues[i] + (valueDistance / 2) && scrollBar.value > scrollPageValues[i] - (valueDistance / 2) )
			{
				circleContents[i].transform.localScale					= Vector2.one * circleContentScale;
				circleContents[i].GetComponent<Image>().color	= Color.white;
				_explain = circleContents[i].GetComponent<RaimenExplain>();
			}
		}
		_explain.UpdateExplain();
	}
	
	
}