package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.actionbarsherlock.app.SherlockListFragment;

public class IssuesFragmentTab extends SherlockListFragment {

	TextView issueId;

	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View view = inflater.inflate(R.layout.issues_fragment_tab, container,
				false);

		return view;

	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setHasOptionsMenu(true);
	}

	@Override
	public boolean onOptionsItemSelected(
			com.actionbarsherlock.view.MenuItem item) {
		if (item.getTitle().equals(getString(R.string.action_refresh))) {
			updateList();
			Toast.makeText(getActivity(), "Refreshing the Issues list...",
					Toast.LENGTH_SHORT).show();
			return super.onOptionsItemSelected(item);
		}

		return false;
	}

	@Override
	public void onActivityCreated(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		if (!updateList()) {

			// add click listener for refresh button
			DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
				@Override
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:
						DBMethods dbMethods = new DBMethods(getActivity());

						dbMethods.insertDemoData();

						updateList();
						break;

					case DialogInterface.BUTTON_NEGATIVE:

						break;
					}
				}
			};

			AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
			builder.setMessage(
					"No issues found,Would you like to populate with demo Demo issues?")
					.setPositiveButton("Yes", dialogClickListener)
					.setNegativeButton("No", dialogClickListener).show();
		}

	}

	// updates list view with appropriate data
	private Boolean updateList() {
		DBMethods dbMethods = new DBMethods(getActivity());
		ArrayList<HashMap<String, String>> issuesList = dbMethods
				.getAllIssues();

		if (issuesList.size() != 0) {

			ListView listView = getListView();

			ListAdapter adapter = new CustomSimpleAdapter(getActivity(),
					issuesList, R.layout.issue_row,
					new String[] { "issueId", "issueTitle", "projectName",
							"priority", "category" }, new int[] {
							R.id.issueIdRowTextView,
							R.id.issueTitleRowTextView,
							R.id.projectNameRowTextView,
							R.id.priorityRowTextView,
							R.id.issueCategoryRowTextView });

			setListAdapter(adapter);
		}

		if (issuesList.size() == 0) {
			return false;
		}

		return true;

	}

}
