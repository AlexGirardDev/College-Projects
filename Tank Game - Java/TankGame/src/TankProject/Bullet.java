package TankProject;

import java.awt.Image;

public class Bullet {

	private float bulletPosX;
	private float bulletPosY;
	private float bulletVelX;
	private float bulletVelY;
	private float velocity;
	private double bulletAngle;
	private Image image;

	// Constructor
	public Bullet(float x, float y, Image image) {
		// Create Default Properties
		this.image = image;
		bulletPosX = x - 4;
		bulletPosY = y - 4;
		velocity = 10;
	}

	// change position
	public void update() {
		bulletPosX += bulletVelX;
		bulletPosY += bulletVelY;
	}

	// Returns TRUE if bullet is on the screen
	public boolean onScreen() {
		boolean onScreen = true;

		if (bulletPosX > 800 || bulletPosX < 0) {
			onScreen = false;
		}
		if (bulletPosY > 600 || bulletPosY < 0) {
			onScreen = false;
		}
		return onScreen;
	}

	// Returns Tanks Speed velocity is equal to the pixels traveled per update
	public float getVelocity() {
		return velocity;
	}

	// Returns Horizontal velocity
	public void setVelocity(float velocity) {
		this.velocity = velocity;
	}

	// Returns X Position
	public float getXPosition() {
		return bulletPosX;
	}

	// Returns Y Position
	public float getYPosition() {
		return bulletPosY;
	}

	// Returns Horizontal velocity
	public float getVelocityX() {
		return bulletVelX;
	}

	// Returns Vertical velocity
	public float getVelocityY() {
		return bulletVelY;
	}

	// Returns Image
	public Image getImage() {
		return image;
	}

	// Set bullets Velocity based on the direction of the turret
	public void fire(double turretAngle) {
		bulletAngle = (Math.PI / 2 + turretAngle);
		bulletVelX = (float) ((Math.cos(bulletAngle)) * velocity) * -1;
		bulletVelY = (float) ((Math.sin(bulletAngle)) * velocity) * -1;
	}
}
