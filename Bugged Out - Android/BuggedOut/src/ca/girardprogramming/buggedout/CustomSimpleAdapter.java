package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.SimpleAdapter;

public class CustomSimpleAdapter extends SimpleAdapter {

	
	//I created a custom SimpleAdapter to let me change the row colour based on the value inside
	//as well as it let me put my put my issueInfo onclick listeners to help keep things clean 
	
	private List<HashMap<String, String>> results;
	private Context appContext;
	private Integer resource;

	public CustomSimpleAdapter(Context context,
			ArrayList<HashMap<String, String>> data, int resource,
			String[] from, int[] to) {
		super(context, data, resource, from, to);
		this.results = data;
		appContext = context;
	}
@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		View v = super.getView(position, convertView, parent);

		
			
			if(results.get(position).get("issueStatus").equalsIgnoreCase("open")){
				v.setBackgroundColor(Color.rgb(255, 111, 111));}
			else if(results.get(position).get("issueStatus").equalsIgnoreCase("Acknowledged")){
				v.setBackgroundColor(Color.rgb(122, 222, 231));}
			
			else if(results.get(position).get("issueStatus").equalsIgnoreCase("Resolved")){
				v.setBackgroundColor(Color.rgb(101,245,80));}
			else if(results.get(position).get("issueStatus").equalsIgnoreCase("Closed")){
				v.setBackgroundColor(Color.rgb(196,200,198));}
			
			
			
	
			final String testIssueId = results.get(position).get("issueId");
			
			
			ImageView  infoButton = (ImageView)v.findViewById(R.id.issueInfoPictureButton);
			
			infoButton.setOnClickListener(new View.OnClickListener() {
                public void onClick(View v) {
                	Intent  theIndent = new Intent(appContext,issueInfo.class);
              
               
        			theIndent.putExtra("issueId", testIssueId); 
                	appContext.startActivity(theIndent);
                    
                }
            });

			
				
				
		return v;
	}
	
}
