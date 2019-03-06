package ca.girardprogramming.buggedout;

import java.util.ArrayList;
import java.util.HashMap;

public class SampleData {

	int numOfDemoIssues = 12;

	public ArrayList<HashMap<String, String>> getDemoLogList() {

		ArrayList<HashMap<String, String>> demoLogList = new ArrayList<HashMap<String, String>>();
		for (int i = 0; i < numOfDemoIssues * 3; i++) {
			demoLogList.add(new HashMap<String, String>());
		}

		for (int i = 0; i < numOfDemoIssues; i++) {

			demoLogList.get(i).put("issueId", String.valueOf(i));
			demoLogList.get(i).put("fieldChanged", "createdBy");
			demoLogList.get(i).put("originalValue", "IdrA");
			demoLogList.get(i).put("updatedValue", "Bonjwa");
			demoLogList.get(i).put("updateTime", "6/15/2013 3:00:00 PM");
		}

		for (int i = numOfDemoIssues; i < numOfDemoIssues * 2; i++) {

			demoLogList.get(i).put("issueId",
					String.valueOf(i - numOfDemoIssues));
			demoLogList.get(i).put("fieldChanged", "issueStatus");
			demoLogList.get(i).put("originalValue", "Open");
			demoLogList.get(i).put("updatedValue", "Closed");
			demoLogList.get(i).put("updateTime", "6/15/2013 3:00:00 PM");
		}
		for (int i = numOfDemoIssues * 2; i < numOfDemoIssues * 3; i++) {

			demoLogList.get(i).put("issueId",
					String.valueOf(i - numOfDemoIssues * 2));
			demoLogList.get(i).put("fieldChanged", "assignedTo");
			demoLogList.get(i).put("originalValue", "Alex");
			demoLogList.get(i).put("updatedValue", "Spencer");
			demoLogList.get(i).put("updateTime", "6/15/2013 3:00:00 PM");

		}
		return demoLogList;
	}

