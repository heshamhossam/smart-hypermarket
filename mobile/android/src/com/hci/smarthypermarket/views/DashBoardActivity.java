package com.hci.smarthypermarket.views;

import android.app.ActionBar;
import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Bluetooth;
import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.OnBluetoothListener;
import com.hci.smarthypermarket.models.Shopper;

public class DashBoardActivity extends Activity {
	
	Button StartScan;
	Button StartCard;
	Button StartBrowse;
	Button StartOrders;
	private Shopper shopper = LauncherActivity.shopper;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_dash_board);
		
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
        ab.setDisplayShowHomeEnabled(false);
        
        Category category = LauncherActivity.market.findCategory(new Bluetooth("Electronics", "E Address", -67));
        
        
        enableBlutooth();
        shopper.startBlutoothTracking(getApplicationContext(), new OnBluetoothListener(){
			
			@Override
			public void onBlutoothFound(Bluetooth bluetooth)
			{
				Toast.makeText(getApplicationContext(), "Welcome in " + bluetooth.getName() + " Section", Toast.LENGTH_LONG).show();
//				Category category = LauncherActivity.market.findCategory(bluetooth);
//				if (category != null)
//					Toast.makeText(getApplicationContext(), "Welcome in " + category.getName() + " Section", Toast.LENGTH_LONG).show();
			}
		});
        
		
        
        // Start BarCode activity when clicks on Scan Button
        StartScan = (Button) findViewById(R.id.home_scan);
        StartScan.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				startBarCodeActivity();
				
			}
		});
        
        // Start Cart activity when clicks on Cart Button
        StartCard = (Button) findViewById(R.id.home_mycart);
        StartCard.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				startCartActivity();
				
			}
		});
        
        StartOrders = (Button) findViewById(R.id.home_orders);
        StartOrders.setOnClickListener(new OnClickListener() {
        	
        	@Override
        	public void onClick(View v){
        		startOrdersActivity();
        	}
        });
        
        StartBrowse = (Button) findViewById(R.id.home_browse);
        StartBrowse.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View arg0) {
				startBrowseActivity();
				
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.dash_board, menu);
		return true;
	}
	
	private void enableBlutooth()
	{
		/* Check if the device supports bluetooth or not */
		BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
		if(bluetoothAdapter == null){
			Toast.makeText(getApplicationContext(), "Device doesn't support bluetooth", Toast.LENGTH_LONG).show();
		}
		else {
			/* Enabling bluetooth if the bluetooth is disabled */
			if(!bluetoothAdapter.isEnabled()){
				Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
			    startActivityForResult(enableBtIntent, 57);
			    Toast.makeText(getApplicationContext(), "Enabling bluetooth", Toast.LENGTH_LONG).show();
			}
			
			
			
		}
	}
	
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		if(requestCode == 57){
			if(resultCode == RESULT_OK){
				Toast.makeText(getApplicationContext(), "Bluetooth is ON", Toast.LENGTH_LONG).show();
			}
			
			if(resultCode == RESULT_CANCELED){
				Toast.makeText(getApplicationContext(), "Error occured while enabling", Toast.LENGTH_LONG).show();
			}
		}
	}

	
	private void startBarCodeActivity(){
		Intent intentBarcode = new Intent(getApplicationContext(), BarCodeActivity.class);
		startActivity(intentBarcode);
	}
	
	private void startCartActivity(){
		Intent intent = new Intent(DashBoardActivity.this, CartActivity.class);
		startActivity(intent);
	}
	
	private void startBrowseActivity(){
		Intent intent = new Intent(DashBoardActivity.this, BrowseActivity.class);
		startActivity(intent);
	}
	
	private void startOrdersActivity(){
		Intent intent = new Intent(DashBoardActivity.this, OrderActivity.class);
		startActivity(intent);
	}

}
