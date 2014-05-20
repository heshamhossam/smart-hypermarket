package com.hci.smarthypermarket.test;

import com.hci.smarthypermarket.views.LauncherActivity;
import com.robotium.solo.Solo;

import android.test.ActivityInstrumentationTestCase2;


public class LauncherActivityTest extends ActivityInstrumentationTestCase2<LauncherActivity> {

	private Solo solo;
	
	public LauncherActivityTest(Class<LauncherActivity> activityClass) {
		super(activityClass);
		// TODO Auto-generated constructor stub
	}

	protected void setUp() throws Exception {
		super.setUp();
	}
	
	@Override
	public void tearDown() throws Exception {
	        solo.finishOpenedActivities();
	}

}