	public ArrayList<HashMap<String, String>> getDemoIssueList() {

		ArrayList<HashMap<String, String>> demoissueList = new ArrayList<HashMap<String, String>>();

		for (int i = 0; i < numOfDemoIssues; i++) {
			demoissueList.add(new HashMap<String, String>());
		}

		demoissueList.get(0).put("projectName", "World Of Peacecraft");
		demoissueList.get(0).put("createdBy", "The Bonjwa");
		demoissueList.get(0).put("assignedTo", "");
		demoissueList.get(0).put("category", "AI");
		demoissueList.get(0).put("issueStatus", "Open");
		demoissueList.get(0).put("priority", "High");
		demoissueList.get(0).put("createDate", "6/1/2013 6:00:00 PM");
		demoissueList.get(0).put("lastUpdate", "6/15/2013 3:00:00 PM");
		demoissueList.get(0).put("issueTitle", "Rebellious Child class");
		demoissueList
				.get(0)
				.put("description",
						"Child Classes throwing exception refuses to inherit parent classes attributes because it wants to be its own person");

		demoissueList.get(1).put("issueTitle", "Continue Bug Testing");
		demoissueList.get(1).put("projectName", "World Of Peacecraft");
		demoissueList.get(1).put("createdBy", "Jaedong");
		demoissueList.get(1).put("assignedTo", "Spencer");
		demoissueList.get(1).put("category", "Multiplayer");
		demoissueList.get(1).put("issueStatus", "Acknowledged");
		demoissueList.get(1).put("priority", "Low");
		demoissueList.get(1).put("createDate", "6/1/2013 5:00:00 PM");
		demoissueList.get(1).put("lastUpdate", "6/14/2013 3:00:00 PM");
		demoissueList.get(1).put("description", "Work your magic man");

		demoissueList.get(2).put("issueTitle", "NPCs ignore the player");
		demoissueList.get(2).put("projectName", "World Of Peacecraft");
		demoissueList.get(2).put("createdBy", "Stephano");
		demoissueList.get(2).put("assignedTo", "Spencer");
		demoissueList.get(2).put("category", "Single Player");
		demoissueList.get(2).put("issueStatus", "Resolved");
		demoissueList.get(2).put("priority", "Normal");
		demoissueList.get(2).put("createDate", "6/1/2013 6:30:00 PM");
		demoissueList.get(2).put("lastUpdate", "6/5/2013 3:00:00 PM");
		demoissueList
				.get(2)
				.put("description",
						"NPCs are to busy talking to eachother and refuse to achnowledge the player");

		demoissueList.get(3)
				.put("issueTitle", "Werewolf character model wrong");
		demoissueList.get(3).put("projectName", "CarCraft 4");
		demoissueList.get(3).put("createdBy", "Leenock");
		demoissueList.get(3).put("assignedTo", "Alex");
		demoissueList.get(3).put("category", "Graphics");
		demoissueList.get(3).put("issueStatus", "Resolved");
		demoissueList.get(3).put("priority", "High");
		demoissueList.get(3).put("createDate", "6/6/2013 5:00:00 PM");
		demoissueList.get(3).put("lastUpdate", "6/22/2013 3:00:00 PM");
		demoissueList
				.get(3)
				.put("description",
						"Once in a while the warewolf character turns into a steamboat.");

		demoissueList.get(4).put("issueTitle", "Cow Sound problems");
		demoissueList.get(4).put("projectName", "Slightly Agitated Bovine");
		demoissueList.get(4).put("createdBy", "DongRaeGu");
		demoissueList.get(4).put("assignedTo", "Karl");
		demoissueList.get(4).put("category", "Graphics");
		demoissueList.get(4).put("issueStatus", "Closed");
		demoissueList.get(4).put("priority", "Normal");
		demoissueList.get(4).put("createDate", "6/8/2013 5:00:00 PM");
		demoissueList.get(4).put("lastUpdate", "6/28/2013 3:00:00 PM");
		demoissueList
				.get(4)
				.put("description",
						"Instead of cow making normal MOO noise they make the sounds of a Chain saw instead");

		demoissueList.get(5).put("issueTitle", "Game crashes on impact");
		demoissueList.get(5).put("projectName", "Call Of Honor");
		demoissueList.get(5).put("createdBy", "MMA");
		demoissueList.get(5).put("assignedTo", "Alex");
		demoissueList.get(5).put("category", "Physics");
		demoissueList.get(5).put("issueStatus", "Acknowledged");
		demoissueList.get(5).put("priority", "Urgent");
		demoissueList.get(5).put("createDate", "6/10/2013 5:00:00 PM");
		demoissueList.get(5).put("lastUpdate", "6/24/2013 3:00:00 PM");
		demoissueList
				.get(5)
				.put("description",
						"If the console is dropped of the table,the game crashes on impact.");

		demoissueList.get(6).put("issueTitle", "Force applied to character");
		demoissueList.get(6).put("projectName", "Call Of Honor");
		demoissueList.get(6).put("createdBy", "Hero");
		demoissueList.get(6).put("assignedTo", "Karl");
		demoissueList.get(6).put("category", "Physics");
		demoissueList.get(6).put("issueStatus", "Resolved");
		demoissueList.get(6).put("priority", "High");
		demoissueList.get(6).put("createDate", "6/11/2013 5:00:00 PM");
		demoissueList.get(6).put("lastUpdate", "6/22/2013 3:00:00 PM");
		demoissueList
				.get(6)
				.put("description",
						"When I shoot the gun, the force seems to applied to the player.I end up being rocketed across the map.");

		demoissueList.get(7).put("issueTitle", "Bovine are not Agitated");
		demoissueList.get(7).put("projectName", "Slightly Agitated Bovine");
		demoissueList.get(7).put("createdBy", "MarneKing");
		demoissueList.get(7).put("assignedTo", "");
		demoissueList.get(7).put("category", "Graphics");
		demoissueList.get(7).put("issueStatus", "Open");
		demoissueList.get(7).put("priority", "Urgent");
		demoissueList.get(7).put("createDate", "6/13/2013 5:00:00 PM");
		demoissueList.get(7).put("lastUpdate", "6/28/2013 3:00:00 PM");
		demoissueList.get(7).put("description",
				"current models display bovine in a good mood");

		demoissueList.get(8).put("issueTitle", "minivanCraft4");
		demoissueList.get(8).put("projectName", "CarCraft 4");
		demoissueList.get(8).put("createdBy", "Parting");
		demoissueList.get(8).put("assignedTo", "Spencer");
		demoissueList.get(8).put("category", "Graphics");
		demoissueList.get(8).put("issueStatus", "Acknowledged");
		demoissueList.get(8).put("priority", "Normal");
		demoissueList.get(8).put("createDate", "6/16/2013 5:00:00 PM");
		demoissueList.get(8).put("lastUpdate", "6/25/2013 3:00:00 PM");
		demoissueList
				.get(8)
				.put("description",
						"Cars seems to be the minority,Minivars are the majority for some reason please fix.");

		demoissueList.get(9).put("issueTitle", "negative 1 in Equation.");
		demoissueList.get(9).put("projectName", "Slightly Agitated Bovine");
		demoissueList.get(9).put("createdBy", "Life");
		demoissueList.get(9).put("assignedTo", "Alex");
		demoissueList.get(9).put("category", "Physics");
		demoissueList.get(9).put("issueStatus", "Resolved");
		demoissueList.get(9).put("priority", "Urgent");
		demoissueList.get(9).put("createDate", "6/17/2013 5:00:00 PM");
		demoissueList.get(9).put("lastUpdate", "6/25/2013 3:00:00 PM");
		demoissueList
				.get(9)
				.put("description",
						"a -1 in the jumping equation causes an issue where the model jumps into the ground instead of the air");

		demoissueList.get(10).put("issueTitle", "OS Compatibility Problem");
		demoissueList.get(10).put("projectName", "CarCraft 4");
		demoissueList.get(10).put("createdBy", "Puma");
		demoissueList.get(10).put("assignedTo", "Karl");
		demoissueList.get(10).put("category", "Physics");
		demoissueList.get(10).put("issueStatus", "Closed");
		demoissueList.get(10).put("priority", "High");
		demoissueList.get(10).put("createDate", "6/18/2013 5:00:00 PM");
		demoissueList.get(10).put("lastUpdate", "6/22/2013 3:00:00 PM");
		demoissueList
				.get(10)
				.put("description",
						"Problems with compaitlbilty with other Fruit like OS Apply only one currently supported");

		demoissueList.get(11).put("issueTitle", "Cars not crafty enough");
		demoissueList.get(11).put("projectName", "CarCraft 4");
		demoissueList.get(11).put("createdBy", "Taeja");
		demoissueList.get(11).put("assignedTo", "Alex");
		demoissueList.get(11).put("category", "Multiplayer");
		demoissueList.get(11).put("issueStatus", "Resolved");
		demoissueList.get(11).put("priority", "High");
		demoissueList.get(11).put("createDate", "6/19/2013 5:00:00 PM");
		demoissueList.get(11).put("lastUpdate", "6/25/2013 3:00:00 PM");
		demoissueList.get(11).put("description", "See title");

		return demoissueList;

	}
}
