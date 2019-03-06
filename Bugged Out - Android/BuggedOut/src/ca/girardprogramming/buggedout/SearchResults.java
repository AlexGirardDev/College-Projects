package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

import android.app.ListActivity;
import android.os.Bundle;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class SearchResults extends ListActivity {
	ArrayList<HashMap<String, String>> searchResults;
	
	TextView issueId;
	
	@Override

	protected void onCreate(Bundle savedInstanceState) {
		// Get saved data if there is any

		super.onCreate(savedInstanceState);
		setContentView(R.layout.search_results);
		updateList();
		

	
	
	}
	
	
	
	
	
	
	@SuppressWarnings("unchecked")
	private void updateList(){
		DBMethods dbMethods = new DBMethods(super.getApplicationContext());
		
		
		
		searchResults = (ArrayList<HashMap<String, String>>) getIntent().getSerializableExtra("arraylist");
		 
		

		// Check to make sure there are contacts to display

		
			// Get the ListView and assign an event handler to it
			
			
			
		if(searchResults.size()!=0) {
			
			// Get the ListView and assign an event handler to it

			ListView listView = getListView();
			/*
			listView.setOnItemClickListener(new OnItemClickListener() {
				
				public void onItemClick(AdapterView<?> parent, View view,int position, long id) {
					
					issueId = (TextView) view.findViewById(R.id.issueIdRowTextView);
					
					
					String issueIdValue = issueId.getText().toString();	
					
			
					Intent  theIndent = new Intent(SearchResults.this , issueInfo.class);
					
				
					
					theIndent.putExtra("issueId", issueIdValue); 
					
				
					
					startActivity(theIndent); 
				}
			}); 
*/
			ListAdapter adapter = new CustomSimpleAdapter( SearchResults.this,searchResults, R.layout.issue_row, new String[]
														{ "issueId","issueTitle", "projectName","priority"}, 
														new int[] {R.id.issueIdRowTextView,R.id.issueTitleRowTextView, R.id.projectNameRowTextView,R.id.priorityRowTextView});
			
		
			
			setListAdapter(adapter);	
	}}

	
	

}
