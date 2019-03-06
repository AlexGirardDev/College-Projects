using UnityEngine;
using System.Collections;
using GameStuff;

public class Player : MonoBehaviour, LevelObject {
	
	bool moving = false;
	public Vector2 moveDirection;
	float amountMoved = 0;
	const float MOVE_SPEED = 50f;
	float moveSpeedModifier = 1f;
	public int extraBoxesToPush;
	public float boxCooldown;
	public Gum myGum;
	
	public int gridX, gridY;
	Level level;
	public int playerNumber = 0;
	float deadCheck = 1f;
	float xOffset;
	float shrinkTime = 0.15f, shrinkElapsed;
	public float stunTime;
	
	// Use this for initialization
	void Start () {
		moveSpeedModifier = 1;
	}
	
	// Update is called once per frame
	void Update () {
  
		if(!level.winScreen)
		{
			if (stunTime <= 0)
			{
		        float ControlerX = Input.GetAxis("HorizontalPlayer" + playerNumber);
		        float ControlerY = Input.GetAxis("VerticalPlayer" + playerNumber);
				
		        if (ControlerX != 0 || ControlerY != 0)
		        {
		            if (Mathf.Abs(ControlerX) > Mathf.Abs(ControlerY))
		            {
		                ControlerY = 0;
		            }
		            else
		            {
		                ControlerX = 0;
		            }
		        }
				
		        if (ControlerX != 0 && (!moving || moveDirection.x != 0))
		        {
		            if (ControlerX > 0 && moveDirection.x <= 0 && canMoveRight(0))
		            {
		                    moving = true;
		                    amountMoved = (moving ? Level.GRID_WIDTH - amountMoved : 0);
		                    moveDirection = new Vector2(1, 0);
		
		                    gridX += (int)moveDirection.x;
		                    gridY += (int)moveDirection.y;
		            }
		            else if (ControlerX < 0 && moveDirection.x >= 0 && canMoveLeft(0))
		            {
		                moving = true;
		                amountMoved = (moving ? Level.GRID_WIDTH - amountMoved : 0);
		                moveDirection = new Vector2(-1, 0);
		
		                gridX += (int)moveDirection.x;
		                gridY += (int)moveDirection.y;
		            }
		        }
		        else if (ControlerY != 0 && (!moving || moveDirection.y != 0))
		        {
		            if (ControlerY < 0 && moveDirection.y <= 0 && canMoveUp(0))
		            {
		                moving = true;
		                amountMoved = (moving ? Level.GRID_WIDTH - amountMoved : 0);
		                moveDirection = new Vector2(0, 1);
		                gridX += (int)moveDirection.x;
		                gridY += (int)moveDirection.y;
					}
		            else if (ControlerY > 0 && moveDirection.y >= 0 && canMoveDown(0))
		            {
		                moving = true;
		                amountMoved = (moving ? Level.GRID_WIDTH - amountMoved : 0);
		                moveDirection = new Vector2(0, -1);
		
		                gridX += (int)moveDirection.x;
		                gridY += (int)moveDirection.y;
		            }
		        }
				
				if (myGum != null)
				{
					if (Input.GetButton("APlayer" + playerNumber))
					{
						myGum.shoot(new Vector2(0, -1), gridX, gridY);
						myGum = null;
					}
					else if (Input.GetButton("BPlayer" + playerNumber))
					{
						myGum.shoot(new Vector2(1, 0), gridX, gridY);
						myGum = null;
					}
					else if (Input.GetButton("XPlayer" + playerNumber))
					{
						myGum.shoot(new Vector2(-1, 0), gridX, gridY);
						myGum = null;
					}
					else if (Input.GetButton("YPlayer" + playerNumber))
					{
						myGum.shoot(new Vector2(0, 1), gridX, gridY);
						myGum = null;
					}
				}
				
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
						moveSpeedModifier = 1;
						moveDirection.x = moveDirection.y = 0;
						this.transform.position = new Vector3((-(int)(level.levelWidth / 2) + gridX) * Level.GRID_WIDTH , (-(int)(level.levelHeight / 2) + gridY) * Level.GRID_WIDTH, transform.position.z);
					}
				}
				
				deadCheck -= Time.deltaTime;
				
				if (boxCooldown > 0)
				{
					boxCooldown -= Time.deltaTime;
				}
				else
				{
					if (extraBoxesToPush > 0)
					{
						extraBoxesToPush--;
						boxCooldown = 10;
					}
				}
			}
			else
			{
				stunTime -= Time.deltaTime;	
			}
			
			if (deadCheck < 0)
			{
				int surrounding = 0;
				
				for (int i = 0; i < level.levelObjects.Count; i++)
				{
					if (level.levelObjects[i].getGridX() == gridX && (level.levelObjects[i].getGridY() == gridY -1 || level.levelObjects[i].getGridY() == gridY + 1))
					{
						surrounding++;
					}
					else if (level.levelObjects[i].getGridY() == gridY && (level.levelObjects[i].getGridX() == gridX - 1 || level.levelObjects[i].getGridX() == gridX + 1))
					{
						surrounding++;	
					}
				}
				
				if (surrounding == 4)
				{
					level.playersAliveList.Remove(this);
					level.levelObjects.Remove(this);
					Destroy(gameObject);								
				}
				else
				{
					deadCheck = 0.5f;	
				}
			}	
		
