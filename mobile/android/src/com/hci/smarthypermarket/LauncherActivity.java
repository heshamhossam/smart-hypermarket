package com.hci.smarthypermarket;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

public class LauncherActivity extends Activity {
	
	public static Shopper shopper = null;
	private Market market = null;
	private Boolean onLocationChangeCalled = false;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.acticity_launcher);
		
		
		
		
		shopper = new Shopper(this) {

			@Override
			protected void onLocationChange() {
				super.onLocationChange();
				//create a mark object from the shopper location
				market = new Market(this.getLocation())
				{
					@Override
					protected void onMarketRetrieved(Market market) {
						super.onMarketRetrieved(market);
						shopper.setMarketId("" + market.getId());
						if (!onLocationChangeCalled)
						{
							onLocationChangeCalled = true;
							startCartActivity();
						}
						
					}
				};
				
			}
			
		};
		
		shopper.trackPosition(this);
		
	}
	
	private void startCartActivity() {
		Intent intent = new Intent(LauncherActivity.this, DashBoardActivity.class);
		startActivity(intent);
		
	}

}
