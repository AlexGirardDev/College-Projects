using UnityEngine;
using System.Collections;
using GameStuff;

public class TerrainGate : MonoBehaviour, GameStuff.Terrain {
	
	int gridX, gridY;
	public Level level;
	bool open = false;
	float nextSwitchTime = 0;
	float xOffset = 0;
	float openSpeed = 0.1f, openElapsed = 0;
	
	// Use this for initialization
	void Start () {
		nextSwitchTime = Random.Range(4.0f, 7.0f);
	}
	
	// Update is called once per frame
	void Update () {
		nextSwitchTime -= Time.deltaTime;
		
		if (nextSwitchTime < 0)
		{
			/*if (!open)
			{
				if (xOffset != 0.75f)
				{
					if (openElapsed > openSpeed)
					{
						xOffset += 0.25f;
						renderer.material.SetTextureOffset("_MainTex", new Vector2(xOffset, 0));
						openElapsed = 0;
					}
					else
					{
						openElapsed += Time.deltaTime;
					}
				}
				else
				{
					nextSwitchTime = Random.Range(4.0f, 7.0f);
					open = true;
				}
				
				
			}
			else if (level.levelObjects[gridX, gridY] == null)
			{
				if (xOffset != 0f)
				{
					if (openElapsed > openSpeed)
					{
						xOffset -= 0.25f;
						renderer.material.SetTextureOffset("_MainTex", new Vector2(xOffset, 0));
						openElapsed = 0;						
					}
					else
					{
						openElapsed += Time.deltaTime;
					}
				}
				else
				{
					open = false;
					nextSwitchTime = Random.Range(4.0f, 7.0f);
				}	
			}*/
		}
	}
	
	public void setGridLocation(int x, int y)
	{
		gridX = x;
		gridY = y;
	}
	
	public bool canMoveThrough()
	{
		return open && xOffset == 0.75f;	
	}	
}
