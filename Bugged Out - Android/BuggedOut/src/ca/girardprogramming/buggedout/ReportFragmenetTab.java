package ca.girardprogramming.buggedout;

import java.text.DateFormat;
import java.util.Date;
import java.util.HashMap;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import com.actionbarsherlock.app.SherlockFragment;

public class ReportFragmenetTab extends SherlockFragment {

	EditText createdByEditText;
	EditText assignedToEditText;
	EditText createdDateEditText;
	EditText lastUpdateEditText;
	EditText issueTitleEditText;
	EditText descriptionEditText;

	Spinner projectNameSpinner;
	Spinner categorySpinner;
	Spinner issueStatusSpinner;
	Spinner prioritySpinner;

	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		// Get the view from fragmenttab3.xml
		View view = inflater.inflate(R.layout.report_fragmenet_tab, container,
				false);

		createdByEditText = (EditText) view.findViewById(R.id.createdBy);
		assignedToEditText = (EditText) view.findViewById(R.id.assignedTo);

		issueTitleEditText = (EditText) view.findViewById(R.id.issueTitle);
		descriptionEditText = (EditText) view
				.findViewById(R.id.issueDescription);

		projectNameSpinner = (Spinner) view
				.findViewById(R.id.projectNameSpinner);
		categorySpinner = (Spinner) view.findViewById(R.id.categorySpinner);
		issueStatusSpinner = (Spinner) view
				.findViewById(R.id.issueStatusSpinner);
		prioritySpinner = (Spinner) view.findViewById(R.id.prioritySpinner);

		Button reportIssueButton = (Button) view
				.findViewById(R.id.reportIssueButton);
		reportIssueButton.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {

				reportIssue();
			}
		});

		setHasOptionsMenu(true);
		return view;
	}

	@Override
	public void onSaveInstanceState(Bundle outState) {
		super.onSaveInstanceState(outState);
		setUserVisibleHint(true);
	}

	public void reportIssue() {
		DBMethods dbMethods = new DBMethods(getActivity());

		HashMap<String, String> issueValuesMap = new HashMap<String, String>();

		issueValuesMap.put("projectName", projectNameSpinner.getSelectedItem()
				.toString());
		issueValuesMap.put("createdBy", createdByEditText.getText().toString());
		issueValuesMap.put("assignedTo", assignedToEditText.getText()
				.toString());

		issueValuesMap.put("category", categorySpinner.getSelectedItem()
				.toString());
		issueValuesMap.put("issueStatus", issueStatusSpinner.getSelectedItem()
				.toString());

		issueValuesMap.put("priority", prioritySpinner.getSelectedItem()
				.toString());

		issueValuesMap.put("createDate", DateFormat.getDateTimeInstance()
				.format(new Date()));
		issueValuesMap.put("lastUpdate", DateFormat.getDateTimeInstance()
				.format(new Date()));
		issueValuesMap.put("issueTitle", issueTitleEditText.getText()
				.toString());
		issueValuesMap.put("description", descriptionEditText.getText()
				.toString());

		dbMethods.insertIssue(issueValuesMap);

		// IssuesFragmentTab issuefragment = (IssuesFragmentTab)
		// getFragmentManager().findFragmentById(R.id.issue)

	}

}
