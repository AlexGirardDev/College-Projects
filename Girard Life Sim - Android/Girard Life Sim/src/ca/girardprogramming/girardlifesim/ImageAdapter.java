package ca.girardprogramming.girardlifesim;



import java.util.ArrayList;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;

public class ImageAdapter extends BaseAdapter {
	private Context mContext;
	

	public ImageAdapter(Context c) {
		mContext = c;
	}

	public int getCount() {
		return MainActivity.cellPicturesList.size();
	}

	public Object getItem(int position) {
		return null;
	}

	public long getItemId(int position) {
		return 0;
	}


	// create a new ImageView for each item referenced by the Adapter
	public View getView(int position, View convertView, ViewGroup parent) {	
		ImageView imageView;
		if (convertView == null) {
			imageView = new ImageView(mContext);
			if (MainActivity.numCellsWide != 0) {
				imageView.setLayoutParams(new GridView.LayoutParams(
					MainActivity.scrnWidth/	MainActivity.numCellsWide -1,
					MainActivity.scrnWidth/	MainActivity.numCellsWide -1));
			}

			imageView.setScaleType(ImageView.ScaleType.CENTER_CROP);

		} else {
			imageView = (ImageView) convertView;
		}

		imageView.setImageResource(MainActivity.cellPicturesList.get(position));
		return imageView;
	}


			
	

	
}