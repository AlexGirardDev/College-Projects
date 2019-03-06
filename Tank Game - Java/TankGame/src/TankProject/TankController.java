package TankProject;

import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.geom.AffineTransform;
import java.io.IOException;
import java.lang.Math;
import java.util.ArrayList;
import javax.imageio.ImageIO;
import javax.swing.*;

public class TankController extends JFrame implements KeyListener,
		MouseListener, MouseMotionListener {

	public static void main(String[] args) {

		String[] startButton = { "Start", "Cancel" };
		int response = JOptionPane.showOptionDialog(null, "\n"
				+ "Objective: \n" + "\n"
				+ "You have been selected to manouver the tank \n"
				+ "and destroy all enemies and their leader. \n"
				+ "Do what you must and Destroy!!! \n" + "\n" + "Controls: \n"
				+ "\n" + "Up (W) - Increases tank speed \n"
				+ "Down (S) - Decreases tank speed \n"
				+ "Left (A) - Turns tank left \n"
				+ "Right (D) - Turns tank right \n" + "Space - Stops tank \n"
				+ "Left Click shoots bullets \n"
				+ "Mouse movement controls crosshair \n" + "\n",
				"Super tankModel World", JOptionPane.PLAIN_MESSAGE,
				
				JOptionPane.NO_OPTION, null, startButton, null);

		switch (response) {
		case 0:
			TankController tankController = new TankController();
			tankController.run();
			break;
		case 1:
			String[] close = { "Close" };
			JOptionPane.showOptionDialog(null, "Thank you for playing: \n"
					+ "\n" + "Super tankModel World \n \n"
					+ "Created by: Team Baller Status \n",
					"Super tankModel World", JOptionPane.CLOSED_OPTION,
					JOptionPane.CLOSED_OPTION, null, close, null);
		}

	}

	// Creating Global Objects and Primitives
	public static TankModel tank;
	public static TankView tankView;
	public static Image background;
	public static Image tankTurret;
	public static Image tankFrame;
	public static Image crosshair;
	public static Image bulletImage;
	public static int ammo = 0;
	public static int key;
	public static double fuel = 500;
	public static ArrayList<Bullet> bulletList = new ArrayList<Bullet>();

	// Load Images and Scenes
	public void loadImages()  {
            try{
                
              /*  
                ClassLoader cldr = this.getClass().getClassLoader();
java.net.URL imageURL   = cldr.getResource("/resources/images/MapBackground_800x600.jpg");
background = ImageIO.read(imageURL);

*/


		background = ImageIO.read( this.getClass().getResourceAsStream("/resources/images/MapBackground_800x600.jpg"));
		tankTurret =ImageIO.read(this.getClass().getResourceAsStream("/resources/images/tankTurret.png"));
		tankFrame = ImageIO.read(this.getClass().getResourceAsStream("/resources/images/tankFrame1.png"));
		bulletImage = ImageIO.read(this.getClass().getResourceAsStream("/resources/images/cannon.png"));
		tank = new TankModel(tankFrame);
		crosshair = ImageIO.read(this.getClass().getResourceAsStream("/resources/images/crosshair.png"));
            }catch (Exception e)
            {
              e.printStackTrace();
                
                
            }
	}

	// Method that creates bullet objects
	public void createBullet() {
		Bullet bullet = new Bullet(
				(tank.getXPosition() + (tank.getWidth() / 2)),
				(tank.getYPosition() + (tank.getHeight() / 2)), bulletImage);
		bullet.fire(tank.getTurretAngle());
		bulletList.add(bullet);
	}

	// Resets Ammo
	public void reload() {
		ammo = 0;
	}

	// run method called in Main method
	public void run() {
		try {
			tankView = new TankView();
			DisplayMode displayMode = new DisplayMode(800, 600, 16, 0);
			tankView.setFullScreen(displayMode);
			loadImages();
			runGraphics();
		} catch (Exception ex) {
			tankView.restoreScreen();
		}
	}

	// run graphics
	public void runGraphics() {

		// Create variables
		double currentAngle;
		double velocityX;
		double velocityY;

		do {
			fuel = fuel + (tank.getVelocity() *0.01);
			if (fuel < 1)
			{
				tank.setVelocity(0);
			fuel = 0;
			}
			// instantiate Graphic Objects
			Graphics2D gBullet = tankView.getGraphics();
			Graphics2D gBG = tankView.getGraphics();
			Graphics2D gTurret = tankView.getGraphics();
			Graphics2D gTank = tankView.getGraphics();
			Graphics2D gCrosshair = tankView.getGraphics();

			// turret rotation
			AffineTransform TurretTurn = new AffineTransform();

			tank.setMousePosX(MouseInfo.getPointerInfo().getLocation().x);
			tank.setMousePosY(MouseInfo.getPointerInfo().getLocation().y);
			tank.setTurretAngle((double) (Math.atan2(
					(tank.getYPosition() + (tank.getHeight() / 2))
							- tank.getMousePosY(),
					(tank.getXPosition() + (tank.getWidth() / 2))
							- tank.getMousePosX())) - 1.570795);

			TurretTurn.rotate(tank.getTurretAngle(),
					(tank.getXPosition() + (tank.getWidth() / 2)),
					(tank.getYPosition() + (tank.getHeight() / 2)));
			gTurret.transform(TurretTurn);

			// tank rotation
			AffineTransform TankTurn = new AffineTransform();

			TankTurn.rotate(Math.toRadians(tank.getTankAngle()),
					(tank.getXPosition() + (tank.getWidth() / 2)),
					(tank.getYPosition() + (tank.getHeight() / 2)));
			gTank.transform(TankTurn);
			if (tank.getTankAngle() > (360)) {
				tank.setTankAngle(0);
				if (tank.getTankAngle() < 0) {
					tank.setTankAngle(360);
				}
			}

			// Calculates X and Y velocity
			currentAngle = (Math.PI / 2 + Math.toRadians(tank.getTankAngle()));
			velocityX = (Math.cos(currentAngle)) * tank.getVelocity();
			velocityY = (Math.sin(currentAngle)) * tank.getVelocity();
			// Sets tanks X and Y velocity
			tank.setVelocityX((float) (velocityX));
			tank.setVelocityY((float) (velocityY));

			// draw graphics
			tank.setXTurretPosition(tank.getXPosition());
			tank.setYTurretPosition(tank.getYPosition());
			drawBG(gBG);
			drawTank(gTank);
			drawBullet(gBullet);
			drawTurret(gTurret);
			drawCrosshair(gCrosshair);

			// dispose of old graphics
			gBG.dispose();
			gTank.dispose();
			gBullet.dispose();
			gTurret.dispose();
			gCrosshair.dispose();

			// update the screen with new graphics
			update();
			tankView.update();

			// Allow computer time to catch up between update cycles

			try {
				Thread.sleep(5);

			} catch (InterruptedException e) {
				e.printStackTrace();
				System.out.println();
			}
		} while (tank != null);
	}

	// Draws background Graphics
	public void drawBG(Graphics gBG) {

		gBG.drawImage(background, 0, 0, null);
		
		//Fuel Label
		gBG.drawString("Fuel: " + Double.toString((int) fuel), 50, 50);
		//Out of Fuel Warning
		if (fuel < 1) {
			gBG.setColor(Color.red);
			gBG.drawString("Out of Fuel", 110, 50);
		}
		//Ammo Label
		gBG.setColor(Color.black);
		gBG.drawString("Ammo: " + Double.toString(50-ammo), 50, 65);
		
		//Out of Ammo Warning
		if (ammo > 49) {
			gBG.setColor(Color.red);
			gBG.drawString("Out of ammo", 110, 65);
		}
		
		//Copyright
		gBG.setColor(Color.red);
		gBG.drawString("Team Baller Status (c)", 10, 10);
	}
	// draw tank graphics
	public void drawTank(Graphics gTank) {
		gTank.drawImage(tank.getImage(), Math.round(tank.getXPosition()),
				Math.round(tank.getYPosition()), null);
	}

	// draw turret Graphic
	public void drawTurret(Graphics gTurret) {
		gTurret.drawImage(tankTurret, Math.round(tank.getXPosition()),
				Math.round(tank.getYPosition()), null);
	}

	// draw reticle Graphic
	public void drawCrosshair(Graphics gCrosshair) {
		gCrosshair.drawImage(crosshair, ((int) tank.getMousePosX()) - 10,
				((int) tank.getMousePosY()) - 10, this);
	}

	// Draw bullet Graphics
	public void drawBullet(Graphics gBullet) {
		try {
			for (int i = 0; i <= bulletList.size() - 1; i++) {
				gBullet.drawImage(bulletList.get(i).getImage(),
						Math.round(bulletList.get(i).getXPosition()),
						Math.round(bulletList.get(i).getYPosition()), null);
			}
		} catch (Exception e) {}
	}

	public void update() {
		// Update Tank's positioning and sets velocity to 0 if it reaches
		// boundaries
		if (tank.getXPosition() < 0) {
			if (tank.getVelocityX() <= 0)
				tank.setVelocityX(0.0f);
		} else if (tank.getXPosition() + tank.getWidth() > 800) {
			if (tank.getVelocityX() >= 0) {
				tank.setVelocityX(0.0f);
			}
		}
		if (tank.getYPosition() < 0) {
			if (tank.getVelocityY() <= 0) {
				tank.setVelocityY(0.0f);
			}
		} else if (tank.getYPosition() + tank.getHeight() > 600) {
			if (tank.getVelocityY() >= 0) {
				tank.setVelocityY(0.0f);
			}
		}
		tank.update();

		// Update Bullets's positioning and removes objects if off screen
		try {
			for (int i = 0; i <= bulletList.size() - 1; i++) {
				if (bulletList.get(i).onScreen() == false) {
					bulletList.remove(i);
				}
				bulletList.get(i).update();
			}
		} catch (Exception e) {
			
		}
	}

	// HOTKEYS
	@Override
	public void keyPressed(KeyEvent e) {
		int key;
		key = e.getKeyCode();

		// Up arrow: increase Velocity
		if (key == 38 || key == 87) {
			if (tank.getVelocity() >= 0.04f && tank.getVelocity() <= -0.04f) {
				tank.setVelocity(0.0f);
			}
			tank.setVelocity(tank.getVelocity() - 0.5f);
			if (tank.getVelocity() < -10) {
				tank.setVelocity(-10);
			}
		}
		// Down arrow: decrease Velocity
		if (key == 40 || key == 83) {
			if (tank.getVelocity() >= 0.04f && tank.getVelocity() <= -0.04f) {
				tank.setVelocity(0.0f);
			}
			tank.setVelocity(tank.getVelocity() + 1f);
			if (tank.getVelocity() >= 0) {
				tank.setVelocity(0f);
			}
		}

		// Right arrow: Turn tank in a clockwise Direction
		if (key == 39 || key == 68) {
			tank.setTankAngle(tank.getTankAngle() + 5);
		}

		// Left Arrow: Turn tank in a counter clockwise direction
		if (key == 37 || key == 65) {
			tank.setTankAngle(tank.getTankAngle() - 5);
		}

		// Space Bar: Stops tank completely
		if (key == 32) {
			tank.setVelocity(0.0f);
			tank.setVelocityX(0.0f);
			tank.setVelocityY(0.0f);
		}

		// "esc" Key: Exits Program
		if (key == 27) {
			System.exit(0);
		}

		// "R" Key: resets ammo
		if (key == 82) {
			reload();
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {

	}

	@Override
	public void keyTyped(KeyEvent e) {
	}

	@Override
	public void mouseClicked(MouseEvent c) {

	}

	@Override
	public void mouseEntered(MouseEvent c) {

	}

	@Override
	public void mouseExited(MouseEvent c) {

	}

	// Mouse Press: Fires Bullets and Decreases ammo
	@Override
	public void mousePressed(MouseEvent c) {
		if (ammo <= 49) {
			createBullet();
			ammo++;
		} 
	}

	@Override
	public void mouseReleased(MouseEvent c) {
	}

	@Override
	public void mouseDragged(MouseEvent m) {
	}

	@Override
	public void mouseMoved(MouseEvent m) {
	}
}