			if (shrinkElapsed > shrinkTime)
			{
				shrinkElapsed = 0;
				
				if (this.transform.localScale.z == 1)
				{
					this.transform.localScale = new Vector3(1f, 1, .9f);
				}
				else
				{
					this.transform.localScale = new Vector3(1f, 1, 1f);	
				}
			}
			else
			{
				shrinkElapsed += Time.deltaTime;	
			}
		}
	}	
	
	public void setMoveSpeed(float speed)
	{
		moveSpeedModifier = speed;
	}
	
	public float getMoveSpeed()
	{
		return moveSpeedModifier;	
	}
	
	public int getGridX()
	{
		return gridX;	
	}
	
	public int getGridY()
	{
		return gridY;	
	}
	
	public bool canMoveLeft(int boxesToMove)
	{
		if (gridX <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX - 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Cookie"))
				{
					if(((Cookie)level.levelObjects[i]).canMoveLeft(extraBoxesToPush))
					{
						((Cookie)level.levelObjects[i]).move(new Vector2(-1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Bacon"))
				{
					if(((Bacon)level.levelObjects[i]).canMoveLeft(extraBoxesToPush))
					{
						((Bacon)level.levelObjects[i]).move(new Vector2(-1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Candy"))
				{
					if(((Candy)level.levelObjects[i]).canMoveLeft(extraBoxesToPush))
					{
						((Candy)level.levelObjects[i]).move(new Vector2(-1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Player") || level.levelObjects[i].GetType().Name.Equals("Wall"))
				{
					return false;	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveRight(int boxesToMove)
	{
		if (gridX >= level.levelWidth - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX + 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Cookie"))
				{
					if(((Cookie)level.levelObjects[i]).canMoveRight(extraBoxesToPush))
					{
						((Cookie)level.levelObjects[i]).move(new Vector2(1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Bacon"))
				{
					if(((Bacon)level.levelObjects[i]).canMoveRight(extraBoxesToPush))
					{
						((Bacon)level.levelObjects[i]).move(new Vector2(1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Candy"))
				{
					if(((Candy)level.levelObjects[i]).canMoveRight(extraBoxesToPush))
					{
						((Candy)level.levelObjects[i]).move(new Vector2(1, 0));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Player") || level.levelObjects[i].GetType().Name.Equals("Wall"))
				{
					return false;	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveDown(int boxesToMove)
	{
		if (gridY <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY - 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Cookie"))
				{
					if(((Cookie)level.levelObjects[i]).canMoveDown(extraBoxesToPush))
					{
						((Cookie)level.levelObjects[i]).move(new Vector2(0, -1));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Bacon"))
				{
					if(((Bacon)level.levelObjects[i]).canMoveDown(extraBoxesToPush))
					{
						((Bacon)level.levelObjects[i]).move(new Vector2(0, -1));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Candy"))
				{
					if(((Candy)level.levelObjects[i]).canMoveDown(extraBoxesToPush))
					{
						((Candy)level.levelObjects[i]).move(new Vector2(0, -1));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Player") || level.levelObjects[i].GetType().Name.Equals("Wall"))
				{
					return false;	
				}
			}
		}
		
		return true;
	}
	
	public bool canMoveUp(int boxesToMove)
	{
		if (gridY >= level.levelHeight - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY + 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Cookie"))
				{
					if(((Cookie)level.levelObjects[i]).canMoveUp(extraBoxesToPush))
					{
						((Cookie)level.levelObjects[i]).move(new Vector2(0, 1));
					}
					else
					{
						return false;	
					}		
				}	
				else if (level.levelObjects[i].GetType().Name.Equals("Bacon"))
				{
					if(((Bacon)level.levelObjects[i]).canMoveUp(extraBoxesToPush))
					{
						((Bacon)level.levelObjects[i]).move(new Vector2(0, 1));
					}
					else
					{
						return false;	
					}		
				}
				else if (level.levelObjects[i].GetType().Name.Equals("Candy"))
				{
					if(((Candy)level.levelObjects[i]).canMoveUp(extraBoxesToPush))
					{
						((Candy)level.levelObjects[i]).move(new Vector2(0, 1));
					}
					else
					{
						return false;	
					}		
				}
				else if (level.levelObjects[i].GetType().Name.Equals("Player") || level.levelObjects[i].GetType().Name.Equals("Wall"))
				{
					return false;	
				}
			}
		}
		
		return true;
	}
	
	public bool isMoving()
	{
		return moving;	
	}
	
	public void setGridLocation(int x, int y)
	{
		gridX = x;
		gridY = y;
	}
	
	public void setLevel(Level l)
	{
		this.level = l;	
	}	
	
	public void OnTriggerEnter(Collider col)
	{
		Powerup p = col.gameObject.GetComponent<Powerup>();
		
		if (p != null)
		{
			if (extraBoxesToPush < 2)
			{
				extraBoxesToPush++;
				boxCooldown = 10;
				Destroy(col.gameObject);
			}
		}
		
		Gum g = col.gameObject.GetComponent<Gum>();
		
		if (g != null)
		{
			if (g.pickedUp)
			{
				stunTime = 4;
				g.renderer.material = g.splat;
				g.splatted = true;
				g.moving = false;
			}
			else
			{
				myGum = g;
				myGum.pickedUp = true;
				myGum.gameObject.active = false;
			}
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
