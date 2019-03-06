package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import com.actionbarsherlock.app.SherlockFragment;

public class SearchFragmentTab extends SherlockFragment {

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
		
		View view = inflater.inflate(R.layout.search_fragment_tab, container,
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

		Button searchIssuesButton = (Button) view
				.findViewById(R.id.searchIssuesButton);

		searchIssuesButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {

				getSearchResults();
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

	public void getSearchResults() {
		DBMethods dbMethods = new DBMethods(getActivity());

		HashMap<String, String> searchFieldsValuesMap = new HashMap<String, String>();
		ArrayList<HashMap<String, String>> searchResults;

		searchFieldsValuesMap.put("projectName", projectNameSpinner
				.getSelectedItem().toString());
		searchFieldsValuesMap.put("createdBy", createdByEditText.getText()
				.toString());
		searchFieldsValuesMap.put("assignedTo", assignedToEditText.getText()
				.toString());

		searchFieldsValuesMap.put("category", categorySpinner.getSelectedItem()
				.toString());
		searchFieldsValuesMap.put("issueStatus", issueStatusSpinner
				.getSelectedItem().toString());

		searchFieldsValuesMap.put("priority", prioritySpinner.getSelectedItem()
				.toString());

		searchFieldsValuesMap.put("issueTitle", issueTitleEditText.getText()
				.toString());
		searchFieldsValuesMap.put("description", descriptionEditText.getText()
				.toString());

		HashMap<String, String> searchCriteriaValuseMap = new HashMap<String, String>();

		for (HashMap.Entry<String, String> entry : searchFieldsValuesMap
				.entrySet()) {

			String key = entry.getKey();
			String value = entry.getValue();

			if (value.length() != 0) {
				searchCriteriaValuseMap.put(key, value);

			}
		}
		searchResults = dbMethods.getSearchResults(searchCriteriaValuseMap);

		Intent theIndent = new Intent(getActivity(), SearchResults.class);

		theIndent.putExtra("arraylist", searchResults);

		startActivity(theIndent);

	}
}
