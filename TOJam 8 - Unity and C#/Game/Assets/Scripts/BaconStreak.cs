using UnityEngine;
using System.Collections;

public class BaconStreak : MonoBehaviour {
	
	float TIME_TO_LIVE = 2f;
	float timeToFade = 1f;
	float timeElapsed = 0;
	public Level level;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		
		if (level.winScreen)
		{
			Destroy(gameObject);	
		}
		
		if (timeElapsed > timeToFade)
		{
			this.renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1 - (timeElapsed - timeToFade) / (TIME_TO_LIVE - timeToFade));	
		}
		
		if (timeElapsed > TIME_TO_LIVE)
		{
			Destroy(gameObject);	
		}
	}
}
