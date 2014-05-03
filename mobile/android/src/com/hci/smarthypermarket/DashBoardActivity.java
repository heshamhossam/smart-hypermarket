package com.hci.smarthypermarket;

import android.os.Bundle;
import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class DashBoardActivity extends Activity {
	
	Button StartScan;
	Button StartCard;
	Button StartBrowse;
	Button StartOrders;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_dash_board);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
        ab.setDisplayShowHomeEnabled(false);
        
        
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
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.dash_board, menu);
		return true;
	}
	
	private void startBarCodeActivity(){
		Intent intent = new Intent(DashBoardActivity.this, BarCodeActivity.class);
		startActivity(intent);
	}
	
	private void startCartActivity(){
		Intent intent = new Intent(DashBoardActivity.this, CartActivity.class);
		startActivity(intent);
	}
	
	private void startBrowseActivity(){
		
	}
	
	private void startOrdersActivity(){
		Intent intent = new Intent(DashBoardActivity.this, OrderActivity.class);
		startActivity(intent);
	}

}
