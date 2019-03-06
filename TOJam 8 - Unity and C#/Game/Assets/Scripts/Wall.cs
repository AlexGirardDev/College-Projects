using UnityEngine;
using System.Collections;
using GameStuff;

public class Wall : MonoBehaviour, LevelObject {

	public int gridX, gridY;
	Level level;
	Vector2 moveDirection;
	const float MOVE_SPEED = 50f;
	float moveSpeedModifier = 1;
	
	// Use this for initialization of OP
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool canMoveLeft(int boxesToMove)
	{
		return false;
	}
	
	public bool canMoveRight(int boxesToMove)
	{
		return false;
	}
	
	public void setMoveSpeed(float speed)
	{
		moveSpeedModifier = speed;	
	}
	
	public bool canMoveDown(int boxesToMove)
	{
		return false;
	}
	
	public bool canMoveUp(int boxesToMove)
	{
		return false;
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
		return false;	
	}
	
	public void setGridLocation(int x, int y)
	{
		gridX = x;
		gridY = y;
	}
	
	public float getMoveSpeed()
	{
		return moveSpeedModifier;	
	}
	
	public void setLevel(Level l)
	{
		this.level = l;	
	}
}
