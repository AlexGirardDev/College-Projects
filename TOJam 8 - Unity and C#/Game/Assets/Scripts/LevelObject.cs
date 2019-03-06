using System;

namespace GameStuff
{
	public interface LevelObject
	{
		bool canMoveLeft(int boxesToMove);
		bool canMoveRight(int boxesToMove);
		bool canMoveDown(int boxesToMove);
		bool canMoveUp(int boxesToMove);
		void setGridLocation(int x, int y);
		void setLevel(Level l);
		int getGridX();
		int getGridY();
		bool isMoving();
		void setMoveSpeed(float newSpeed);
		float getMoveSpeed();
	}
}

