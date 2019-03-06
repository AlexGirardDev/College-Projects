using UnityEngine;
using System.Collections;
using GameStuff;
using System.IO;
using System.Collections.Generic;

public class Level : MonoBehaviour {
	//Karl's OP level is over 9000!!!!!
	public string levelName;
	public static float GRID_WIDTH = 10f;
	public Player player;
	public Cookie cookie;
	public Bacon bacon;
	public Candy candy;
	public Powerup powerup;
	public Gum gum;
	public Wall wall;	
	public GUIText[] endGameText;
	public Material[] players;
	public Material[] walls;
	int playerNum = 1;
	public int levelWidth, levelHeight;
	public float nextPowerUpTime, nextGumTime;
	public int playersAlive;
	public bool winScreen;
	public bool[] used;
	public float boxTime = 10;
	
	public List<LevelObject> levelObjects;
	public List<Player>playersAliveList = new List<Player>();
	public GameStuff.Terrain[,] terrainObjects;
	
	// Use this for initialization of over 9000!!
	void Start () {
		used = new bool[players.Length];
		
		levelName = "level" + Random.Range(1, 4);
		
		FileStream fs = new FileStream(Application.dataPath + "\\levels\\" + levelName + ".txt", FileMode.Open, FileAccess.Read);
		StreamReader sr = new StreamReader(fs);
		
		List<string> fileData = new List<string>();
		string curLine = sr.ReadLine();
		int maxWidth = 0;
		
		while (curLine != null)
		{
			fileData.Add(curLine);
			
			if (curLine.Length > maxWidth)
			{
				maxWidth = curLine.Length;	
			}
			
			curLine = sr.ReadLine();
		}
		
		sr.Close();	
		fs.Close();
		
		levelObjects = new List<LevelObject>();
		
		levelWidth = maxWidth - 1;
		levelHeight = fileData.Count - 1; 
		
		string[] controllers = Input.GetJoystickNames();
		
		int gridX = -(int)(maxWidth / 2);
		int gridY = -(int)(levelHeight / 2);
		
		for (int i = 0; i < fileData.Count; i++)
		{
			string line = fileData[i];
			
			for (int j = 0; j < maxWidth; j++)
			{
				if (line[j] == 'C')
				{
					LevelObject l = (LevelObject)Instantiate(cookie, new Vector3(gridX * Level.GRID_WIDTH, gridY * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Cookie;
					l.setGridLocation(gridX + (int)(levelWidth / 2), gridY + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}	
				else if (line[j] == 'B')
				{
					LevelObject l = (LevelObject)Instantiate(bacon, new Vector3(gridX * Level.GRID_WIDTH, gridY * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Bacon;
					l.setGridLocation(gridX + (int)(levelWidth / 2), gridY + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}	
				else if (line[j] == 'D')
				{
					LevelObject l = (LevelObject)Instantiate(candy, new Vector3(gridX * Level.GRID_WIDTH, gridY * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Candy;
					l.setGridLocation(gridX + (int)(levelWidth / 2), gridY + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}
				else if (line[j] == 'P')
				{
					if (playerNum <= controllers.Length)
					{
						LevelObject l = (LevelObject)Instantiate(player, new Vector3(gridX * Level.GRID_WIDTH, gridY * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Player;	
						l.setGridLocation(gridX + (int)(levelWidth / 2), gridY + (int)(levelHeight / 2));
						l.setLevel(this);
						((Player)l).playerNumber = Mathf.Min(playerNum++, 4);
						
						int nextMaterial = Random.Range(0, used.Length);
						
						while (used[nextMaterial])
						{
							nextMaterial = Random.Range(0, used.Length);	
						}
						
						((Player)l).renderer.material = players[nextMaterial];
						used[nextMaterial] = true;
						
						levelObjects.Add(l);
						playersAliveList.Add(((Player)l));
					}
				}
				else if (line[j] == 'W')
				{
					Quaternion rotation;
					
					if (gridX == -(int)(levelWidth / 2) - 1 && (gridY != -levelHeight / 2 && gridY != levelHeight / 2 + 1))
					{
						rotation = Quaternion.Euler(0, -90, 90);
					}
					else if (gridX == levelWidth / 2 && (gridY != -levelHeight / 2 && gridY != levelHeight / 2 + 1))
					{
						rotation = Quaternion.Euler(0, 90, -90);
					}
					else
					{
						rotation = Quaternion.Euler(270, 0, 0);	
					}
					
					LevelObject l = (LevelObject)Instantiate(wall, new Vector3(gridX * Level.GRID_WIDTH, gridY * Level.GRID_WIDTH, 0), rotation) as Wall;	
					l.setGridLocation(gridX + (int)(levelWidth / 2), gridY + (int)(levelHeight / 2));
					l.setLevel(this);
					
					if (gridX <= -(int)(levelWidth / 2) || gridY <= -levelHeight / 2 || gridY >= levelHeight / 2 || gridX >= levelWidth / 2)
					{
						((MonoBehaviour)l).gameObject.renderer.material = walls[0];
					}
					else
					{
						((MonoBehaviour)l).gameObject.renderer.material = walls[1];
					}
					
					levelObjects.Add(l);
				}
				
				gridX++;
			}
			
			gridY++;
			gridX = -(int)(maxWidth / 2);
		}		
		
		playersAlive = playerNum - 1;
		
		sr.Close();
		fs.Close();
		
		nextPowerUpTime = Random.Range(4f, 6f);
		nextGumTime = Random.Range(6f, 8f);
	}
	
	private bool isGate(int x, int y)
	{
		for (int i = 0; i < levelObjects.Count; i++)
		{
			if (levelObjects[i].getGridX() == x && levelObjects[i].getGridY() == y)
			{
				if (levelObjects[i].GetType().Name.Equals("Wall"))
				{
					return true;	
				}
			}
		}
		
		return false;
	}
	
	private bool isFree(int x, int y)
	{
		for (int i = 0; i < levelObjects.Count; i++)
		{
			if (levelObjects[i].getGridX() == x && levelObjects[i].getGridY() == y)
			{
				return false;	
			}
		}
		
		return true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (nextPowerUpTime < 0 && !winScreen)
		{
			int x = Random.Range(1, levelWidth - 1);		
			int y = Random.Range(1, levelHeight - 1);
			
			Powerup p = Instantiate(powerup, new Vector3((-(int)(levelWidth / 2) + x) * Level.GRID_WIDTH , (-(int)(levelHeight / 2) + y) * Level.GRID_WIDTH, -0.1f), Quaternion.Euler(270, 0, 0)) as Powerup;
			p.level = this;
			
			nextPowerUpTime = Random.Range(4f, 6f);
		}
		else
		{
			nextPowerUpTime -= Time.deltaTime;
		}
		
		if (boxTime < 0)
		{
			boxTime = 10;
			
			for (int i = 0; i < 3; i++)
			{
				int x = Random.Range(1, levelWidth - 1);		
				int y = Random.Range(1, levelHeight - 1);
				
				while (!isFree(x, y))
				{
					x = Random.Range(1, levelWidth - 1);		
					y = Random.Range(1, levelHeight - 1);	
				}
				
				x -= levelWidth / 2;
				y -= levelHeight / 2;
				
				int type = Random.Range(0, 10);
				
				if (type < 5)
				{
					LevelObject l = (LevelObject)Instantiate(cookie, new Vector3(x * Level.GRID_WIDTH, y * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Cookie;
					l.setGridLocation(x + (int)(levelWidth / 2), y + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}	
				else if (type < 8)
				{
					LevelObject l = (LevelObject)Instantiate(bacon, new Vector3(x * Level.GRID_WIDTH, y * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Bacon;
					l.setGridLocation(x + (int)(levelWidth / 2), y + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}	
				else
				{
					LevelObject l = (LevelObject)Instantiate(candy, new Vector3(x * Level.GRID_WIDTH, y * Level.GRID_WIDTH, 0), Quaternion.Euler(270, 0, 0)) as Candy;
					l.setGridLocation(x + (int)(levelWidth / 2), y + (int)(levelHeight / 2));
					l.setLevel(this);
					
					levelObjects.Add(l);
				}
			}
		}
		else
		{
			boxTime -= Time.deltaTime;	
		}
		
		if (nextGumTime < 0 && !winScreen)
		{
			int x = Random.Range(1, levelWidth - 1);		
			int y = Random.Range(1, levelHeight - 1);
			
			while (isGate(x, y))
			{
				x = Random.Range(1, levelWidth - 1);		
				y = Random.Range(1, levelHeight - 1);
			}
			
			Gum g = Instantiate(gum, new Vector3((-(int)(levelWidth / 2) + x) * Level.GRID_WIDTH , (-(int)(levelHeight / 2) + y) * Level.GRID_WIDTH, -0.1f), Quaternion.Euler(270, 0, 0)) as Gum;
			g.level = this;
			
			nextGumTime = Random.Range(6f, 8f);
		}
		else
		{
			nextGumTime -= Time.deltaTime;
		}
		
		if (playersAliveList.Count <= 1 && !winScreen)
		{
			winScreen = true;
			
			for (int i = 0; i < levelObjects.Count; i++)
			{
				Destroy(((MonoBehaviour)levelObjects[i]).gameObject);
			}
			
			Player winnerWinnerChickenDinner = Instantiate(playersAliveList[0], new Vector3(0, 0, 0), Quaternion.Euler(270, 0, 0)) as Player;
			((MonoBehaviour)winnerWinnerChickenDinner).transform.localScale = new Vector3(5, 1, 5);
				
			for (int i = 0; i < endGameText.Length; i++)
			{
				endGameText[i].gameObject.active = true;	
			}
				
			endGameText[0].text = "Player " + winnerWinnerChickenDinner.playerNumber + " Wins!";
		
		}
		
		if (winScreen)
		{
			if (Input.GetButton("Start"))
			{
				Application.LoadLevel("Menu");	
			}
		}
	}
}
