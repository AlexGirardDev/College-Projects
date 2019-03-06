using UnityEngine;
using System.Collections;

public class Gum : MonoBehaviour {

	float disappearTimer = 8;
	public Level level;
	public bool pickedUp, moving, splatted;
	Vector2 moveDirection;
	const float MOVE_SPEED = 140f;
	int gridX, gridY;
	float amountMoved, deadDelay;
	
	public Material splat, flying;
	
	// Use this for initialization
	void Start () {
		disappearTimer = 8;
	}
	
	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		
		if ((disappearTimer < 0 || level.winScreen) && !pickedUp)
		{
			Destroy(gameObject);	
		}
		
		if (moving)
		{
			float xMoveAmount = (moveDirection.x * MOVE_SPEED * Time.deltaTime);
			float yMoveAmount = (moveDirection.y * MOVE_SPEED * Time.deltaTime);
			
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
			
			amountMoved += (MOVE_SPEED * Time.deltaTime);
			
			if (amountMoved >= Level.GRID_WIDTH)
			{
				collider.enabled = true;
				moving = false;
				
				if ((moveDirection.x < 0 && canMoveLeft()) ||
					(moveDirection.x > 0 && canMoveRight()) ||
					(moveDirection.y > 0 && canMoveUp()) ||
					(moveDirection.y < 0 && canMoveDown()))
				{
					amountMoved = 0;
					moving = true;
										
					gridX += (int)moveDirection.x;
					gridY += (int)moveDirection.y;
				}
				else
				{
					amountMoved = 0;
					this.transform.position = new Vector3((-(int)(level.levelWidth / 2) + (gridX + moveDirection.x)) * Level.GRID_WIDTH , (-(int)(level.levelHeight / 2) + (gridY + moveDirection.y)) * Level.GRID_WIDTH, transform.position.z);
					renderer.material = splat;
					splatted = true;
				}
			}
		}
		
		if (splatted)
		{
			if (deadDelay < 4)
			{
				deadDelay += Time.deltaTime;	
				Debug.Log(deadDelay);
			}
			else
			{
				this.gameObject.active = false;
				Destroy(this);	
			}
		}		
	}
	
	public bool canMoveLeft()
	{
		if (gridX <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX - 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Player"))
				{
					((Player)level.levelObjects[i]).stunTime = 4;
					moving = false;
					renderer.material = splat;
					splatted = true;
				}	
				
				return false;	
			}
		}
		
		return true;
	}
	
	public bool canMoveRight()
	{
		if (gridX >= level.levelWidth - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridX() == gridX + 1 && level.levelObjects[i].getGridY() == gridY)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Player"))
				{
					((Player)level.levelObjects[i]).stunTime = 4;
					moving = false;
					renderer.material = splat;
					splatted = true;
				}
				
				return false;	
			}
		}
		
		return true;
	}
	
	public bool canMoveDown()
	{
		if (gridY <= 0)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY - 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Player"))
				{
					((Player)level.levelObjects[i]).stunTime = 4;
					moving = false;
					renderer.material = splat;
					splatted = true;
				}
				
				return false;	
			}
		}
		
		return true;
	}
	
	public bool canMoveUp()
	{
		if (gridY >= level.levelHeight - 1)
		{
			return false;	
		}
		
		for (int i = 0; i < level.levelObjects.Count; i++)
		{
			if (level.levelObjects[i].getGridY() == gridY + 1 && level.levelObjects[i].getGridX() == gridX)
			{
				if (level.levelObjects[i].GetType().Name.Equals("Player"))
				{
					((Player)level.levelObjects[i]).stunTime = 4;
					moving = false;
					renderer.material = splat;
					splatted = true;
				}
				
				return false;	
			}
		}
		
		return true;
	}
	
	public void shoot(Vector2 moveDirection, int x, int y)
	{
		this.gridX = x;
		this.gridY = y;
		collider.enabled = false;
		this.transform.position = new Vector3((-(int)(level.levelWidth / 2) + (gridX + moveDirection.x)) * Level.GRID_WIDTH , (-(int)(level.levelHeight / 2) + (gridY + moveDirection.y)) * Level.GRID_WIDTH, transform.position.z);
		this.renderer.material = flying;
		
		if (moveDirection.x < 0)
		{	
			if (canMoveLeft())
			{
				renderer.material.SetTextureScale("_MainTex", new Vector2(-1, 1));	
			}
			else
			{
				this.renderer.material = splat;	
			}
		}
		else if (moveDirection.x > 0)
		{
			if (canMoveRight())
			{
				renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));	
			}
			else
			{
				this.renderer.material = splat;	
			}
		}
		else if (moveDirection.y > 0)
		{
			if (canMoveUp())
			{
				transform.rotation = Quaternion.Euler(0, 90, -90);
			}
			else
			{
				this.renderer.material = splat;	
			}
		}
		else if (moveDirection.y < 0)
		{
			if (canMoveDown())
			{
				transform.rotation = Quaternion.Euler(0, -90, 90);
			}
			else
			{
				this.renderer.material = splat;	
			}
		}
		
		gameObject.active = true;
		
		if (!splatted)
		{
			this.moveDirection = moveDirection;
			moving = true;
					
			this.gridX += (int)moveDirection.x;
			this.gridY += (int)moveDirection.y;
		}
	}
}
