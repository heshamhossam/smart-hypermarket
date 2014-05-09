package com.hci.smarthypermarket.views;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.R.layout;
import com.hci.smarthypermarket.models.Market;
import com.hci.smarthypermarket.models.OnModelListener;
import com.hci.smarthypermarket.models.Shopper;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

public class LauncherActivity extends Activity {
	
	public static Shopper shopper = null;
	public static Market market = null;
	private Boolean onLocationChangeCalled = false;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.acticity_launcher);
		
		
		shopper = new Shopper(getApplicationContext());
		
		shopper.setModelHandler(new OnModelListener() {
			
			@Override
			public void OnModelLocationChange() {
				
				if (!onLocationChangeCalled && shopper.isConnectedToInternet(getApplicationContext()))
				{
					onLocationChangeCalled = true;
					market = new Market(shopper.getLocation());
					market.setModelHandler(new OnModelListener() {
						
						@Override
						public void OnModelRetrieved() {
							shopper.setMarketId(market.getId());
							startDashboardActivity();
							
						}
					});
				}
				
			}
		});

		
		shopper.trackPosition(this);
		
	}
	
	private void startDashboardActivity() {
		Intent intent = new Intent(LauncherActivity.this, DashBoardActivity.class);
		startActivity(intent);
		
	}

}
