package ca.girardprogramming.girardlifesim;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;

public class MainActivity extends Activity {
	// Number of cells Across the screen
	public static int numCellsWide = 7;

	// Number of cells Vertically on the screen
	public static int numCellsHeight = 15;

	// The state of all cells in the System
	public static List<List<Boolean>> cellCurrentState = new ArrayList<List<Boolean>>();

	// Temporary State of cells during a life cycle calculation
	public static List<List<Boolean>> cellTempState = new ArrayList<List<Boolean>>();

	public static GridView gridview; // Create gridview object

	// Arraylist of all states in picture format for use with imageadapter and
	
	public static ArrayList<Integer> cellPicturesList = new ArrayList<Integer>();

	public static int scrnWidth;// Screen width in pixels

	// Converts a position in gridview to corisponding x and y for use in 2d
	// State list array
	public ArrayList<Integer> convertPosToXY(int pos) {
		ArrayList<Integer> posxy = new ArrayList<Integer>();
		posxy.add(pos % numCellsWide);
		posxy.add(pos / numCellsWide);
		return posxy;
	}

	// Transfers the temp CellState list to Current
	public void cellTempToCurrent() {

		for (int a = 0; a < cellCurrentState.size(); a++) {
			cellCurrentState.get(a).clear();
			cellCurrentState.get(a).addAll(cellTempState.get(a));
		}

	}

	// Returns the cells fate in the next life cycle as a boolean
	public Boolean getCellFate(int x, int y) {

		int count = 0;

		// bottom left
		if ((x != 0) && (y != numCellsHeight - 1)) {
			if (cellCurrentState.get(x - 1).get(y + 1)) {
				count++;
			}
		}

		// middle left
		if ((x != 0)) {
			if (cellCurrentState.get(x - 1).get(y)) {
				count++;
			}
		}

		// top left
		if ((x != 0) && (y != 0)) {
			if (cellCurrentState.get(x - 1).get(y - 1)) {
				count++;
			}
		}

		// top middle
		if ((y != 0)) {
			if (cellCurrentState.get(x).get(y - 1)) {
				count++;
			}
		}

		// top right
		if ((x != numCellsWide - 1) && (y != 0)) {
			if (cellCurrentState.get(x + 1).get(y - 1)) {
				count++;
			}
		}

		// middle right
		if ((x != numCellsWide - 1)) {
			if (cellCurrentState.get(x + 1).get(y)) {
				count++;
			}
		}

		// bottom right
		if ((x != numCellsWide - 1) && (y != numCellsHeight - 1)) {
			if (cellCurrentState.get(x + 1).get(y + 1)) {
				count++;
			}
		}

		// bottom middle
		if (y != numCellsHeight - 1) {
			if (cellCurrentState.get(x).get(y + 1)) {
				count++;
			}
		}

		// Check how mant alive neighbour cells there were
		if (cellCurrentState.get(x).get(y)) {
			if (count == 2 || count == 3) {
				return true;

			} else {

				return false;

			}

		} else {

			if (count == 3) {
				return true;

			} else {

				return false;
			}
		}

	}

	// Updates the Picture list based on current cell states for use in gridview
	public void setPictureList() {
		cellPicturesList.clear();

		for (int a = 0; a < numCellsHeight; a++) {
			for (int b = 0; b < numCellsWide; b++) {

				if (MainActivity.cellCurrentState.get(b).get(a)) {
					cellPicturesList.add(R.drawable.r);
				} else {
					cellPicturesList.add(R.drawable.b);
				}
			}

		}

	}

	// Checks all cells for fate in next life cycle and updates it in the temp
	// State List
	public void updateCellStates() {

		for (int a = 0; a < numCellsWide; a++) {

			for (int b = 0; b < numCellsHeight; b++) {
				cellTempState.get(a).set(b, getCellFate(a, b));

			}

		}

	}

	// Fills the initial Cell state lists on Appilication open
	public void fillLists(int width, int height) {

		for (int a = 0; a < width; a++) {
			cellCurrentState.add(new ArrayList<Boolean>());
			cellTempState.add(new ArrayList<Boolean>());

			for (int b = 0; b < height; b++) {
				cellCurrentState.get(a).add(false);
				cellTempState.get(a).add(false);
			}
		}

		setPictureList();

	}

	// Get gridview from Activity and assign to gridview object

	private void setGridView() {
		gridview = (GridView) findViewById(R.id.gridview);
		gridview.setNumColumns(numCellsWide);

		gridview.setAdapter(new ImageAdapter(MainActivity.this));

		// Create on click listener for each cell in gridview

		gridview.setOnItemClickListener(new OnItemClickListener() {

			public void onItemClick(AdapterView<?> parent, View v,
					int position, long id) {
				int posx = convertPosToXY(position).get(0);
				int posy = convertPosToXY(position).get(1);
			

				// On cell click change check state and change to opposite
				if (cellCurrentState.get(posx).get(posy)) {
					cellCurrentState.get(posx).set(posy, false);
				} else {
					cellCurrentState.get(posx).set(posy, true);
				}

				setPictureList();

				gridview.invalidateViews();

			}
		});

	}

	// Get buttons from Activity and assign to objects
	public void setButtons() {

		Button generateButton, stepButton;

		generateButton = (Button) findViewById(R.id.btnGenerate);
		stepButton = (Button) findViewById(R.id.btnStep);

		// Set up onclick listener for Step button and asign methods when
		// clicked to execute one life cycle
		stepButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				updateCellStates();
				cellTempToCurrent();
				setPictureList();
				gridview.invalidateViews();

			}
		});

		generateButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {

				setGridView();

			}
		});

	}

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		getPlayInfo();
		setButtons();
		

		// Get screen width of device in pixels
		DisplayMetrics metrics = new DisplayMetrics();
		getWindowManager().getDefaultDisplay().getMetrics(metrics);

		scrnWidth = metrics.widthPixels;

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	//Get info from player on desired grid size.
	public void getPlayInfo() {

		AlertDialog.Builder widthAlert = new AlertDialog.Builder(this);
		AlertDialog.Builder alertHeight = new AlertDialog.Builder(this);

	
			widthAlert
					.setMessage("How many Cells Would you like across the screen?");
			final EditText widthInput = new EditText(this);
			widthAlert.setView(widthInput);
			widthAlert.setPositiveButton("Ok",
					new DialogInterface.OnClickListener() {
						public void onClick(DialogInterface dialog,
								int whichButton) {

							numCellsWide = Integer.parseInt(widthInput
									.getText().toString());
							fillLists(numCellsWide, numCellsHeight);

						}
					});
			widthAlert.show();

			alertHeight
					.setMessage("How many Cells Would you like Vertically on the screen?");

			final EditText inputHeight = new EditText(this);
			alertHeight.setView(inputHeight);
			alertHeight.setPositiveButton("Ok",
					new DialogInterface.OnClickListener() {
						public void onClick(DialogInterface dialog,
								int whichButton) {
							numCellsHeight = Integer.parseInt(inputHeight
									.getText().toString());
						}
					});
			alertHeight.show();
	

	}
}
