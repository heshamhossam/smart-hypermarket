package com.hci.smarthypermarket.views;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Toast;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Bluetooth;
import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Market;
import com.hci.smarthypermarket.models.OnBluetoothListener;
import com.hci.smarthypermarket.models.OnModelListener;
import com.hci.smarthypermarket.models.Shopper;

public class LauncherActivity extends Activity {
	
	public static Shopper shopper = null;
	public static Market market = null;
	private Boolean onLocationChangeCalled = false;
	
	BluetoothAdapter mBluetoothAdapter;
	Integer REQ_BT_ENABLE=1;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.acticity_launcher);
		
		
		shopper = new Shopper(getApplicationContext());
		
		if (shopper.isConnectedToInternet(getApplicationContext()))
		{
			shopper.setModelHandler(new OnModelListener() {
				
				@Override
				public void OnModelLocationChange() {
					
					if (!onLocationChangeCalled)
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
			
			shopper.trackPosition(getApplicationContext());
			
		}
		else
		{
			market = new Market("1", "home", true);
			startDashboardActivity();
		}
		
		

		
		
	}
	
	private void startDashboardActivity() {
		Intent intent = new Intent(LauncherActivity.this, DashBoardActivity.class);
		startActivity(intent);
		
	}
	
	
}
