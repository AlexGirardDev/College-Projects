package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

// SQLiteOpenHelper helps you open or create a database

public class DBMethods extends SQLiteOpenHelper {

	SQLiteOpenHelper instance;

	public DBMethods(Context applicationcontext) {
		super(applicationcontext, "contactbook.db", null, 1);
	}

	// onCreate is called the first time the database is created
	@Override
	public void onCreate(SQLiteDatabase database) {
		String query = "CREATE TABLE tIssues ("
				+ "issueId INTEGER PRIMARY KEY," + "projectName TEXT,"
				+ "createdBy TEXT," + "assignedTo TEXT," + "category TEXT,"
				+ "issueStatus TEXT ," + "priority TEXT," + "createDate TEXT,"
				+ "lastUpdate TEXT," + "issueTitle TEXT," + "description TEXT)";
		database.execSQL(query);
		query = "CREATE TABLE issueLogEntrys(issueLogId INTEGER PRIMARY KEY,"
				+ "issueId INTEGER," + "fieldChanged TEXT,"
				+ "originalValue TEXT," + "UpdatedValue TEXT,"
				+ "updateTime TEXT)";
		database.execSQL(query);

	}

	@Override
	public void onUpgrade(SQLiteDatabase database, int version_old,
			int current_version) {
		String query = "DROP TABLE IF EXISTS tIssues";

		// Executes the query provided as long as the query isn't a select
		// or if the query doesn't return any data

		database.execSQL(query);

		query = "DROP TABLE IF EXISTS issueLogEntrys";

		// Executes the query provided as long as the query isn't a select
		// or if the query doesn't return any data

		database.execSQL(query);
		onCreate(database);
	}

	// Inserts demo data into the database pulled from sampleData Class
	public void insertDemoData() {

		ArrayList<HashMap<String, String>> demoIssueList;
		ArrayList<HashMap<String, String>> demoLogList;
		SampleData sd = new SampleData();

		demoIssueList = sd.getDemoIssueList();

		for (int i = 0; i < demoIssueList.size(); i++) {
			insertIssue(demoIssueList.get(i));
		}

		demoLogList = sd.getDemoLogList();

		for (int i = 0; i < demoLogList.size(); i++) {
			addLogEntry(demoLogList.get(i));
		}
	}

	// Get all of the current issues in the database and return them as an
	// ArrayList of HashMaps
	public ArrayList<HashMap<String, String>> getAllIssues() {

		ArrayList<HashMap<String, String>> issuesArrayList = new ArrayList<HashMap<String, String>>();

		String selectQuery = "SELECT * FROM tIssues";

		SQLiteDatabase database = this.getWritableDatabase();

		Cursor cursor = database.rawQuery(selectQuery, null);

		if (cursor.moveToFirst()) {

			do {
				HashMap<String, String> issuetMap = new HashMap<String, String>();

				issuetMap.put("issueId", cursor.getString(0));
				issuetMap.put("projectName", cursor.getString(1));
				issuetMap.put("createdBy", cursor.getString(2));
				issuetMap.put("assignedTo", cursor.getString(3));
				issuetMap.put("category", cursor.getString(4));
				issuetMap.put("issueStatus", cursor.getString(5));
				issuetMap.put("priority", cursor.getString(6));
				issuetMap.put("createDate", cursor.getString(7));
				issuetMap.put("lastUpdate", cursor.getString(8));
				issuetMap.put("issueTitle", cursor.getString(9));
				issuetMap.put("description", cursor.getString(10));

				issuesArrayList.add(issuetMap);

			} while (cursor.moveToNext());

		}

		return issuesArrayList;

	}

	// Get the issue info of a specific issue based on issueId
	public HashMap<String, String> getIssueInfo(String issueId) {

		HashMap<String, String> issueInfoMap = new HashMap<String, String>();

		// Open a database for reading only

		SQLiteDatabase database = this.getReadableDatabase();

		String selectQuery = "SELECT * FROM tIssues where issueId='" + issueId
				+ "'";

		// rawQuery executes the query and returns the result as a Cursor

		Cursor cursor = database.rawQuery(selectQuery, null);
		if (cursor.moveToFirst()) {
			do {

				issueInfoMap.put("issueId", cursor.getString(0));
				issueInfoMap.put("projectName", cursor.getString(1));
				issueInfoMap.put("createdBy", cursor.getString(2));
				issueInfoMap.put("assignedTo", cursor.getString(3));
				issueInfoMap.put("category", cursor.getString(4));
				issueInfoMap.put("issueStatus", cursor.getString(5));

				issueInfoMap.put("priority", cursor.getString(6));

				issueInfoMap.put("createDate", cursor.getString(7));
				issueInfoMap.put("lastUpdate", cursor.getString(8));
				issueInfoMap.put("issueTitle", cursor.getString(9));
				issueInfoMap.put("description", cursor.getString(10));

			} while (cursor.moveToNext());
		}
		return issueInfoMap;
	}

	// Insert issue into database
	public void insertIssue(HashMap<String, String> issueValues) {

		SQLiteDatabase database = this.getWritableDatabase();

		ContentValues values = new ContentValues();

		values.put("projectName", issueValues.get("projectName"));
		values.put("createdBy", issueValues.get("createdBy"));
		values.put("assignedTo", issueValues.get("assignedTo"));
		values.put("category", issueValues.get("category"));
		values.put("issueStatus", issueValues.get("issueStatus"));
		values.put("priority", issueValues.get("priority"));
		values.put("createDate", issueValues.get("createDate"));
		values.put("lastUpdate", issueValues.get("lastUpdate"));
		values.put("issueTitle", issueValues.get("issueTitle"));
		values.put("description", issueValues.get("description"));

		database.insert("tIssues", null, values);

		database.close();
	}

