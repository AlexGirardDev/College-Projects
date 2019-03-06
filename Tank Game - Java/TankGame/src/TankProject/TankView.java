package TankProject;

import java.awt.*;
import java.awt.image.*;
import javax.swing.JFrame;

public class TankView extends TankController {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private GraphicsDevice videoCard;

	// Give the video card access to the monitor
	public TankView() {
		GraphicsEnvironment env = GraphicsEnvironment
				.getLocalGraphicsEnvironment();
		videoCard = env.getDefaultScreenDevice();
	}

	// get current Display Mode
	public DisplayMode getCurrentDisplayMode() {
		return videoCard.getDisplayMode();
	}

	// Make frame full screen
	public void setFullScreen(DisplayMode displayMode) {
		JFrame fullScreenFrame;
		TankController tankController;

		fullScreenFrame = new JFrame();
		tankController = new TankController();
		fullScreenFrame.addKeyListener(tankController);
		fullScreenFrame.addMouseListener(tankController);
		fullScreenFrame.addMouseMotionListener(tankController);
		fullScreenFrame.setUndecorated(true);
		fullScreenFrame.setIgnoreRepaint(true);
		fullScreenFrame.setResizable(false);

		videoCard.setFullScreenWindow(fullScreenFrame);
		BufferedImage cursorImg = new BufferedImage(16, 16,
				BufferedImage.TYPE_INT_ARGB);
		Cursor blankCursor = Toolkit.getDefaultToolkit().createCustomCursor(
				cursorImg, new Point(0, 0), "blank cursor");
		fullScreenFrame.getContentPane().setCursor(blankCursor);
		if (displayMode != null && videoCard.isDisplayChangeSupported()) {
			try {
				videoCard.setDisplayMode(displayMode);
			} catch (Exception ex) {
			}
		}
		fullScreenFrame.createBufferStrategy(2);
	}


	// set Graphic Object equal to this
	public Graphics2D getGraphics() {
		Window window = videoCard.getFullScreenWindow();
		if (window != null) {
			BufferStrategy strategy = window.getBufferStrategy();
			return (Graphics2D) strategy.getDrawGraphics();
		} else {
			return null;
		}
	}

	// updates Display
	public void update() {
		Window window = videoCard.getFullScreenWindow();
		if (window != null) {
			BufferStrategy strategy = window.getBufferStrategy();
			if (!strategy.contentsLost()) {
				strategy.show();
			}
		}
	}

	// returns full screen window
	public Window getFullScreenWindow() {
		return videoCard.getFullScreenWindow();
	}

	// Leave full screen
	public void restoreScreen() {
		Window window = videoCard.getFullScreenWindow();
		if (window != null) {
			window.dispose();
		}
		videoCard.setFullScreenWindow(null);

	}
}
