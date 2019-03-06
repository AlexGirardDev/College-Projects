package ca.girardprogramming.buggedout;

import java.text.DateFormat;
import java.util.Date;
import java.util.HashMap;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class issueInfo extends Activity {
	EditText createdByEditText;
	EditText assignedToEditText;
	EditText issueTitleEditText;
	EditText descriptionEditText;

	TextView createdDateTextView;
	TextView lastUpdateTextView;
	TextView issueIdTextView;

	Spinner projectNameSpinner;
	Spinner categorySpinner;
	Spinner issueStatusSpinner;
	Spinner prioritySpinner;

	String issueId;
	HashMap<String, String> originalFieldValues = new HashMap<String, String>();
	HashMap<String, String> updatedFieldValues = new HashMap<String, String>();

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.issue_info);
		DBMethods dbMethods = new DBMethods(super.getApplicationContext());

		addButtonListeners();

		//assign views from XML layout to respected Variables
		createdDateTextView = (TextView) findViewById(R.id.createdDate);
		lastUpdateTextView = (TextView) findViewById(R.id.lasteUpdate);
		issueIdTextView = (TextView) findViewById(R.id.issueId);

		createdByEditText = (EditText) findViewById(R.id.createdBy);
		assignedToEditText = (EditText) findViewById(R.id.assignedTo);
		issueTitleEditText = (EditText) findViewById(R.id.issueTitle);
		descriptionEditText = (EditText) findViewById(R.id.issueDescription);

		projectNameSpinner = (Spinner) findViewById(R.id.projectNameSpinner);
		categorySpinner = (Spinner) findViewById(R.id.categorySpinner);
		issueStatusSpinner = (Spinner) findViewById(R.id.issueStatusSpinner);
		prioritySpinner = (Spinner) findViewById(R.id.prioritySpinner);

		
		
		
		Intent theIntent = getIntent();
		issueId = theIntent.getStringExtra("issueId");
		HashMap<String, String> issueList = dbMethods.getIssueInfo(theIntent
				.getStringExtra("issueId"));

		//get all of appropriate data from database base and insert into respected views
		createdByEditText.setText(issueList.get("createdBy"));
		assignedToEditText.setText(issueList.get("assignedTo"));
		createdDateTextView.setText(issueList.get("createDate"));
		lastUpdateTextView.setText(issueList.get("lastUpdate"));
		issueTitleEditText.setText(issueList.get("issueTitle"));
		descriptionEditText.setText(issueList.get("description"));

		issueIdTextView.setText(issueId);

		// i had to use an array adapter to use the getPosition function to find
		// the apporiate spinner index

		projectNameSpinner
				.setSelection(((ArrayAdapter<String>) projectNameSpinner
						.getAdapter()).getPosition(issueList
						.get("projecttName")));

		categorySpinner.setSelection(((ArrayAdapter<String>) categorySpinner
				.getAdapter()).getPosition(issueList.get("category")));

		issueStatusSpinner
				.setSelection(((ArrayAdapter<String>) issueStatusSpinner
						.getAdapter()).getPosition(issueList.get("issueStatus")));

		prioritySpinner.setSelection(((ArrayAdapter<String>) prioritySpinner
				.getAdapter()).getPosition(issueList.get("priority")));


		originalFieldValues.put("issueId", issueId);
		originalFieldValues.put("projectName", issueList.get("projecttName"));
		originalFieldValues.put("createdBy", issueList.get("createdBy"));
		originalFieldValues.put("assignedTo", issueList.get("assignedTo"));

		originalFieldValues.put("category", issueList.get("category"));
		originalFieldValues.put("issueStatus", issueList.get("issueStatus"));

		originalFieldValues.put("priority", issueList.get("priority"));

		originalFieldValues.put("createDate", issueList.get("createDate"));

		originalFieldValues.put("lastUpdate", issueList.get("lastUpdate"));
		originalFieldValues.put("issueTitle", issueList.get("issueTitle"));
		originalFieldValues.put("description", issueList.get("description"));

	}

	//compares original values of input fields with current and inserts any changed into the logs entry as a log Row
	private void updatelog() {

		for (HashMap.Entry<String, String> entry : updatedFieldValues
				.entrySet()) {
			String key = entry.getKey();
			String value = entry.getValue();

			if (!updatedFieldValues.get(key).equalsIgnoreCase(
					originalFieldValues.get(key))) {
				insertLogEntry(key);

			}
			// use key and value
		}

	}

	
	//pulls all values from input fields and retuns them as a HashMap
	public HashMap<String, String> getFieldValues() {

		HashMap<String, String> fieldValuesMap = new HashMap<String, String>();

		fieldValuesMap.put("issueId", issueIdTextView.getText().toString());
		fieldValuesMap.put("projectName", projectNameSpinner.getSelectedItem()
				.toString());
		fieldValuesMap.put("createdBy", createdByEditText.getText().toString());
		fieldValuesMap.put("assignedTo", assignedToEditText.getText()
				.toString());

		fieldValuesMap.put("category", categorySpinner.getSelectedItem()
				.toString());
		fieldValuesMap.put("issueStatus", issueStatusSpinner.getSelectedItem()
				.toString());

		fieldValuesMap.put("priority", prioritySpinner.getSelectedItem()
				.toString());

		fieldValuesMap.put("createDate", createdDateTextView.getText()
				.toString());

		fieldValuesMap.put("lastUpdate", lastUpdateTextView.getText()
				.toString());
		fieldValuesMap.put("issueTitle", issueTitleEditText.getText()
				.toString());
		fieldValuesMap.put("description", descriptionEditText.getText()
				.toString());

		return fieldValuesMap;

	}

	//inserts a log into logs Database
	private void insertLogEntry(String FieldValue) {

		HashMap<String, String> logValueMap = new HashMap<String, String>();
		DBMethods dbMethods = new DBMethods(getApplication());

		logValueMap.put("issueId", issueId);
		logValueMap.put("fieldChanged", FieldValue);
		logValueMap.put("originalValue", originalFieldValues.get(FieldValue));
		logValueMap.put("updatedValue", updatedFieldValues.get(FieldValue));
		logValueMap.put("updateTime",
				DateFormat.getDateTimeInstance().format(new Date()));

		dbMethods.addLogEntry(logValueMap);

	}

	//adds listeners to respected buttons
	private void addButtonListeners() {

		Button updateIssueButton = (Button) findViewById(R.id.updateIssueButton);
		updateIssueButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				DBMethods dbMethods = new DBMethods(getApplication());
				updatedFieldValues = getFieldValues();
				updatelog();

				HashMap<String, String> issueValuesMap = new HashMap<String, String>();

				issueValuesMap.put("issueId", issueIdTextView.getText()
						.toString());
				issueValuesMap.put("projectName", projectNameSpinner
						.getSelectedItem().toString());
				issueValuesMap.put("createdBy", createdByEditText.getText()
						.toString());
				issueValuesMap.put("assignedTo", assignedToEditText.getText()
						.toString());

				issueValuesMap.put("category", categorySpinner
						.getSelectedItem().toString());
				issueValuesMap.put("issueStatus", issueStatusSpinner
						.getSelectedItem().toString());

				issueValuesMap.put("priority", prioritySpinner
						.getSelectedItem().toString());

				issueValuesMap.put("createDate", createdDateTextView.getText()
						.toString());

				issueValuesMap.put("lastUpdate", DateFormat
						.getDateTimeInstance().format(new Date()));
				issueValuesMap.put("issueTitle", issueTitleEditText.getText()
						.toString());
				issueValuesMap.put("description", descriptionEditText.getText()
						.toString());

				dbMethods.updateIssue(issueValuesMap);

				finish();

			}
		});

		Button deleteIssueButton = (Button) findViewById(R.id.deleteIssueButton);
		deleteIssueButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				DBMethods dbMethods = new DBMethods(getApplication());
				dbMethods.deleteIssue(issueId);

			}
		});

		Button issueLogButton = (Button) findViewById(R.id.issueLogButton);
		issueLogButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {

				Intent theIndent = new Intent(issueInfo.this, LogListView.class);


				theIndent.putExtra("issueId", issueId);

		

				startActivity(theIndent);


			}
		});

	}

}
