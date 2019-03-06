package TankProject;

import java.awt.Image;

public class TankModel {

	private float tankPosX;
	private float tankPosY;
	private float tankTurretPosX;
	private float tankTurretPosY;
	private float tankVelX;
	private float tankVelY;
	private double turretAngle;
	private double tankAngle;
	private float MousePosX;
	private float MousePosY;
	private float velocity;
	private Image image;

	// Constructor
	public TankModel(Image image) {
		// Create Default Tank Properties
		this.image = image;
		tankVelX = 0.0f;
		tankVelY = 0.0f;
		tankPosX = 400 - (image.getWidth(null) / 2);
		tankPosY = 300 - (image.getHeight(null) / 2);
		velocity = 0.0f;
	}

	// Change Position
	public void update() {
		tankPosX += tankVelX;
		tankPosY += tankVelY;
	}

	// Return Velocity
	public float getVelocity() {
		return velocity;
	}

	// set Horizontal Velocity
	public void setVelocity(float velocity) {
		this.velocity = velocity;
	}

	// Return Turret X position
	public float getTurretXPosition() {
		return tankTurretPosX;
	}

	// set Turret X position
	public void setXTurretPosition(float Turretx) {
		tankTurretPosX = Turretx;
	}

	// Return Turret Y position
	public float getTurretYPosition() {
		return tankTurretPosY;
	}

	// set Turret Y position
	public void setYTurretPosition(float Turrety) {
		tankTurretPosY = Turrety;
	}

	public float getXPosition() {
		return tankPosX;
	}

	// set X position
	public void setXPosition(float x) {
		tankPosX = x;
	}

	// Return Y position
	public float getYPosition() {
		return tankPosY;
	}

	// set Y position
	public void setYPosition(float y) {
		tankPosY = y;
	}

	// Return mouse x position
	public float getMousePosX() {
		return MousePosX;
	}

	// set mouse X position
	public void setMousePosX(float xm) {
		MousePosX = xm;
	}

	// Return mouse Y position
	public float getMousePosY() {
		return MousePosY;
	}

	// set mouse Y position
	public void setMousePosY(float my) {
		MousePosY = my;
	}

	// Return Sprite Width
	public int getWidth() {
		return image.getWidth(null);
	}

	// Return Sprite Height
	public int getHeight() {
		return image.getHeight(null);
	}

	// Return Horizontal velocity
	public float getVelocityX() {
		return tankVelX;
	}

	// Return Horizontal velocity
	public void setVelocityX(float tankVelX) {
		this.tankVelX = tankVelX;
	}

	// Return Vertical velocity
	public float getVelocityY() {
		return tankVelY;
	}

	// set Vertical velocity
	public void setVelocityY(float tankVelY) {
		this.tankVelY = tankVelY;
	}

	// Return Image
	public Image getImage() {
		return image;
	}

	// set Tank angle
	public void setTankAngle(double tankAngle) {
		this.tankAngle = tankAngle;
	}

	// Return Tank angle
	public double getTankAngle() {
		return tankAngle;
	}

	// set Turret Angle
	public void setTurretAngle(double turretAngle) {
		this.turretAngle = turretAngle;
	}

	// Return Turret Angle
	public double getTurretAngle() {
		return turretAngle;
	}
}
