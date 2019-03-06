package ca.girardprogramming.buggedout;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.ViewPager;
import android.widget.TextView;

import com.actionbarsherlock.app.ActionBar;
import com.actionbarsherlock.app.ActionBar.Tab;
import com.actionbarsherlock.app.SherlockFragmentActivity;
import com.actionbarsherlock.view.Menu;
import com.actionbarsherlock.view.MenuItem;

public class MainActivity extends SherlockFragmentActivity {

	// Declare Variables
	ActionBar mActionBar;
	ViewPager mPager;
	Tab tab;

	Intent intent;
	TextView contactId;

	private static Menu _menuInstance;

	DBMethods dbMethods = new DBMethods(this);

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		_menuInstance = menu;

		menu.add(getString(R.string.action_refresh))
				.setIcon(R.drawable.action_refresh).setVisible(true)
				.setShowAsAction(MenuItem.SHOW_AS_ACTION_IF_ROOM);
		return super.onCreateOptionsMenu(menu);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_main);

		mActionBar = getSupportActionBar();
		mActionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

		mPager = (ViewPager) findViewById(R.id.pager);

		FragmentManager fm = getSupportFragmentManager();

		ViewPager.SimpleOnPageChangeListener ViewPagerListener = new ViewPager.SimpleOnPageChangeListener() {
			@Override
			public void onPageSelected(int position) {
				super.onPageSelected(position);

				mActionBar.setSelectedNavigationItem(position);
			}
		};

		mPager.setOnPageChangeListener(ViewPagerListener);

		ViewPagerAdapter viewpageradapter = new ViewPagerAdapter(fm);

		mPager.setAdapter(viewpageradapter);

		ActionBar.TabListener tabListener = new ActionBar.TabListener() {

			@Override
			public void onTabSelected(Tab tab, FragmentTransaction ft) {

				mPager.setCurrentItem(tab.getPosition());
			}

			@Override
			public void onTabUnselected(Tab tab, FragmentTransaction ft) {

			}

			@Override
			public void onTabReselected(Tab tab, FragmentTransaction ft) {

			}
		};

		// Create second Tab
		tab = mActionBar.newTab().setText("Issues").setTabListener(tabListener);
		mActionBar.addTab(tab);

		// Create third Tab
		tab = mActionBar.newTab().setText("Report").setTabListener(tabListener);
		mActionBar.addTab(tab);

		tab = mActionBar.newTab().setText("Search").setTabListener(tabListener);
		mActionBar.addTab(tab);
	}

}