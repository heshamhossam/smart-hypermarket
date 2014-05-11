package com.hci.smarthypermarket.views;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Toast;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Market;
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
	
	private void enableBlutooth()
	{
		/* Check if the device supports bluetooth or not */
		mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		if(mBluetoothAdapter == null){
			Toast.makeText(getApplicationContext(), "Device doesn't support bluetooth", Toast.LENGTH_LONG).show();
		}
		else {
			/* Enabling bluetooth if the bluetooth is disabled */
			if(!mBluetoothAdapter.isEnabled()){
				Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
			    startActivityForResult(enableBtIntent, REQ_BT_ENABLE);
			    Toast.makeText(getApplicationContext(), "Enabling bluetooth", Toast.LENGTH_LONG).show();
			}
		}
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
//		if(requestCode == REQ_BT_ENABLE){
//			if(resultCode == RESULT_OK){
//				shopper.startBlutoothTracking(new BlutoothListener(){
//					onBlutoothFound(Bluetooth bluetooth)
//					{
//						Category category = market.findCategory(blutooth);
//					}
//				});
//			}
//			
//			if(resultCode == RESULT_CANCELED){
//				
//			}
//		}
	}

}
