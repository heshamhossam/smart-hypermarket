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
        
        StartScan = (Button) findViewById(R.id.home_scan);
        StartScan.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				startBarCodeActivity();
				
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
		
	}
	
	private void startBrowseActivity(){
		
	}
	
	private void startOrdersActivity(){
		
	}

}
