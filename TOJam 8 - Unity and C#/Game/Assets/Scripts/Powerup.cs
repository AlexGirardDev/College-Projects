using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	
	float disappearTimer = 10;
	public Level level;
	
	// Use this for initialization
	void Start () {
		disappearTimer = 10;
	}
	
	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		
		if (disappearTimer < 0 || level.winScreen)
		{
			Destroy(gameObject);	
		}
	}
}
