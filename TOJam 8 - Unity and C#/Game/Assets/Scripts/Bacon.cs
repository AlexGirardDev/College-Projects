using UnityEngine;
using System.Collections;
using GameStuff;

public class Bacon : MonoBehaviour, LevelObject {
	
	public int gridX, gridY;
	Level level;
	public BaconStreak streak;
	bool moving = false;
	float amountMoved = 0;
	Vector2 moveDirection;
	const float MOVE_SPEED = 90f;
	float moveSpeedModifier = 1;
	float wallCheck;
	
	
	// Use this for initialization
	void Start () {
		moveSpeedModifier = 1;
		wallCheck = Random.Range(4f, 8f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
		{
			float xMoveAmount = (moveDirection.x * (MOVE_SPEED * moveSpeedModifier) * Time.deltaTime);
			float yMoveAmount = (moveDirection.y * (MOVE_SPEED * moveSpeedModifier) * Time.deltaTime);
			
			if (moveDirection.x != 0)
			{
				xMoveAmount = Mathf.Min(xMoveAmount, Mathf.Abs(this.transform.position.x - (-(int)(level.levelWidth / 2) + gridX) * Level.GRID_WIDTH));
			}
			else if (moveDirection.y != 0)
			{
				yMoveAmount = Mathf.Min(yMoveAmount, Mathf.Abs(this.transform.position.y - (-(int)(level.levelWidth / 2) + gridY) * Level.GRID_WIDTH));
			}
			
			this.transform.position = new Vector3(this.transform.position.x + xMoveAmount,
												  this.transform.position.y + yMoveAmount, this.transform.position.z);
			
			amountMoved += ((MOVE_SPEED * moveSpeedModifier) * Time.deltaTime);
			
			if (amountMoved >= Level.GRID_WIDTH)
			{
				moving = false;
				
				if ((moveDirection.x < 0 && canMoveLeft(0)) ||
					(moveDirection.x > 0 && canMoveRight(0)) ||
					(moveDirection.y > 0 && canMoveUp(0)) ||
					(moveDirection.y < 0 && canMoveDown(0)))
				{
					amountMoved = 0;
					moving = true;
					
					BaconStreak b = Instantiate(streak, new Vector3(transform.position.x, transform.position.y, 0.1f), (moveDirection.x != 0) ? Quaternion.Euler(270, 0, 0) : Quaternion.Euler(0, 90, -90)) as BaconStreak;
					b.level = level;
					
					gridX += (int)moveDirection.x;
					gridY += (int)moveDirection.y;
				}
				else
				{
					amountMoved = 0;
					this.transform.position = new Vector3((-(int)(level.levelWidth / 2) + gridX) * Level.GRID_WIDTH , (-(int)(level.levelHeight / 2) + gridY) * Level.GRID_WIDTH, transform.position.z);
				}
			}
		}
		
		wallCheck -= Time.deltaTime;
		
		if (wallCheck < 0)
		{
			for (int i = 0; i < level.levelObjects.Count; i++)
			{
				if ((level.levelObjects[i].getGridX() == gridX && (Mathf.Abs(level.levelObjects[i].getGridY() - gridY) == 1)) ||
					(level.levelObjects[i].getGridY() == gridY && Mathf.Abs(level.levelObjects[i].getGridX() - gridX) == 1))
				{
					if (level.levelObjects[i].GetType().Name.Equals("Wall"))
					{
						int[] order = {0, 1, 2, 3};
						
						for (int j = 0; j < order.Length; j++)
						{
							int t = order[j];
							int r = Random.Range(0, order.Length);
							order[j] = order[r];
							order[r] = t;
						}
						
						for (int j = 0; j < 4; j++)
						{
							switch(order[j])
							{
							case 0:
								if (canMoveLeft(0))
								{
									move(new Vector2(-1, 0));	
								}
								break;
							case 1:
								if (canMoveRight(0))
								{
									move(new Vector2(1, 0));	
								}
								break;
								
							case 2:
								if (canMoveUp(0))
								{
									move(new Vector2(0, 1));	
								}
								break;
								
							case 3:
								if (canMoveDown(0))
								{
									move(new Vector2(0, -1));	
								}
								break;
							}
						}
						
						if (moving)
						{
							break;	
						}
					}
				}
			}
			
			wallCheck = Random.Range(4f, 68f);
		}
	}
	
	public bool canMoveLeft(int boxesToMove)
	{
		if (moving)
		{
			return false;	
		}
		
		if (gridX <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX - 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (boxesToMove <= 0)
				{
					return false;	
				}
				else
				{
					return level.levelObjects[i].canMoveLeft(boxesToMove - 1);	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveRight(int boxesToMove)
	{
		if (moving)
		{
			return false;	
		}
		
		if (gridX >= level.levelWidth - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX + 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (boxesToMove <= 0)
				{
					return false;	
				}
				else
				{
					return level.levelObjects[i].canMoveRight(boxesToMove - 1);	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveDown(int boxesToMove)
	{
		if (moving)
		{
			return false;	
		}
		
		if (gridY <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY - 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (boxesToMove <= 0)
				{
					return false;	
				}
				else
				{
					return level.levelObjects[i].canMoveDown(boxesToMove - 1);	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveUp(int boxesToMove)
	{
		if (moving)
		{
			return false;	
		}
		
		if (gridY >= level.levelHeight - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY + 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (boxesToMove <= 0)
				{
					return false;	
				}
				else
				{
					return level.levelObjects[i].canMoveUp(boxesToMove - 1);	
				}
			}
		}
		
		return true;
	}
	
	public void setGridLocation(int x, int y)
	{
		gridX = x;
		gridY = y;
	}
	
	public void setLevel(Level l)
	{
		level = l;	
	}
	
	public int getGridX()
	{
		return gridX;
	}
	
	public int getGridY()
	{
		return gridY;
	}
	
	public bool isMoving()
	{
		return moving;
	}
	
	public void setMoveSpeed(float newSpeed)
	{
		moveSpeedModifier = newSpeed;
	}
	
	public float getMoveSpeed()
	{
		return moveSpeedModifier;
	}
	
	public void move(Vector2 moveDirection)
	{
		if (!moving)
		{
			/*
			for (int i = 0; i < level.levelObjects.Count; i++)
			{
				if (level.levelObjects[i].getGridX() == gridX + moveDirection.x && level.levelObjects[i].getGridY() == gridY + moveDirection.y)
				{
					if (level.levelObjects[i].GetType().Name.Equals("Bacon"))
					{
						((Bacon)level.levelObjects[i]).move(moveDirection);
					}
					else if (level.levelObjects[i].GetType().Name.Equals("Candy"))
					{
						((Candy)level.levelObjects[i]).move(moveDirection);
					}
					else if (level.levelObjects[i].GetType().Name.Equals("Cookie"))
					{
						((Cookie)level.levelObjects[i]).move(moveDirection);
					}
				}
			}
			*/
			BaconStreak b = Instantiate(streak, new Vector3(transform.position.x, transform.position.y, 0.1f), (moveDirection.x != 0) ? Quaternion.Euler(270, 0, 0) : Quaternion.Euler(0, 90, -90)) as BaconStreak;
			b.level = level;
			
			this.moveDirection = moveDirection;
			moving = true;
				
			gridX += (int)moveDirection.x;
			gridY += (int)moveDirection.y;
		}
	}
	
	public void OnTriggerStay(Collider col)
	{
		BaconStreak b = col.gameObject.GetComponent<BaconStreak>();
		
		if (b != null)
		{
			setMoveSpeed(2f);	
		}
	}
	
	public void OnTriggerExit(Collider col)
	{
		BaconStreak b = col.gameObject.GetComponent<BaconStreak>();
		
		if (b != null)
		{
			setMoveSpeed(1f);	
		}
	}
}