	// update issue with new set of data
	public int updateIssue(HashMap<String, String> queryValues) {

		SQLiteDatabase database = this.getWritableDatabase();

		ContentValues values = new ContentValues();

		values.put("projectName", queryValues.get("projectName"));
		values.put("createdBy", queryValues.get("createdBy"));
		values.put("assignedTo", queryValues.get("assignedTo"));
		values.put("category", queryValues.get("category"));
		values.put("issueStatus", queryValues.get("issueStatus"));
		values.put("priority", queryValues.get("priority"));
		values.put("createDate", queryValues.get("createDate"));
		values.put("lastUpdate", queryValues.get("lastUpdate"));
		values.put("issueTitle", queryValues.get("issueTitle"));
		values.put("description", queryValues.get("description"));

		return database.update("tIssues", values, "issueId" + " = ?",
				new String[] { queryValues.get("issueId") });
	}

	// delete issue based on issueId
	public void deleteIssue(String issueId) {

		SQLiteDatabase database = this.getWritableDatabase();

		String deleteQuery = "DELETE FROM  tIssues where issueId='" + issueId
				+ "'";

		database.execSQL(deleteQuery);
	}

	// Returns ArrayList of issues based on search results passed in via a
	// HashMap
	public ArrayList<HashMap<String, String>> getSearchResults(
			HashMap<String, String> searchCriteria) {

		ArrayList<HashMap<String, String>> searchResults = new ArrayList<HashMap<String, String>>();

		boolean firstCondition = false;
		
		//Check to make sure searchCriteria isnt empty
		if (searchCriteria.size() != 0) {
			
			String selectQuery = "SELECT * FROM tIssues where  ";
			SQLiteDatabase database = this.getReadableDatabase();

			ArrayList<String> valueList = new ArrayList<String>();

			//iterate through each set of strings and add to Select query
			for (HashMap.Entry<String, String> entry : searchCriteria
					.entrySet()) {

				String key = entry.getKey();
				String value = entry.getValue();

				valueList.add("%" + value + "%");
				if (!firstCondition) {
					selectQuery += key + " LIKE ? ";
					firstCondition = true;
				} else {
					selectQuery += " AND " + key + " LIKE ? ";
				}
			}
			
			
		
			String[] valueArray = new String[valueList.size()];
			valueArray = valueList.toArray(valueArray);
			Cursor cursor = database.rawQuery(selectQuery, valueArray);
			if (cursor.moveToFirst()) {
				do {

					HashMap<String, String> resultMap = new HashMap<String, String>();

					resultMap.put("issueId", cursor.getString(0));
					resultMap.put("projectName", cursor.getString(1));
					resultMap.put("createdBy", cursor.getString(2));
					resultMap.put("assignedTo", cursor.getString(3));
					resultMap.put("category", cursor.getString(4));
					resultMap.put("issueStatus", cursor.getString(5));
					resultMap.put("priority", cursor.getString(6));
					resultMap.put("createDate", cursor.getString(7));
					resultMap.put("lastUpdate", cursor.getString(8));
					resultMap.put("issueTitle", cursor.getString(9));
					resultMap.put("description", cursor.getString(10));

					searchResults.add(resultMap);

				} while (cursor.moveToNext());

			}
		}

	

		return searchResults;

	}

	
	//insert a log entry into logs database
	public void addLogEntry(HashMap<String, String> logValues) {

		SQLiteDatabase database = this.getWritableDatabase();

		ContentValues values = new ContentValues();

		values.put("issueLogId", logValues.get("issueLogId"));
		values.put("issueId", logValues.get("issueId"));
		values.put("fieldChanged", logValues.get("fieldChanged"));
		values.put("originalValue", logValues.get("originalValue"));
		values.put("updatedValue", logValues.get("updatedValue"));
		values.put("updateTime", logValues.get("updateTime"));

		

		database.insert("issueLogEntrys", null, values);
	}

	// get all logs based on issueId
	public ArrayList<HashMap<String, String>> getIssueLogList(String issueId) {
		ArrayList<HashMap<String, String>> logArrayList = new ArrayList<HashMap<String, String>>();

		String selectQuery = "SELECT * FROM issueLogEntrys where issueId='"
				+ issueId + "'";
		SQLiteDatabase database = this.getWritableDatabase();

		Cursor cursor = database.rawQuery(selectQuery, null);

		if (cursor.moveToFirst()) {

			do {

				HashMap<String, String> logEntryMap = new HashMap<String, String>();

				logEntryMap.put("issueLogId", cursor.getString(0));
				logEntryMap.put("issueId", cursor.getString(1));
				logEntryMap.put("fieldChanged", cursor.getString(2));
				logEntryMap.put("originalValue", cursor.getString(3));
				logEntryMap.put("updatedValue", cursor.getString(4));
				logEntryMap.put("updateTime", cursor.getString(5));

				logArrayList.add(logEntryMap);

			} while (cursor.moveToNext());

		}

		return logArrayList;

	}


}