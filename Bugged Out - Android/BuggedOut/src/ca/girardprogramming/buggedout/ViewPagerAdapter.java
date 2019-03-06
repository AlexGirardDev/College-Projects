package ca.girardprogramming.buggedout;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class ViewPagerAdapter extends FragmentPagerAdapter {

   // Declare the number of ViewPager pages
   final int PAGE_COUNT = 3;

   public ViewPagerAdapter(FragmentManager fm) {
       super(fm);
   }

   @Override
   public Fragment getItem(int arg0) {
       switch (arg0) {

      /*
       case 0:
           HomeFragmentTab homefragmenttab = new HomeFragmentTab();
           return homefragmenttab;
*/
  
       case 0:
           IssuesFragmentTab issuesfragmenttab  = new IssuesFragmentTab();
           return issuesfragmenttab ;

      
       case 1:
    	   ReportFragmenetTab reportfragmenettab  = new ReportFragmenetTab();
           return reportfragmenettab ;
           
       case 2:
    	   SearchFragmentTab searchfragmenttab  = new SearchFragmentTab();
           return searchfragmenttab ;
             
       }
       return null;
   }

   @Override
   public int getCount() {
       // TODO Auto-generated method stub
       return PAGE_COUNT;
   }

}