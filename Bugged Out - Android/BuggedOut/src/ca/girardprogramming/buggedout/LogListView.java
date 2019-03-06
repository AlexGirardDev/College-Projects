package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.ListAdapter;
import android.widget.SimpleAdapter;

public class LogListView extends ListActivity {

	String issueId;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// Get saved data if there is any

		super.onCreate(savedInstanceState);
		setContentView(R.layout.log_listview);
		updateList();

	}

	private void updateList() {
		DBMethods dbMethods = new DBMethods(super.getApplicationContext());

		Intent theIntent = getIntent();
		issueId = theIntent.getStringExtra("issueId");

		ArrayList<HashMap<String, String>> issueLogEntrys = dbMethods
				.getIssueLogList(issueId);

		ListAdapter adapter = new SimpleAdapter(super.getApplicationContext(),
				issueLogEntrys, R.layout.log_row, new String[] { "issueLogId",
						"issueId", "fieldChanged", "originalValue",
						"updatedValue", "updateTime" }, new int[] {
						R.id.issueLogIdTextView, R.id.issueIdTextView,
						R.id.fieldChangedTextView, R.id.originalValueTextView,
						R.id.updatedValueTextView, R.id.updateTimeTextView });

		setListAdapter(adapter);
	}
}
